<<<<<<< HEAD
using System;
    =======
using AnimationState;
>>>>>>> 5b6471c(fix #137)
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

    [Space(10)] [Tooltip("Debug state changes in the console")] [SerializeField]
    private bool m_Debug;

    private readonly StateMachine m_StateMachine = new();

    public TempAnimationProcessor _AnimationProcessor;
        <<<<<<<

    private IState CastAnimationState;

    public State CurrState;
    IState DamagedState;
    private IState DamagedState;
    private IState DeadState;
    private IState DeadState;


    private IState IdleState;


    private IState IdleState;

    private StateMachine m_StateMachine = new();
    private IState MoveState;
    private IState MoveState;

    private Action NullAction = () => { ; };
        >>>>>>> 5

    private Action NullAction = () => { ; };
    private IState RecoveryState;
    private b6471c(fix #137)
    public CharacterStateMachineBinder AnimationProcessor { get; set; }
    public CharacterStateMachineBinder AnimationProcessor { get; set; }

    private void Start()
    {
        AnimationProcessor = _AnimationProcessor;
        Initialize();
    }

    private HEAD
        IState AttackState;
    ====== =

    [Button]
    private void Initialize()
    {
        // Set up the coroutines helper for non-MonoBehaviours
        Coroutines.Initialize(this);

        // Define the Game States
        SetStates();
        AddLinks();

        OnTimeToIdle += m_StateMachine.FakeLoop;
        OnAttack += m_StateMachine.FakeLoop;
        OnRecovery += m_StateMachine.FakeLoop;

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

    HEAD

    #region Define

    /// <summary>
    /// This defines how the different states can transition to other states.
    /// </summary>
    private void SetStates()
    {
        // Menu states (optional names added for debugging)
        IdleState = new State("Idle", IdleStateFunc);
        CastAnimationState = new State("Casting", OnCastAnimation);
        RecoveryState = new State("Recovery", OnRecoveryFunc);

        DamagedState = new State("OnDamaged", DamagedStateFunc);
        MoveState = new State("Move", MoveStateFunc);
        DeadState = new State("Dead", DeadStateFunc);
    }

    private void AddLinks()
    {
        // Transition from main menu to submenu states
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnMove), MoveState));
        IdleState.AddLink(new EventLink(new ActionWrapper(ref OnAttack), CastAnimationState));

        DamagedState.AddLink(new EventLink(new ActionWrapper(ref OnTimeToIdle), IdleState));

        CastAnimationState.AddLink(new EventLink(new ActionWrapper(ref OnRecovery), RecoveryState));
        //CastAnimationState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));

        RecoveryState.AddLink(new EventLink(new ActionWrapper(ref OnTimeToIdle), IdleState));

        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnDamaged), DamagedState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnMove), MoveState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnAttack), CastAnimationState));
        MoveState.AddLink(new EventLink(new ActionWrapper(ref OnTimeToIdle), IdleState));
    }

    #endregion Define

    #region OnAttack

    <<<<<<< HEAD

    private Action OnAttack;

    public void Event_Attack()
        ====== =

    private Action OnAttack;
    private Action OnCastFinish;

    public void Event_CastAttack(Action castSkill)
        >>>>>>> 5

    private b6471c(fix #137)
    {
        Debug.Log("Start_CastAttack");
        if (OnCastFinish != null)
        {
            Debug.Log("OnCastFinish != null");
            return;
        }

        OnCastFinish = castSkill;
        OnAttack();
        AnimationProcessor.AttackAnimation(OnRecovery);
    }

    public void OnCastAnimation()
    {
        Debug.Log("OnCastAnimation");
    }
    <<<<<<< HEAD
    ====== =
    private Action OnRecovery;

    public void OnRecoveryFunc()
    {
        OnCastFinish();
        OnCastFinish = null;
        Debug.Log("OnRecoveryFunc");
        AnimationProcessor.AttackAnimation(Event_TimeToIdle);
    }
    >>>>>>> 5

    private b6471c(fix #137)

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
        Debug.Log("Event_TimeToIdle");
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

    <<<<<<<
}
====== =


public void IdleStateFunc()
{
    Debug.Log("IdleStateFunc");
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
}
>>>>>>> 5b6471c (fix #137)