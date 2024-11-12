using DesignPatterns.StateMachines;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterStateMachine : MonoBehaviour
{
    public AnimationProcessor processor;

    // Inspector fields
    [Header("Preload (Splash Screen)")]
    [Tooltip("Prefab assets that load first. These can include level management Prefabs or textures, sounds, etc.")]
    [SerializeField] GameObject[] m_PreloadedAssets;  // Required assets to load before the GameStateManager sets up states

    [Space(10)]
    [Tooltip("Debug state changes in the console")]
    [SerializeField] bool m_Debug;

    StateMachine m_StateMachine = new StateMachine();


    IState IdleState;
    IState AttackState;
    IState DamagedState;
    IState MoveState;
    IState DeadState; 
  
    Action OnAttack;   
    Action OnDamaged;
    Action OnMove;

    Action TimeToIdle;
    Action OnDead;
    Action NullAction = () => {; };

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
        m_StateMachine.Run(IdleState);
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
        IdleState = new State(IdleStateFunc, "Idle",true);
        AttackState = new State(AttackStateFunc, "Attack", true);
        DamagedState = new State(DamagedStateFunc, "OnDamaged", true);
        MoveState = new State(MoveStateFunc, "Move", true);
        DeadState = new State(DeadStateFunc, "Dead", true);
    }

    /// <summary>
    /// This defines how the different states can transition to other states.
    /// </summary>
    private void AddLinks()
    {
        // Transition from main menu to submenu states
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnMove), MoveState));
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnAttack), AttackState));

        DamagedState.AddLink(new EventLink(new ActionWrapper(ref TimeToIdle), IdleState));

        AttackState.AddLink(new EventLink(new ActionWrapper(ref TimeToIdle), IdleState));
        AttackState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));

        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnMove), MoveState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnAttack), AttackState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref TimeToIdle), IdleState));
    }


    public int CaseIndex;
    [Button]
    public void Setact0()
    {
        switch (CaseIndex)
        {
            case 1:
                OnAttack.Invoke();
                break;
            case 2:
                OnDamaged.Invoke();
                break;
            case 3:
                OnMove.Invoke();
                break;
            case 4:
                TimeToIdle.Invoke();
                break;
            default: break;
        }
    }

    public void IdleStateFunc()
    {
        Debug.Log("IdleStateFunc");
    }

    public void AttackStateFunc()
    {
        processor.StartTimeAction(1f, TimeToIdle);
    }

    public void DamagedStateFunc()
    {
        processor.StartTimeAction(3f, TimeToIdle);
    }

    public void MoveStateFunc()
    {
        Debug.Log("MoveStateFunc");
    }

    public void DeadStateFunc()
    {
        Debug.Log("DeadStateFunc");
    }
}
