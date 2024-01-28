using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera_Record : MonoBehaviour
{
    public static MainCamera_Record instance;
    public Camera myCamera;
    Vector3 initialCenterPos;
    public Vector3 Player_1_Pos, Player_2_pos;
    void Awake()
    {
        instance = this;
        myCamera = GetComponent<Camera>();
        initialCenterPos = transform.position;
    }

    void Update()
    {
        
    }
}
