using System;
using System.Collections;
using UnityEngine;

public class TempAnimationProcessor : MonoBehaviour, CharacterStateMachineBinder
{
    private IEnumerator CurrAnimation;

    public void AttackAnimation(Action callback)
    {
        Debug.Log("attack anim!!!");

        if (CurrAnimation != null)
        {
            StopCoroutine(CurrAnimation);
            CurrAnimation = null;
        }

        CurrAnimation = DebugRoutine("AttackAnimation", 1f, callback);
        StartCoroutine(CurrAnimation);
    }

    public void DamagedAnimation(Action callback)
    {
        if (CurrAnimation != null)
        {
            StopCoroutine(CurrAnimation);
            CurrAnimation = null;
        }

        CurrAnimation = DebugRoutine("DamagedAnimation", 0.5f, callback);
        StartCoroutine(CurrAnimation);
    }

    public void DeadAnimation(Action callback)
    {
        if (CurrAnimation != null)
        {
            StopCoroutine(CurrAnimation);
            CurrAnimation = null;
        }

        CurrAnimation = DebugRoutine("DeadAnimation", 1f, callback);
        StartCoroutine(CurrAnimation);
    }

    public void IdleAnimation()
    {
        Debug.Log("idle anim!!!");

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
        var elapsedTime = 0f;
        Debug.Log("start");
        while (true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > 1000f)
                break;

            Debug.Log($"State : {animation}");
            yield return new WaitForSeconds(0.2f);
        }
    }

    private IEnumerator DebugRoutine(string animation, float time, Action action)
    {
        var elapsedTime = 0f;
        var startTime = Time.time;
        while (elapsedTime < time)
        {
            elapsedTime = Time.time - startTime;
            var progress = Mathf.Clamp01(elapsedTime / time) * 100; // 퍼센트 계산
            Debug.Log($"{animation} : {progress:F1}%");
            yield return new WaitForSeconds(0.25f);
        }

        action?.Invoke();
    }
}