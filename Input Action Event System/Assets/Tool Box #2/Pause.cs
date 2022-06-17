using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    bool toggle;

    void togglePause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            toggle = !toggle;
        }

        if (toggle)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void UnpauseButton()
    {
        toggle = false;
    }
}
