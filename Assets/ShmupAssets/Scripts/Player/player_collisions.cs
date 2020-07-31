using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collisions : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public int power;
    public int special;

    public int powerLevel;


    void Start()
    {
        UIController.Instance.powerUp(0, power);
        UIController.Instance.addScore(score);
        UIController.Instance.specialChange(0, special);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //enemy or bullet
        if ( collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Enemy Bullet") )
        {
            powerDown();
        }

        //power up
        if (collision.gameObject.tag.Equals("power-up"))
        {
            int bounty = collision.GetComponent<powerUpController>().powerBonus;
            int oldPower = power;
            power += bounty;

            if (power >= 30)
            {
                powerLevel = 3;
                power = 30;
            }
            else if( power >= 15)
            {
                powerLevel = 2;
            }
            else if (power >= 5) 
            {
                powerLevel = 1;
            }
            else 
            {
                powerLevel = 0;
            }

            UIController.Instance.powerUp(oldPower, power);
        }
    }

    void powerDown() 
    {
        int oldPower = power;
        switch (powerLevel)
        {
            
            case 3:
                powerLevel = 2;
                power = 15;
                break;
            case 2:
                powerLevel = 1;
                power = 5;
                break;
            case 1:
                powerLevel = 0;
                power = 1;
                break;
            case 0:
                power = 0;
                Destroy(gameObject);
                break;

        }
        UIController.Instance.powerDown(oldPower, power);
    }

    //increases special points, called by collision on ForcefieldController
    public void graze() 
    {
        if (special <= 30) 
        {
            special++;
            UIController.Instance.specialChange(special-1, special);
        }
    }

}
