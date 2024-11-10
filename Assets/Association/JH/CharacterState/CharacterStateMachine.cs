using DesignPatterns.StateMachines;
using System;

public class CharacterStateMachine : StateMachine
{
    public CharacterStateMachine(IState state)
    {
        SetCurrentState(state);
    }

    public override void SetCurrentState(IState state)
    {
        if (state == null)
            throw new ArgumentNullException(nameof(state));

        if (CurrentState != null && m_CurrentPlayCoroutine != null)
        {
            //interrupt currently executing state
            Skip();
        }

        CurrentState = state;

        Coroutines.StartCoroutine(Play());
    }
    public override void Run(IState state)
    {
        SetCurrentState(state);
        Run();
    }

    public override void Run()
    {
        if (m_LoopCoroutine != null) //already running
            return;

        m_LoopCoroutine = Coroutines.StartCoroutine(Loop());

    }
}
