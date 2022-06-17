using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public slow slowMotion;
    public float slowMoDuration;
    public float slowTimeScale;

    void SlowMo2(float slowMotionDuration, float slowTimeScale, BoolData canDo)
    {
        if (canDo.GetData())
        {
            StartCoroutine(slowMotion.DoManipulateTimeScale(slowMotionDuration, slowTimeScale));
        }
    }
}
