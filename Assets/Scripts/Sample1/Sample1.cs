using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Sample1
{
    public class Sample1 : MonoBehaviour
    {
        async UniTaskVoid Start()
        {
            Debug.Log("Start Thread:" + Thread.CurrentThread.ManagedThreadId);

            var Token = this.GetCancellationTokenOnDestroy();

            var Result = await Work(Token);
            Debug.Log(Result);

            Result = await Work2(Token);
            Debug.Log(Result);
        }

        private async Task<string> Work(CancellationToken Token)
        {
            return await Task.Run(async () =>
            {
                Debug.Log("Working Thread:" + Thread.CurrentThread.ManagedThreadId);
                await Task.Delay(1000, Token);
                return "Work Finish Thread:" + Thread.CurrentThread.ManagedThreadId;
            }, Token);
        }

        private async UniTask<string> Work2(CancellationToken Token)
        {
            return await Task.Run(async () =>
            {
                Debug.Log("Working UniTask Thread:" + Thread.CurrentThread.ManagedThreadId);
                await Task.Delay(1000, Token);
                return "Work Finish UniTask Thread:" + Thread.CurrentThread.ManagedThreadId;
            }, Token);
        }
    }
}
