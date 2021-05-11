using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

public class Sample1 : MonoBehaviour
{
    async void Start()
    {
        Debug.Log("Start Thread:" + Thread.CurrentThread.ManagedThreadId);

        var Result = await Work();
        Debug.Log(Result);

        Result = await Work2();
        Debug.Log(Result);
    }

    private async Task<string> Work()
    {
        return await Task.Run(async () =>
        {
            Debug.Log("Working Thread:" + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            return "Work Finish Thread:" + Thread.CurrentThread.ManagedThreadId;
        });
    }

    private async UniTask<string> Work2()
    {
        return await Task.Run(async () =>
        {
            Debug.Log("Working UniTask Thread:" + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(1000);
            return "Work Finish UniTask Thread:" + Thread.CurrentThread.ManagedThreadId;
        });
    }
}
