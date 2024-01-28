using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public static BulletGenerator instance;
    public GameObject bulletPrefab1, bulletPrefab2;

    float generatePos_x_player_1 = -4.76f, generatePos_x_player_2 = 4.76f;
    float bullet_posY_bottom = -5f, bullet_posY_top = 4f;

    private void Awake()
    {
        instance = this;
    }


    public void _emit_bullet_player_1(float posY)
    {
        var _posY = posY.Map(0f, 1f, bullet_posY_bottom, bullet_posY_top); 
        Vector3 generatePos = new Vector3(generatePos_x_player_1, _posY, 0);
        GameObject bullet = Instantiate(bulletPrefab1, generatePos, Quaternion.identity);
    }

    public void _emit_bullet_player_2(float posY)
    {
        var _posY = posY.Map(0f, 1f, bullet_posY_bottom, bullet_posY_top);
        Vector3 generatePos = new Vector3(generatePos_x_player_2, _posY, 0);
        GameObject bullet = Instantiate(bulletPrefab2, generatePos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
