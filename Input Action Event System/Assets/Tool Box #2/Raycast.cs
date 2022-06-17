using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;

public class Raycast : MonoBehaviour
{
    // after testing hide in inspector
    public RaycastHit hit;

    // call this when you want to use a raycast 
    public void RaycastCall(Transform origin, Vector3 direction, float maxDistance)
    {
        // direction.foward or direction.what ever the direction is
        if (Physics.Raycast(origin.position, origin.TransformDirection(direction), out hit, maxDistance))
        {
            Debug.DrawRay(origin.position, origin.TransformDirection(direction) * maxDistance, Color.blue);
            //Debug.Log(hit.collider.name);
        }
        else
        {
            Debug.DrawRay(origin.position, origin.TransformDirection(direction) * maxDistance, Color.red);
        }
    }

    // call this when you want to use a raycast 
    public void FireRayCast(Transform origin, Vector3 direction, float maxDistance)
    {
        // direction.foward or direction.what ever the direction is
        if (Physics.Raycast(origin.position, origin.TransformDirection(direction), out hit, maxDistance))
        {
            Debug.DrawRay(origin.position, origin.TransformDirection(direction) * maxDistance, Color.blue);
            Debug.Log(hit.collider.name);

            if (!hit.collider.gameObject.TryGetComponent<Health>(out Health health))
            {
                return;
            }

            if (health)
            {
                UltEventHolder ultEventHolder = hit.collider.gameObject.GetComponent<UltEventHolder>();

                if (ultEventHolder)
                {
                    ultEventHolder.Invoke();
                }
            }

        }
        else
        {
            Debug.DrawRay(origin.position, origin.TransformDirection(direction) * maxDistance, Color.red);
        }
    }
}
