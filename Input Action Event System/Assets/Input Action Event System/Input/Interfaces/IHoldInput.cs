using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public interface IHoldInput
{
    void HoldAndPress(KeyCode holdInput, KeyCode pressInput, UltEvent ultEvent, BoolData isListening);
    void HoldAndPressButton(string holdInput, string pressInput, UltEvent ultEvent, BoolData isListening);
    void HoldAndWait(KeyCode holdInput, UltEvent ultEvent, BoolData isListening, float holdTime, TimerData timerData);
    void HoldAndWaitButton(string holdInput, UltEvent ultEvent, BoolData isListening, float holdTime, TimerData timerData);
    void GetKeyUp(KeyCode key, UltEvent ultEvent, BoolData isListening);
    void GetButtonUp(string HoldAndReleaseInput, UltEvent ultEvent, BoolData isListening);
}
