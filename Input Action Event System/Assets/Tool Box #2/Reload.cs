using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public FloatData currentBullets;
    public BoolData canShoot;
    public float clipSize;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReloadGun();
    }

    void ReloadGun()
    {
        if (currentBullets.GetData() <= 0)
        {
            canShoot.SetData(false);
        }

        if (Input.GetKeyDown(KeyCode.R) && canShoot.GetData() == false)
        {
            canShoot.SetData(true);
            currentBullets.SetData(clipSize);
        }
    }
}
