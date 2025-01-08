using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

public class Unitask_DelaySkillEnqueue
{
    private readonly List<CancellationTokenSource> _activeTasks = new();

    public async UniTaskVoid RepeatedAction(Action func, int count, float timegapMs)
    {
        if (func == null || count <= 0 || (count > 1 && timegapMs <= 0))
        {
            NabeDebug.Log($"Except by : {func == null} / {count <= 0} / {count > 1 && timegapMs <= 0}");
            throw new Exception();
        }

        int tempValue = (int)(timegapMs * 1000);

        CancellationTokenSource cts = new();
        _activeTasks.Add(cts);

        func();
        for (int i = 1; i < count; i++)
        {
            await UniTask.Delay(tempValue, cancellationToken: cts.Token);
            func();
        }

        _activeTasks.Remove(cts);
    }

    public async UniTaskVoid DelayedAction(Action func, float delayMs)
    {
        int tempValue = (int)(delayMs * 1000);

        CancellationTokenSource cts = new();
        _activeTasks.Add(cts);

        await UniTask.Delay(tempValue, cancellationToken: cts.Token);

        func();
        _activeTasks.Remove(cts);
    }

    public void ClearAllTasks()
    {
        foreach (CancellationTokenSource cts in _activeTasks)
        {
            cts.Cancel();
        }

        _activeTasks.Clear();
        NabeDebug.Log("All tasks have been cleared.");
    }
}