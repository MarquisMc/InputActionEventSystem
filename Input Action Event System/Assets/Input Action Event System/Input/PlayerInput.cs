using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;
using UnityEditor;

public class PlayerInput : MonoBehaviour
{
    // TODO: I might need to move these objects to InputActions.cs
    MultiTapInput multiTapInputObj = new MultiTapInput();
    HoldInput holdInputObj = new HoldInput();

    [Tooltip("list of all the input actions")]
    public List<InputActions> inputActions = new List<InputActions>();

    private void Update() 
    {
        InputCurrent();
    }

    private void InputCurrent()
    {
        for (int i = 0; i < inputActions.Count; i++)
        {
            // current input type is multi tap input
            if (inputActions[i].CurrentInputType == InputActions.InputType.MultiTapInput)
            {
               inputActions[i].tapCounter = multiTapInputObj.MultiTap(inputActions[i].pressInput, inputActions[i].inputEvent,
                inputActions[i].isListening, inputActions[i].maxTapNum, inputActions[i].tapDuration, inputActions[i].tapCounter, inputActions[i].timerData);
            }

            // current input type is hold and press input
            if (inputActions[i].CurrentInputType == InputActions.InputType.HoldAndPressInput)
            {
                holdInputObj.HoldAndPress(inputActions[i].holdInput, inputActions[i].pressInput,
                inputActions[i].inputEvent, inputActions[i].isListening);
            }
            
            // current input type is hold and wait input
            if (inputActions[i].CurrentInputType == InputActions.InputType.HoldAndWaitInput)
            {
                holdInputObj.HoldAndWait(inputActions[i].holdInput, inputActions[i].inputEvent,
                inputActions[i].isListening, inputActions[i].holdTime, inputActions[i].timerData);
            }
        }
    }
}