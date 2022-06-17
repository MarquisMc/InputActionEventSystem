using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;
using UnityEditor;

[System.Serializable]
public class InputActions 
{
    [Tooltip("the name of the input action")]
    public string inputName;
    
    // all of the input types are listed here
    // more input types can be added to this list
    public enum InputType
    {
        MultiTapInput,
        HoldAndPressInput,
        HoldAndWaitInput,

        NUM_STATES
    }

    public InputType CurrentInputType = InputType.MultiTapInput;

    // MultiTapInput variable
    // the input that is pressed
    public KeyCode pressInput;

    // HoldAndPressInput variable
    // HoldAndWaitInput variable
    // the input that is held down
    public KeyCode holdInput;

    // MultiTapInput variable
    // HoldAndPressInput variable
    // HoldAndWaitInput variable
    public BoolData isListening;
    
    // MultiTapInput variable
    // max tap number
    public int maxNum;

    public int tapCounter;
    
    // MultiTapInput variable
    // the timer will start counting down from this value
    public float startDuration;

    // HoldAndPressInput variable
    // how long the hold input will be held for
    public float holdTime;
    
    [Tooltip("these are the events that will be called when the input is triggered")] 
    public UltEvent inputEvent;

    public TimerData timerData = new TimerData();
}