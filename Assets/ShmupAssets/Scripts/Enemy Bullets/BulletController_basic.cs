using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController_basic : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D bullet;

    public bool grazed;

    Transform direction;

    void Start()
    {
        direction = transform;
        bullet.AddForce(direction.up * speed, ForceMode2D.Impulse);
        grazed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")) 
        {
            Destroy(gameObject);
        }
    }
}

