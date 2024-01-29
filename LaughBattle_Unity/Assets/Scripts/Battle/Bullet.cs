using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool Player_1 = false, Player_2 = false;
	public Sprite[] _sprite;
    Rigidbody2D rigid;
    Vector2 moveDir;
    float speed = 3f;
    void Start()
	{
		rigid = GetComponent<Rigidbody2D>();
		GameObject child = transform.GetChild(0).gameObject;
		child.GetComponent<SpriteRenderer>().sprite = _sprite[Random.Range(0, _sprite.Length)];

		if (transform.position.x < 0) //bullet from Player 1
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
		if (Player_1 == true)
		{
			if (collision.gameObject.tag == "Player_2")
			{
				Debug.Log("hit player 2");
				BattleSystem.instance._calculateDamage(2, 1);
				Player_2_battle_Animation.instance._playHitAnim();
				SE.instance._playOneShot_randamaze(1);
				Destroy(this.gameObject);
			}

			if (collision.gameObject.tag == "Bullet_2")
			{
				SE.instance._playOneShot_randamaze(0);
				Destroy(this.gameObject);
			}
		}

		if (Player_2 == true)
		{
			if (collision.gameObject.tag == "Player_1")
			{
				Debug.Log("hit player 1");
				BattleSystem.instance._calculateDamage(1, 1);
                Player_1_battle_Animation.instance._playHitAnim();
                SE.instance._playOneShot_randamaze(1);
                Destroy(this.gameObject);
			}

			if (collision.gameObject.tag == "Bullet_1")
			{
                SE.instance._playOneShot_randamaze(0);

                Destroy(this.gameObject);
			}
		}




	}
}
