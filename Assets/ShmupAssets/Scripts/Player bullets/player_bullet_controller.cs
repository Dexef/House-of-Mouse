using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bullet_controller : MonoBehaviour
{
    public float damage = 10f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag.Equals("Bullet Border")) 
        {
            Destroy(gameObject);
        }
    }

}
