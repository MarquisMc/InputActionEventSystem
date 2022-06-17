using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour
{
    public void SetActiveScriptWithTime(float dur, bool activeBool, Behaviour obj)
    {
        //StartCoroutine(WithTime(dur, activeBool, obj.GetData()));
    }

    public void SetActiveGameObjWithTime(float dur, bool activeBool, GameObjectData obj )
    {
        StartCoroutine(WithTime(dur, activeBool, obj.GetData()));
    }

    public void SetComponentActive(float dur, bool active, Behaviour obj)
    {
        StartCoroutine(ComponentWithTime(dur, active, obj));
    }

    IEnumerator WithTime(float dur, bool activeBool, GameObject obj)
    {

        yield return new WaitForSeconds(dur);

        obj.SetActive(activeBool);
    }
    IEnumerator ComponentWithTime(float dur, bool activeBool, Behaviour obj)
    {

        yield return new WaitForSeconds(dur);
        obj.enabled = activeBool;
    }
    
}
