using System;
using DesignPatterns.StateMachines;
using Sirenix.OdinInspector;
using UnityEngine;

public interface IStateMachine
{
    CharacterStateMachine GetStateMachine { get; }
}

// TODO : 내 상태 interface 시키기
public class CharacterStateMachine : MonoBehaviour
{
    [Space(10)] [Tooltip("Debug state changes in the console")] [SerializeField]
    private bool m_Debug;

    public TempAnimationProcessor _AnimationProcessor;
    IState AttackState;

    public State CurrState;
    IState DamagedState;
    private IState DeadState;


    private IState IdleState;

    private readonly StateMachine m_StateMachine = new();
    private IState MoveState;

    private Action NullAction = () => { ; };
    public CharacterStateMachineBinder AnimationProcessor { get; set; }

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
        OnAttack += () => m_StateMachine.FakeLoop();
        OnTimeToIdle += () => m_StateMachine.FakeLoop();

        // Start the State Machine
        RunStateMachine();
    }

    // Begin tracking game states
    private void RunStateMachine()
    {
        // Start with the main menu scene
        m_StateMachine.Run(IdleState);
    }


    public void IdleStateFunc()
    {
        AnimationProcessor.IdleAnimation();
    }

    public void DamagedStateFunc()
    {
        AnimationProcessor.DamagedAnimation(OnTimeToIdle);
    }

    public void MoveStateFunc()
    {
        AnimationProcessor.MoveAnimation();
    }

    public void DeadStateFunc()
    {
        AnimationProcessor.DeadAnimation(() => Debug.Log("I am dead"));
    }

    #region Define

    /// <summary>
    /// This defines how the different states can transition to other states.
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

    private void AddLinks()
    {
        // Transition from main menu to submenu states
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnMove), MoveState));
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnAttack), AttackState));

        DamagedState.AddLink(new EventLink(new ActionWrapper(ref OnTimeToIdle), IdleState));

        AttackState.AddLink(new EventLink(new ActionWrapper(ref OnTimeToIdle), IdleState));
        AttackState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));

        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnMove), MoveState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnAttack), AttackState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnTimeToIdle), IdleState));
    }

    #endregion Define


    #region OnAttack

    private Action OnAttack;

    public void Event_Attack()
    {
        OnAttack.Invoke();
    }

    public void AttackStateFunc()
    {
        AnimationProcessor.DamagedAnimation(OnTimeToIdle);
    }

    #endregion OnAttack


    #region OnDamaged

    private Action OnDamaged;

    public void Event_Damaged()
    {
        OnDamaged.Invoke();
    }

    #endregion OnDamag


    #region OnMove

    private Action OnMove;

    public void Event_Move()
    {
        OnMove.Invoke();
    }

    #endregion OnMove


    #region ToIdle

    private Action OnTimeToIdle;

    public void Event_TimeToIdle()
    {
        OnTimeToIdle.Invoke();
    }

    #endregion ToIdle


    #region OnDead

    private Action OnDead;

    public void Event_OnDead()
    {
        OnDead();
    }

    #endregion OnDead
}