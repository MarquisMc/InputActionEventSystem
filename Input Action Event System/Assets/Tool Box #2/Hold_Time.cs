using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public class Hold_Time : MonoBehaviour
{
    //When holding a button,if you hold it for as long as "holdTimeDelay", then you can do "holdButtonAction". But if you let go before, you can do "upButtonAction"
    float delay;
    public void HoldTime(KeyCode holdInput, float holdTimeDelay, UltEventHolder upButtonAction, UltEventHolder holdButtonAction, BoolData isListening)
    {
        if (Input.GetKey(holdInput) && isListening.GetData())
        {
            delay += Time.deltaTime;
        }
        if (Input.GetKeyDown(holdInput))
        {
            delay = 0;
        }

        if(delay >= holdTimeDelay && holdButtonAction!=null)
        {
            holdButtonAction.Invoke();
        }

        if(delay < holdTimeDelay && Input.GetKeyUp(holdInput) && upButtonAction != null)
        {
            upButtonAction.Invoke();
        }
    }
}
