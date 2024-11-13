using DesignPatterns.StateMachines;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterStateMachine : MonoBehaviour
{
    public AnimationProcessor _AnimationProcessor;
    public CharacterStateMachineBinder AnimationProcessor { get; set; }

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
        AnimationProcessor = _AnimationProcessor;
        Initialize();
    }

    [Button]
    private void Initialize()
    {
        // Set up the coroutines helper for non-MonoBehaviours
        Coroutines.Initialize(this);

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
        AnimationProcessor = _AnimationProcessor ;
    }

    /// <summary>
    /// Defines the runtime states of the game/tutorial application.
    /// </summary>
    private void SetStates()
    {
        // Menu states (optional names added for debugging)
        IdleState = new State(IdleStateFunc, "Idle");
        AttackState = new State(AttackStateFunc, "Attack");
        DamagedState = new State(DamagedStateFunc, "OnDamaged");
        MoveState = new State(MoveStateFunc, "Move");
        DeadState = new State(DeadStateFunc, "Dead");
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

    [Button]
    public void Event_Attack()
    {
        OnAttack.Invoke();
    }

    [Button]
    public void Event_Damaged()
    {
        OnDamaged.Invoke();
    }

    [Button]
    public void Event_Move()
    {
        OnMove.Invoke();
    }

    [Button]
    public void Event_TimeToIdle()
    {
        AnimationProcessor.IdleAnimation();
    }

    public void IdleStateFunc()
    {
        AnimationProcessor.MoveAnimation();
    }

    public void AttackStateFunc()
    {
        AnimationProcessor.AttackAnimation(TimeToIdle);
    }

    public void DamagedStateFunc()
    {
        AnimationProcessor.DamagedAnimation(TimeToIdle);
    }

    public void MoveStateFunc()
    {
        AnimationProcessor.MoveAnimation();
    }

    public void DeadStateFunc()
    {
        AnimationProcessor.DeadAnimation(()=>Debug.Log("I am dead"));
    }
}
