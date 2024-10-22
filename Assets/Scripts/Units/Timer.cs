using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action TimeIsUp;

    public void StartTimer(int time)
    {
        StartCoroutine(CountdownTime(time));
    }

    private IEnumerator CountdownTime(int time)
    {
        float passedTime = 0;

        while (passedTime < time)
        {
            passedTime += Time.deltaTime;

            yield return null;
        }
        
        TimeIsUp?.Invoke();
    }
}