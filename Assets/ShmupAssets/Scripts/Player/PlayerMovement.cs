using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float focusSpeed;
    private float speed;

    public Rigidbody2D rb;
    public Animator anim;

    public GameObject forceField;

    Vector2 movement;

    // Start is called before the first frame update
    private void Start()
    {
        speed = moveSpeed;

    }
    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.LeftShift)) 
        {
            speed = focusSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            speed = moveSpeed;
        }

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Speed", Mathf.Abs(movement.x));
        //sqrMagnitude è più efficiente di magnitude perchè semplifica
        //calcolo radice quadrata
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //fixedDeltaTime permette velocità costante
        
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
