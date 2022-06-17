using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public GameObjectData forceObj;
    public BoolData canAddForce;
    public Rigidbody rb;

    public LayerMask layer;
    public void AddForceToObj(Vector3 direction, float dashForce)
    {
        if (canAddForce.GetData() == true && rb != null)
        {
            rb.AddForce(forceObj.GetData().transform.TransformDirection(direction.normalized) * dashForce, ForceMode.Impulse);
            //rb.isKinematic = false;
            Debug.Log("add force");
        }
    }

    void AddForceOnImpact(Collision collision, GameObjectData addForceObj, BoolData isListening , Vector3 direction, float force, ForceMode forceMode)
    {
        if (collision.gameObject == addForceObj.GetData() && isListening.GetData())
        {
            Debug.Log("bounce back");

            direction = transform.position - collision.gameObject.transform.position;

            rb.AddForce(addForceObj.GetData().transform.TransformDirection(direction.normalized) * force, forceMode);

        }
    }
}
