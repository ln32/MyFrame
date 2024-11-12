using System;
using System.Collections;
using UnityEngine;

public class AnimationProcessor : MonoBehaviour
{
    public void StartTimeAction(float time, Action action)
    {
        StartCoroutine(TimeActionCoroutine(time, action));
    }

    private IEnumerator TimeActionCoroutine(float time, Action action)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / time) * 100; // 퍼센트 계산
            Debug.Log($"Progress: {progress:F2}%");
            yield return null;
        }

        action?.Invoke();
        Debug.Log("Action Executed!");
    }
}
