using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;
using UnityEditor;

public class InputEvents : MonoBehaviour
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
            MultiTap(i);

            HoldAndPress(i);

            HoldAndWait(i);

            GetKeyUp(i);
        }
    }

    void MultiTap(int index)
    {
        // current input type is multi tap input
        if (inputActions[index].CurrentInputType == InputActions.InputType.MultiTapInput)
        {
            inputActions[index].tapCounter = multiTapInputObj.MultiTap(inputActions[index].pressInput, inputActions[index].inputEvent,
            inputActions[index].isListening, inputActions[index].maxTapNum, inputActions[index].tapDuration, inputActions[index].tapCounter, inputActions[index].timerData);
        }
    }

    void HoldAndPress(int index)
    {
        // current input type is hold and press input
        if (inputActions[index].CurrentInputType == InputActions.InputType.HoldAndPressInput)
        {
            holdInputObj.HoldAndPress(inputActions[index].holdInput, inputActions[index].pressInput,
            inputActions[index].inputEvent, inputActions[index].isListening);
        }
    }

    void HoldAndWait(int index)
    {
        // current input type is hold and wait input
        if (inputActions[index].CurrentInputType == InputActions.InputType.HoldAndWaitInput)
        {
            holdInputObj.HoldAndWait(inputActions[index].holdInput, inputActions[index].inputEvent,
            inputActions[index].isListening, inputActions[index].holdTime, inputActions[index].timerData);
        }
    }

    void GetKeyUp(int index)
    {
        // current input type is get key up input
        if (inputActions[index].CurrentInputType == InputActions.InputType.GetKeyUpInput)
        {
            holdInputObj.GetKeyUp(inputActions[index].pressInput, inputActions[index].inputEvent,
            inputActions[index].isListening);
        }
    }
}