using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static DG.Tweening.DOTweenAnimation;

public class AnimationProcessor : MonoBehaviour, CharacterStateMachineBinder
{
    IEnumerator CurrAnimation;
    public void AttackAnimation(Action callback)
    {
        if (CurrAnimation != null)
        {
            StopCoroutine(CurrAnimation);
            CurrAnimation = null;
        }

        CurrAnimation = DebugRoutine("AttackAnimation",0.5f, callback);
        StartCoroutine(CurrAnimation);
    }

    public void DamagedAnimation(Action callback)
    {
        if (CurrAnimation != null)
        {
            StopCoroutine(CurrAnimation);
            CurrAnimation = null;
        }

        CurrAnimation = DebugRoutine("DamagedAnimation", 1.0f, callback);
        StartCoroutine(CurrAnimation);
    }

    public void DeadAnimation(Action callback)
    {
        if (CurrAnimation != null)
        {
            StopCoroutine(CurrAnimation);
            CurrAnimation = null;
        }

        CurrAnimation = DebugRoutine("DeadAnimation", 2f, callback);
        StartCoroutine(CurrAnimation);
    }

    public void IdleAnimation()
    {
        if (CurrAnimation != null)
            StopCoroutine(CurrAnimation);

        CurrAnimation = DebugRoutine("IdleAnimation");
        StartCoroutine(CurrAnimation);
    }

    public void MoveAnimation()
    {
        if (CurrAnimation != null)
            StopCoroutine(CurrAnimation);

        CurrAnimation = DebugRoutine("MoveAnimation");
        StartCoroutine(CurrAnimation);
    }

    private IEnumerator DebugRoutine(string animation)
    {
        float elapsedTime = 0f;

        while (true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 1000f)
                break;

            Debug.Log($"State : {animation}");
            yield return null;
        }
    }

    private IEnumerator DebugRoutine(string animation, float time, Action action)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / time) * 100; // 퍼센트 계산
            Debug.Log($"{animation} : {progress:F2}%");
            yield return null;
        }

        action?.Invoke();
    }
}