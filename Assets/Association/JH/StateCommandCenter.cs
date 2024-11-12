using DesignPatterns.StateMachines;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Rendering.InspectorCurveEditor;

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
        // Menu states (optional names added for debugging)
        m_MainMenuState = new State(null,"m_MainMenuState",true);
        m_SolidMenuState = new State(null, "m_SolidMenuState", true);
        m_DesignPatternMenuState = new State(null, "m_DesignPatternMenuState", true);
        m_ResourcesMenuState = new State(null, "m_ResourcesMenuState", true);
    }

    Action act0;
    Action act1;
    Action act2;
    ActionPointer actionPointer;
    /// <summary>
    /// This defines how the different states can transition to other states.
    /// </summary>
    private void AddLinks()
    {
        act0 = PrintFunc;
        act1 = new Action(() => { Debug.Log("act1"); });
        act2 = new Action(() => { Debug.Log("act2"); });

        // Transition from main menu to submenu states
        m_MainMenuState.AddLink(new EventLink(new ActionWrapper(ref act0), m_SolidMenuState));
        m_SolidMenuState.AddLink(new EventLink(new ActionWrapper(ref act1), m_DesignPatternMenuState));
        m_DesignPatternMenuState.AddLink(new EventLink(new ActionWrapper(ref act2), m_MainMenuState));
    }
    
    void PrintFunc()
    {
        Debug.Log("act0");
    }

    [Button]
    public void Setact0()
    {
        act0.Invoke();
    }

    [Button]
    public void Setact1()
    {
        act1.Invoke();
    }
    [Button]
    public void Setact2()
    {
        act2.Invoke();
    }
}
