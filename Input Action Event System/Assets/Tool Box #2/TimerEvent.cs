using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public class TimerEvent : MonoBehaviour
{
    public void DoTimerEvent(TimerData timer, UltEventHolder ultEvent, int timerEventInt)
    {
        if (timer.GetCurrentTimeInt() == timerEventInt)
        {
            ultEvent.Invoke();
        }
    }
}
