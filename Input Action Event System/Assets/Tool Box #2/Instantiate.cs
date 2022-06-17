using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public void InstantiateAtPosition(GameObject pos, GameObject instaniatedObj)
    {
        Instantiate(instaniatedObj, pos.transform.position, Quaternion.identity);
    }
}
