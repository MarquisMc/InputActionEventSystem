using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public class MultiTapInput : IMultiTapInput
{
    [SerializeField]
    int maxTapCounter;

    public int tapCounter;

    float delay = 0;
    bool delayOn = false;
    /// <summary>
    // 0.4 duration is double tap 
    // 0.6 duration is triple tap
    /// </summary>

    // this function is called when the input is triggered
    // it will check if the input is a multi tap input
    public int MultiTap(KeyCode input, UltEvent ultEvent, BoolData isListening, int maxNum, float startDuration, int tapCount, TimerData timerData)
    {
        if (Input.GetKeyDown(input) && isListening.GetData())
        {
            tapCount++;

            Debug.Log("Tap " + tapCount);

            if (tapCount >= maxNum)
            {             
                ultEvent.Invoke();
                tapCount = 0;
            }
        }

        // using timer data to start and stop the timer
        // if tapCounter is greater than or equal to 1 but less than maxNum 
        //then start the timer and when the timer is 0 then set the tapCounter to 0
        if (tapCount >= 1 && tapCount < maxNum)
        {
            timerData.StartTimer();

            if (timerData.GetCurrentTime() <= 0)
            {
                tapCount = 0;
                timerData.StopTimer();
                timerData.SetTimer(startDuration);
            }
        }
        else
        {
            timerData.SetTimer(startDuration);
            timerData.StopTimer();
        }

        return tapCount;
    }
    
    public int MultiTapButton(string input, UltEvent ultEvent, BoolData isListening, int maxNum, float startDuration, int tapCount, TimerData timerData)
    {
        if (Input.GetKeyDown(input) && isListening.GetData())
        {
            tapCount++;

            Debug.Log("Tap " + tapCount);

            if (tapCount >= maxNum)
            {
                ultEvent.Invoke();
                tapCount = 0;
            }
        }

        // using timer data to start and stop the timer
        // if tapCounter is greater than or equal to 1 but less than maxNum 
        //then start the timer and when the timer is 0 then set the tapCounter to 0
        if (tapCount >= 1 && tapCount < maxNum)
        {
            timerData.StartTimer();

            if (timerData.GetCurrentTime() <= 0)
            {
                tapCount = 0;
                timerData.StopTimer();
                timerData.SetTimer(startDuration);
            }
        }
        else
        {
            timerData.SetTimer(startDuration);
            timerData.StopTimer();
        }

        return tapCount;
    }

    public void BuffTapButton(string input, float delayTime, UltEvent ultEvent, BoolData isListening, TimerData timerData)
    {
        if (Input.GetButtonDown(input))
        {
            timerData.StartTimer();
            timerData.SetTimer(delayTime);
        }

        if(timerData.GetCurrentTime() <= 0 && isListening.GetData())
        {
            ultEvent.Invoke();
            timerData.StopTimer();
            timerData.SetTimer(delayTime);
        }
    }

    public void OrBuffTapButton(string input, float delayTime, UltEvent ultEvent, GetBoolData ActiveBools, TimerData timerData)
    {
        if (Input.GetButtonDown(input))
        {
            timerData.StartTimer();
            timerData.SetTimer(delayTime);
        }

        foreach (BoolData boolData in ActiveBools.wantedBoolDatas)
        {
            if (timerData.GetCurrentTime() <= 0 && boolData.GetData())
            {
                ultEvent.Invoke();
                timerData.StopTimer();
                timerData.SetTimer(delayTime);
            }
        }
    }
}