using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public static BulletGenerator instance;
    public GameObject bulletPrefab;

    float generatePos_x_player_1 = -4.76f, generatePos_x_player_2 = 4.76f;
    float bullet_posY_bottom = -2.56f, bullet_posY_top = 2.45f;

    private void Awake()
    {
        instance = this;
    }


    public void _emit_bullet_player_1(float posY)
    {
        Vector3 generatePos = new Vector3(generatePos_x_player_1, posY, 0);
        GameObject bullet = Instantiate(bulletPrefab, generatePos, Quaternion.identity);
    }

    public void _emit_bullet_player_2(float posY)
    {
        Vector3 generatePos = new Vector3(generatePos_x_player_2, posY, 0);
        GameObject bullet = Instantiate(bulletPrefab, generatePos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
