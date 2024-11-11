using DesignPatterns.StateMachines;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class StateCommandCenter : MonoBehaviour
{
    // Inspector fields
    [Header("Preload (Splash Screen)")]
    [Tooltip("Prefab assets that load first. These can include level management Prefabs or textures, sounds, etc.")]
    [SerializeField] GameObject[] m_PreloadedAssets;  // Required assets to load before the GameStateManager sets up states

    [Space(10)]
    [Tooltip("Debug state changes in the console")]
    [SerializeField] bool m_Debug;

    StateMachine m_StateMachine = new StateMachine();

    // Define all States here
    IState m_MainMenuState;   // Show the main menu screen
    IState m_SolidMenuState;   // Show the Solid Menu screen
    IState m_DesignPatternMenuState;   // Show the Design Patterns Menu screen
    IState m_ResourcesMenuState;   // Show the Resources Menu screen


    public State CurrState;

    private void Start()
    {
        Initialize();
        
    }

    [Button]
    private void Initialize()
    {
        // Set up the coroutines helper for non-MonoBehaviours
        Coroutines.Initialize(this);

        // Load any assets or prefabs required to start the game
        InstantiatePreloadedAssets();

        // Define the Game States
        SetStates();
        AddLinks();

        // Start the State Machine
        RunStateMachine();
    }

    // Begin tracking game states
    private void RunStateMachine()
    {
        // Start with the main menu scene
        m_StateMachine.Run(m_MainMenuState);
    }

    // Use this to preload any assets. This is an opportunity to load any prefabs (with textures, models, etc.) 
    // in advance to avoid loading during gameplay 
    private void InstantiatePreloadedAssets()
    {
        foreach (var asset in m_PreloadedAssets)
        {
            if (asset != null)
                Instantiate(asset);
        }
    }

    /// <summary>
    /// Defines the runtime states of the game/tutorial application.
    /// </summary>
    private void SetStates()
    {
        CurrState = new State(null, "MainMenuState", m_Debug);
        // Menu states (optional names added for debugging)
        m_MainMenuState = CurrState;
        m_SolidMenuState = new State(null, "SolidMenuState", m_Debug);
        m_DesignPatternMenuState = new State(null, "DesignPatternsMenuState", m_Debug);
        m_ResourcesMenuState = new State(null, "ResourcesMenuState", m_Debug);
    }

    /// <summary>
    /// This defines how the different states can transition to other states.
    /// </summary>
    private void AddLinks()
    {
        // Transition from main menu to submenu states
        m_MainMenuState.AddLink(new EventLink(new ActionWrapper("m_SolidMenuState"), m_SolidMenuState));
        m_MainMenuState.AddLink(new EventLink(new ActionWrapper("m_DesignPatternMenuState"), m_DesignPatternMenuState));
        m_MainMenuState.AddLink(new EventLink(new ActionWrapper("m_ResourcesMenuState"), m_ResourcesMenuState));

    }
}
