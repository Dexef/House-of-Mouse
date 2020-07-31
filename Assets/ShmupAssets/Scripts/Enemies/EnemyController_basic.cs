using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMathFunctions;

public class EnemyController_basic : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject drop;
    
    public float maxHealth;
    public float direction;
    public int bounty;

    private float health;

    void Start()
    {
        health = maxHealth;
    }


    //collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enabled)
        {
            if (collision.gameObject.tag.Equals("Player Bullet"))
            {
                player_bullet_controller dmg_script = collision.GetComponent<player_bullet_controller>();
                float damage = dmg_script.damage;

                addDamage(damage);
            }
            else if (collision.gameObject.tag.Equals("Bullet Border"))
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                Destroy(gameObject);
            }
        }
        
    }

    private void addDamage(float damage) 
    {
        health -= damage;
        if(health <= 0) 
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        UIController.Instance.addScore(bounty);
        if(drop != null) 
        {
            Instantiate(drop, gameObject.transform.position, new Quaternion(0,0,0,0));
        }
    }
}
