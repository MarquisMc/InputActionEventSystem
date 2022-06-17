using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltEvents;
public class TrackVelocity : MonoBehaviour
{
    [Header("TrackVelocity")]
    public FloatData trackingVelocity;
    public FloatData lastVelocity;
    public float velocityThres;
    public Rigidbody rb;

    void TrackVel() => trackingVelocity.SetData(rb.velocity.magnitude);

    void SetLastVelocityWithDistance(GameObjectData obj, FloatData trackVelo, FloatData lastVelo)
    {
        Vector3 vecToObj = transform.position - obj.transform.position;

        if (vecToObj.sqrMagnitude < 0.05f)
        {
            lastVelo = trackVelo;
        }
    }

    void SetLastVelocity(Collision collision, FloatData trackVelo ,FloatData lastVelo)
    {
        
        if (!collision.gameObject.TryGetComponent<TrackVelocity>(out TrackVelocity trackVelocity))
        {
            return;
        }
        
        if (trackVelocity)
        {
            lastVelo.SetData(trackVelo.GetData());
            Debug.Log(trackVelocity);
        }
        /*
        if (collision.collider.tag == "Impact")
        {
            lastVelo.SetData(trackVelo.GetData());
            Debug.Log(collision.collider.name);
        }
        */
    }

    void CompareLastVelocity(Collision collision,UltEventHolder callHurtEvent,FloatData selfLastVelocity, FloatData comparableLastVelocity)
    {
        if (!collision.gameObject.TryGetComponent<TrackVelocity>(out TrackVelocity trackVelocity))
        {
            return;
        }

        if (trackVelocity)
        {
            if (selfLastVelocity.GetData() < comparableLastVelocity.GetData())
            {
                // call an ult event
                callHurtEvent.Invoke();
                Debug.Log("lost");
            }
        }
    }

    void CompareTrackingVelocity(FloatData selfTrackingVelocity, FloatData comparableTrackingVelocity)
    {
        if (selfTrackingVelocity.GetData() < comparableTrackingVelocity.GetData())
        {
            // do something maybe call an ult event
        }
    }

    void GetDifferenceInVelocity(Collision collision, UltEventHolder ultEventHolder, FloatData selfLastVelocity, FloatData comparableLastVelocity, float veloThres)
    {
        if (!collision.gameObject.TryGetComponent<TrackVelocity>(out TrackVelocity trackVelocity))
        {
            return;
        }

        if (trackVelocity)
        {
            float difInVel = selfLastVelocity.GetData() - comparableLastVelocity.GetData();

            if (difInVel > -veloThres &&  difInVel < veloThres)
            {

            }
            else if (difInVel >= veloThres)
            {
                ultEventHolder.Invoke();
            }
        }
        
    }
}
