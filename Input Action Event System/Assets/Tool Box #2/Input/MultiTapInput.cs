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
    /// put this in inspector for the direction
    /// foward = vector3(0, 0, 1);
    /// back = vector3(0, 0, -1);
    /// right = vector3(1, 0, 0);
    /// left = vector3(-1, 0, 0);
    /// up = vector3(0, 1, 0);
    /// down vector3(0, -1, 0);
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
    
    public void MultiTapButton(string input, UltEvent ultEvent, BoolData isListening, int maxNum)
    {
        if (Input.GetButtonDown(input) && isListening.GetData())
        {
            tapCounter++;

            Debug.Log(tapCounter);

            if (tapCounter >= maxNum)
            {
                // call an ult event here
                ultEvent.Invoke();
                tapCounter = 0;
            }
        }
    }

    public void BuffTapButton(string input,float delayTime, UltEvent ultEvent, BoolData ActiveBool)
    {
        if (Input.GetButtonDown(input))
        {
            delayOn = true;
            delay = delayTime;
        }

        if (delayOn)
        {
            delay -= Time.deltaTime;
        }
        if(delay > 0 && ActiveBool.GetData())
        {
            ultEvent.Invoke();
            delay = 0;
            delayOn = false;
        }
    }
    public void OrBuffTapButton(string input, float delayTime, UltEvent ultEvent, GetBoolData ActiveBools)
    {
        if (Input.GetButtonDown(input))
        {
            delayOn = true;
            delay = delayTime;
        }

        if (delayOn)
        {
            delay -= Time.deltaTime;
        }

        foreach (BoolData boolData in ActiveBools.wantedBoolDatas)
        {
            if (delay > 0 && boolData.GetData())
            {
                ultEvent.Invoke();
                delay = 0;
                delayOn = false;
            }
        }

        
    }

    // 0.4 duration is double tap 
    // 0.6 duration is triple tap

    public void ResetMultiTap(float duration, float startDuration)    
    {
        
        if (tapCounter >= 1 && duration > 0)
        {
            // start a timer and count down to 0 when the timer is 0 then reset the tap counter
            duration -= Time.deltaTime;
        }

        if (duration <= 0)
        {
            tapCounter = 0;
            duration = startDuration;
        }
    }

    void DebugOnFloor()
    {
        Debug.Log("OnFloor");
    }
}