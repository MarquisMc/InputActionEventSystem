using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public class HoldInput : IHoldInput
{
    // for the hold and wait function
    float holdTimeDelay;

    float hold;

    private void Start()
    {
        hold = holdTimeDelay;
    }

    public void HoldAndPress(KeyCode holdInput, KeyCode pressInput, UltEvent ultEvent, BoolData isListening)
    {
        if (Input.GetKey(holdInput) && Input.GetKeyDown(pressInput) && isListening.GetData())
        {
            Debug.Log("press and hold");
            ultEvent.Invoke();
        }
    }
    
    public void HoldAndPressButton(string holdInput, string pressInput, UltEvent ultEvent, BoolData isListening)
    {
        if (Input.GetButton(holdInput) && Input.GetButtonDown(pressInput) && isListening.GetData())
        {
            Debug.Log("press and hold");
            ultEvent.Invoke();
        }
    }

    // using timer data to start and stop the timer
    public void HoldAndWait(KeyCode holdInput, UltEvent ultEvent, BoolData isListening, float holdTime, TimerData timerData)
    {
        if (Input.GetKey(holdInput) && isListening.GetData())
        {
            timerData.StartTimer();

            //Debug.Log("hold and wait" + holdTime);

            if (timerData.GetCurrentTime() <= 0)
            {
                ultEvent.Invoke();
                timerData.SetTimer(holdTime);
            }
        }else
        {
            timerData.SetTimer(holdTime);
        }

        if (Input.GetKeyUp(holdInput))
        {
            timerData.StopTimer();
        }
    }

    public void HoldAndWaitButton(string holdInput, UltEvent ultEvent, BoolData isListening, FloatData holdTime)
    {
        //hold time delay is dynamic and hold time is static

        if (Input.GetButton(holdInput) && isListening.GetData())
        {
            hold -= Time.deltaTime;


            if (hold <= 0)
            {
                ultEvent.Invoke();

            }
        }
        if (hold <= 0)
        {

            hold = holdTime.GetDataMax();
        }

    }

    public void GetKeyUp(KeyCode HoldAndReleaseInput, UltEvent ultEvent, BoolData isListening)
    {
        if (Input.GetKeyUp(HoldAndReleaseInput) && isListening.GetData())
        {
            
            ultEvent.Invoke();
        }
    }

    public void GetButtonUp(string holdAndReleaseInput, UltEvent ultEvent, BoolData isListening)
    {
        // isListening will = true if the player is carrying a body 
        // if the player is not carrying a body then is listening will be false

        if (Input.GetButtonUp(holdAndReleaseInput) && isListening.GetData())
        {
            
            ultEvent.Invoke();
        }
    }
}
