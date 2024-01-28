using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool Player_1 = false, Player_2 = false;
    Rigidbody2D rigid;
    Vector2 moveDir;
    float speed = 3f;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        if(transform.position.x < 0) //bullet from Player 1
        {
            moveDir = Vector2.right;
            Player_1 = true;
        }
        else //bullet from Player 2
        {
            moveDir = Vector2.left;
            Player_2 = true;

        }

    }

    void Update()
    {
        rigid.velocity = moveDir * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Player_1==true)
        {
            if(collision.gameObject.tag == "Player_2")
            {
                Debug.Log("hit player 2");
                BattleSystem.instance._calculateDamage(2, 1);
                Destroy(this.gameObject);
            }
        }

        if (Player_2 == true)
        {
            if (collision.gameObject.tag == "Player_1")
            {
                Debug.Log("hit player 1");
                BattleSystem.instance._calculateDamage(1, 1);

                Destroy(this.gameObject);
            }
        }
    }
}
