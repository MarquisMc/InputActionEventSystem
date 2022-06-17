using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapSphere : MonoBehaviour
{
    public Collider[] overlapObjsArray;

    public Transform overlabboxPos;
    public Transform pos;
    public float range;

    public Collider[] overlapObjs;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OverlapBoxCall(Vector3 Scale)
    {
        overlapObjs = (Physics.OverlapBox(overlabboxPos.position, Scale / 2, Quaternion.identity));
    }

    public void OverlapSphereCall(Transform pos, float range)
    {
        overlapObjs = (Physics.OverlapSphere(pos.position, range));


        //overlapObjsArray = Physics.OverlapSphere(pos.position, range);
        //OnDrawGizmosSelected(pos, range);
        /*
        
        if (Physics.OverlapSphere(pos.position, range).Length == 0 && overlapObjs.Count != 0)
        {
            overlapObjs.RemoveAt(0);
            
        }
        

        //print(Physics.OverlapSphere(pos.position, range).Length);

        foreach (Collider objsInSphere in Physics.OverlapSphere(pos.position, range))
        {
            if (!overlapObjs.Contains(objsInSphere))
            {
                overlapObjs.AddRange(Physics.OverlapSphere(pos.position, range));
            }

            foreach (Collider objs in overlapObjs)
            {
                if (objs != objsInSphere)
                {
                    overlapObjs.Remove(objs);
                }
            }

            
        }
        */

        // make a new function called overlabBoxCall()
        /*
        if (Physics.OverlapBox(pos.position, ))
        {

        }
        */

    }

    /*
    private void OnDrawGizmosSelected()
    {
        if (pos.position == null)
            return;

        Gizmos.DrawWireSphere(pos.position, range);
    }
    */
    
    /*
    private void OnDrawGizmos()
    {
        if (overlabboxPos.position == null)
            return;

        Gizmos.DrawWireCube(overlabboxPos.position, )
    }
    */
}
