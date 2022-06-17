using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    void MaterialSwap(SkinnedMeshRenderer meshRenderer, Material orginal, Material currentMat, Material newMat, BodySwap canSwap)
    {
        // if canSwap is true and delay is less than 2 then the material will be the new material
        if (canSwap.canSwap && canSwap.delayTime < 2f)
        {
            for (int i = 0; i < meshRenderer.materials.Length; i++)
            {
                meshRenderer.material = newMat;
            }
        }

        // if canSwap is false then the material will be the orginal material
        if (!canSwap.canSwap)
        {
            for (int i = 0; i < meshRenderer.materials.Length; i++)
            {
                meshRenderer.material = orginal;
            }
        }
    }
    */
}
