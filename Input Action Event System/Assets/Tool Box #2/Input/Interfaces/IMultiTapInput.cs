using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public interface IMultiTapInput
{
    int MultiTap(KeyCode key, UltEvent ultEvent, BoolData isListening, int maxNum, float startDuration, int tapCount, TimerData timerData);
    void MultiTapButton(string key, UltEvent ultEvent, BoolData isListening, int maxNum);
    void BuffTapButton(string key, float delayTime, UltEvent ultEvent, BoolData ActiveBool);
    void OrBuffTapButton(string key, float delayTime, UltEvent ultEvent, GetBoolData ActiveBools);
    void ResetMultiTap(float duration, float startDuration);
}
