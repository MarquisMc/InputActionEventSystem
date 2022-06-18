using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public class MultiTapInput : IMultiTapInput
{
    /// <summary>
    /// explain the variables 
    /// UltEvents are from a 3rd party library that allows you to create advanced unity evente
    /// BoolData is a class that allows you to create a bool data type
    /// TimerData is a class that allows you to create a timer data type
    /// string input is a button name for the input
    // 0.4 duration is double tap 
    // 0.6 duration is triple tap
    /// </summary>

    // this function is called when the input is triggered
    // it will check if the input is a multi tap input
    public int MultiTap(KeyCode input, UltEvent ultEvent, BoolData isListening, int maxNum, float tapDuration, int tapCounter, TimerData timerData)
    {
        if (Input.GetKeyDown(input) && isListening.GetData())
        {
            tapCounter++;

            Debug.Log("Tap " + tapCounter);

            if (tapCounter >= maxNum)
            {             
                ultEvent.Invoke();
                tapCounter = 0;
            }
        }

        // using timer data to start and stop the timer
        // if tapCounter is greater than or equal to 1 but less than maxNum 
        //then start the timer and when the timer is 0 then set the tapCounter to 0
        if (tapCounter >= 1 && tapCounter < maxNum)
        {
            timerData.StartTimer();

            if (timerData.GetCurrentTime() <= 0)
            {
                tapCounter = 0;
                timerData.StopTimer();
                timerData.SetTimer(tapDuration);
            }
        }
        else
        {
            timerData.SetTimer(tapDuration);
            timerData.StopTimer();
        }

        return tapCounter;
    }
    
    public int MultiTapButton(string input, UltEvent ultEvent, BoolData isListening, int maxNum, float tapDuration, int tapCounter, TimerData timerData)
    {
        if (Input.GetKeyDown(input) && isListening.GetData())
        {
            tapCounter++;

            Debug.Log("Tap " + tapCounter);

            if (tapCounter >= maxNum)
            {
                ultEvent.Invoke();
                tapCounter = 0;
            }
        }

        // using timer data to start and stop the timer
        // if tapCounter is greater than or equal to 1 but less than maxNum 
        //then start the timer and when the timer is 0 then set the tapCounter to 0
        if (tapCounter >= 1 && tapCounter < maxNum)
        {
            timerData.StartTimer();

            if (timerData.GetCurrentTime() <= 0)
            {
                tapCounter = 0;
                timerData.StopTimer();
                timerData.SetTimer(tapDuration);
            }
        }
        else
        {
            timerData.SetTimer(tapDuration);
            timerData.StopTimer();
        }

        return tapCounter;
    }

    public void BuffTap(KeyCode input, float delayTime, UltEvent ultEvent, BoolData isListening, TimerData timerData)
    {
        if (Input.GetKeyDown(input) && isListening.GetData())
        {
            timerData.SetTimer(delayTime);
            timerData.StartTimer();
        }

        if (timerData.GetCurrentTime() <= 0)
        {
            ultEvent.Invoke();
            timerData.StopTimer();
            timerData.SetTimer(delayTime);
        }
    }

    public void BuffTapButton(string input, float delayTime, UltEvent ultEvent, BoolData isListening, TimerData timerData)
    {
        if (Input.GetButtonDown(input) && isListening.GetData())
        {
            timerData.SetTimer(delayTime);
            timerData.StartTimer();
        }

        if(timerData.GetCurrentTime() <= 0)
        {
            ultEvent.Invoke();
            timerData.StopTimer();
            timerData.SetTimer(delayTime);
        }
    }

    public void OrBuffTap(KeyCode input, float delayTime, UltEvent ultEvent, GetBoolData ActiveBools, TimerData timerData)
    {
        if (Input.GetKeyDown(input))
        {
            timerData.SetTimer(delayTime);
            timerData.StartTimer();
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

    public void OrBuffTapButton(string input, float delayTime, UltEvent ultEvent, GetBoolData ActiveBools, TimerData timerData)
    {
        if (Input.GetButtonDown(input))
        {
            timerData.SetTimer(delayTime);
            timerData.StartTimer();
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