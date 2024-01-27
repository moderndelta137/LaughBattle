using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public static BulletGenerator instance;

    private void Awake()
    {
        instance = this;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
