using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcefieldController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Enemy Bullet"))
        {
            if(collision.gameObject.GetComponent<BulletController_basic>().grazed == false) 
            {
                player.GetComponent<player_collisions>().graze();
                UIController.Instance.addScore(25);
                collision.gameObject.GetComponent<BulletController_basic>().grazed = true;
            }

        }
    }
}
