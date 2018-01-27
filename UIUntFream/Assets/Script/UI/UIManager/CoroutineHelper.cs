using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineHelper : MonoSingleton<CoroutineHelper>
{
    private DateTime start;

    private static readonly Queue<Action> ExecuteOnMainThread = new Queue<Action>();

    // 可追踪Coroutine的列表，用于判断某Coroutine是否正在运行
    private List<IEnumerator> runningCoroutinesByEnumerator = new List<IEnumerator>();

    //>-----------------------------------------------------------------------------

    /// <summary>
    /// 开始一个可追踪的Coroutine
    /// </summary>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public Coroutine StartTrackedCoroutine(IEnumerator coroutine)
    {
        return StartCoroutine(GenericRoutine(coroutine));
    }

    /// <summary>
    /// 停止一个可追踪的Coroutine
    /// </summary>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public void StopTrackedCoroutine(IEnumerator coroutine)
    {
        if (!runningCoroutinesByEnumerator.Contains(coroutine))
        {
            return;
        }
        StopCoroutine(coroutine);
        runningCoroutinesByEnumerator.Remove(coroutine);
    }

    /// <summary>
    /// 查询某Coroutine是否在执行
    /// </summary>
    /// <param name="coroutine"></param>
    /// <returns></returns>
    public bool IsTrackedCoroutineRunning(IEnumerator coroutine)
    {
        return runningCoroutinesByEnumerator.Contains(coroutine);
    }

    private IEnumerator GenericRoutine(IEnumerator coroutine)
    {
        runningCoroutinesByEnumerator.Add(coroutine);
        yield return StartCoroutine(coroutine);
        runningCoroutinesByEnumerator.Remove(coroutine);
    }

    public void CallActionWhenFrameEnd(Action action)
    {
        StartCoroutine(CallAction(action, new WaitForEndOfFrame()));
    }

    private IEnumerator WaitFrameCallAction(int frameCount, Action action)
    {
        var frame = 0;
        while (frame < frameCount)
        {
            frame++;
            yield return null;
        }

        if (action != null)
        {
            action();
        }
    }

    public void CallActionWaitFrame(int frameCount, Action action)
    {
        StartCoroutine(WaitFrameCallAction(frameCount, action));
    }


    public void CallActionDelay(Action action, float seconds = 0.1f)
    {
        StartCoroutine(CallAction(action, new WaitForSeconds(seconds)));
    }

    private IEnumerator CallAction(Action action, YieldInstruction instruction)
    {
        yield return instruction;

        action();

        yield break;
    }

    public void StartCoroutineOnMainThread(IEnumerator ie)
    {
        ExecuteOnMainThread.Enqueue(() => { StartCoroutine(ie); });
    }

    public void CallActionOnMainThread(Action action)
    {
        ExecuteOnMainThread.Enqueue(action);
    }

    public void Update()
    {
        while (ExecuteOnMainThread.Count > 0)
        {
            ExecuteOnMainThread.Dequeue().Invoke();
        }
    }

    /// <summary>
    /// 启动一个计时器，用于携程内的计时
    /// </summary>
    public void StartTimer()
    {
        start = DateTime.Now;
    }

    /// <summary>
    /// 检查时间
    /// </summary>
    /// <param name="miliseconds"></param>
    /// <returns></returns>
    public bool CheckIfPassed(int miliseconds)
    {
        DateTime now = DateTime.Now;
        double ms = (now - start).TotalMilliseconds;

        return ms >= miliseconds;
    }

}