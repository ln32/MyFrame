using System;
using System.Collections;
using UnityEngine;

namespace DesignPatterns.StateMachines
{
    /// <summary>
    ///     A Generic state machine, adapted from the Runner template
    ///     https://unity.com/features/build-a-runner-game
    /// </summary>
    public class StateMachine
    {
        protected Coroutine m_CurrentPlayCoroutine;

        protected Coroutine m_LoopCoroutine;

        protected bool m_PlayLock;

        // The current state the statemachine is in
        public IState CurrentState { get; protected set; }

        public bool IsRunning => m_LoopCoroutine != null;

        /// <summary>
        ///     Finalizes the previous state and then runs the new state
        /// </summary>
        /// <param name="state"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual void SetCurrentState(IState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (CurrentState != null && m_CurrentPlayCoroutine != null)
                //interrupt currently executing state
                Skip();

            CurrentState = state;
            Coroutines.StartCoroutine(Play());
        }

        /// <summary>
        ///     Runs the life cycle methods of the current state.
        /// </summary>
        /// <returns></returns>
        protected IEnumerator Play()
        {
            if (!m_PlayLock)
            {
                m_PlayLock = true;

                CurrentState.Enter();

                //keep a ref to execute coroutine of the current state
                //to support stopping it later.
                m_CurrentPlayCoroutine = Coroutines.StartCoroutine(CurrentState.Execute());

                yield return m_CurrentPlayCoroutine;

                m_CurrentPlayCoroutine = null;
            }
        }

        /// <summary>
        ///     Interrupts the execution of the current state and finalizes it.
        /// </summary>
        /// <exception cref="Exception"></exception>
        protected void Skip()
        {
            if (CurrentState == null)
                throw new Exception($"{nameof(CurrentState)} is null!");

            if (m_CurrentPlayCoroutine != null)
            {
                Coroutines.StopCoroutine(ref m_CurrentPlayCoroutine);
                //finalize current state
                CurrentState.Exit();
                m_CurrentPlayCoroutine = null;
                m_PlayLock = false;
            }
        }

        public virtual void Run(IState state)
        {
            SetCurrentState(state);
            Run();
        }

        public virtual void Run()
        {
            if (m_LoopCoroutine != null) //already running
                return;

            m_LoopCoroutine = Coroutines.StartCoroutine(Loop());
        }

        /// <summary>
        ///     Turns off the main loop of the StateMachine
        /// </summary>
        public void Stop()
        {
            if (m_LoopCoroutine == null) //already stopped
                return;

            if (CurrentState != null && m_CurrentPlayCoroutine != null)
                //interrupt currently executing state
                Skip();

            Coroutines.StopCoroutine(ref m_LoopCoroutine);
            CurrentState = null;
        }

        /// <summary>
        ///     The main update loop of the StateMachine.
        ///     It checks the status of the current state and its link to provide state sequencing
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerator Loop()
        {
            while (false)
            {
                if (CurrentState != null && m_CurrentPlayCoroutine == null) //current state is done playing
                    if (CurrentState.ValidateLinks(out var nextState))
                    {
                        if (m_PlayLock)
                        {
                            //finalize current state
                            CurrentState.Exit();
                            m_PlayLock = false;
                        }

                        CurrentState.DisableLinks();
                        SetCurrentState(nextState);
                        CurrentState.EnableLinks();
                    }

                yield return null;
            }
        }


        public void FakeLoop()
        {
            if (CurrentState != null && m_CurrentPlayCoroutine == null) //current state is done playing
                if (CurrentState.ValidateLinks(out var nextState))
                {
                    if (m_PlayLock)
                    {
                        //finalize current state
                        CurrentState.Exit();
                        m_PlayLock = false;
                    }

                    CurrentState.DisableLinks();
                    SetCurrentState(nextState);
                    CurrentState.EnableLinks();
                }
        }
    }
}


public static class Coroutines
{
    private static MonoBehaviour s_CoroutineRunner;

    public static bool IsInitialized => s_CoroutineRunner != null;

    public static void Initialize(MonoBehaviour runner)
    {
        s_CoroutineRunner = runner;
    }

    public static Coroutine StartCoroutine(IEnumerator coroutine)
    {
        if (s_CoroutineRunner == null) throw new InvalidOperationException("CoroutineRunner is not initialized.");

        return s_CoroutineRunner.StartCoroutine(coroutine);
    }

    public static void StopCoroutine(Coroutine coroutine)
    {
        if (s_CoroutineRunner != null) s_CoroutineRunner.StopCoroutine(coroutine);
    }

    public static void StopCoroutine(ref Coroutine coroutine)
    {
        if (s_CoroutineRunner != null && coroutine != null)
        {
            s_CoroutineRunner.StopCoroutine(coroutine);
            coroutine = null;
        }
    }
}

public class ActionPointer
{
    public ActionPointer()
    {
    }

    public ActionPointer(ref Action _Action)
    {
        _Action += () => { Action?.Invoke(); };
    }

    private Action Action { get; set; }

    public void AddAction(Action target)
    {
        Action += target;
    }

    public void RemoveAction(Action target)
    {
        Action -= target;
        Action -= () => { Action?.Invoke(); };
        Action = null;
    }

    public void Invoke()
    {
        Action?.Invoke();
    }
}