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
        GetKeyUpInput,

        NUM_STATES
    }
    
    [Space(10f)]

    public InputType CurrentInputType = InputType.MultiTapInput;

    // MultiTapInput variable
    // the input that is pressed
    public KeyCode pressInput;

    // HoldAndPressInput variable
    // HoldAndWaitInput variable
    // the input that is held down
    public KeyCode holdInput;

    [Space(10f)]

    // MultiTapInput variable
    // HoldAndPressInput variable
    // HoldAndWaitInput variable
    public BoolData isListening;
    
    // MultiTapInput variable
    // max tap number
    public int maxTapNum;

    // MultiTapInput variable
    // the number of taps occurred
    [HideInInspector]
    public int tapCounter;
    
    // MultiTapInput variable
    // the timer will start counting down from this value
    public float tapDuration;

    // HoldAndPressInput variable
    // how long the hold input will be held for
    public float holdTime;
    
    [Tooltip("these are the events that will be called when the input is triggered")] 
    public UltEvent inputEvent;

    // multi tap input variable
    // HoldAndWaitInput variable
    // timer will count down when the input is pressed or held down
    public TimerData timerData = new TimerData();
}