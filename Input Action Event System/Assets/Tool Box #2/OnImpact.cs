using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpact : MonoBehaviour
{
    // this is so the obj that is being impacted can reference it

    public void SoundOnImpactWithHighVelo(Collision collision, string OtherPlayerName, AudioSource sound, FloatData trackVelo, GameObject dustCloud)
    {
        if (collision.collider.name != OtherPlayerName )
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;

            if (trackVelo.GetData() >= 8f)
            {
                Instantiate(dustCloud, pos, Quaternion.identity);
            }

            if (trackVelo.GetData() >= 6f)
            {
                sound.Play();
            }
        }
    }

    public void SpawnOnImpact(Collision collision, GameObjectData objImpact, GameObject spawnedObj)
    {
        if (collision.collider.gameObject == objImpact.GetData())
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;

            Instantiate(spawnedObj, pos, Quaternion.identity);
            Debug.Log("clash");
        }
    }
}
