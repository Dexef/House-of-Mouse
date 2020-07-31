using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpController : MonoBehaviour
{
    public int powerBonus;

    private Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, 1) * 100f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player")) 
        {
            Destroy(gameObject);
        }
    }
}
