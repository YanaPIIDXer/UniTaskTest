using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Sample1 : MonoBehaviour
{
    async void Start()
    {
        Debug.Log("Start Thread:" + Thread.CurrentThread.ManagedThreadId);

        var Result = await Work();
        Debug.Log(Result);
    }

    async Task<string> Work()
    {
        return await Task.Run(() =>
        {
            Debug.Log("Working Thread:" + Thread.CurrentThread.ManagedThreadId);
            return "Work Finish Thread:" + Thread.CurrentThread.ManagedThreadId;
        });
    }
}
