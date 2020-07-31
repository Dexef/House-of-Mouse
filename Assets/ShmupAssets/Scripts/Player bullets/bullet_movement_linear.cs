using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_movement_linear : MonoBehaviour
{
    public float speed = 20f;

    public Rigidbody2D bullet;
    Transform direction;


    // Start is called before the first frame update
    void Start()
    {
        //direction = transform;
        bullet.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
