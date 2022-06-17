using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow : MonoBehaviour
{
    public float orginal;

    // Start is called before the first frame update
    void Start()
    {
        orginal = 1f;
    }

    public IEnumerator DoManipulateTimeScale(float duration, float timeScale)
    {        
        Time.timeScale = timeScale;

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = orginal;
    }

}
