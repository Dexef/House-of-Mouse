using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMathFunctions;

public class shooting : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject crosshair;

    public float bul1CD = 0.25f;
    public float bul2CD = 0.25f;

    private bool bul1ready;
    private bool bul2ready;

    IEnumerator fire1;
    IEnumerator fire2;

    CMath CMath;

    // Start is called before the first frame update
    void Start()
    {
        bul1ready = true;
        bul2ready = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (bul1ready)
            {
                fire1 = shoot1(bul1CD);
                StartCoroutine(fire1);
            }
            if (bul2ready)
            {
                fire2 = shoot2(bul2CD);
                StartCoroutine(fire2);
            }
        }

    }

    IEnumerator shoot1(float cooldown) 
    {
        int powerLevel = gameObject.GetComponent<player_collisions>().powerLevel;
        bul1ready = false;
        switch (powerLevel)
        {
            case 3:
                shootNormal(bullet1, 0.1f, 0f);
                shootNormal(bullet1, -0.1f, 0f);
                shootNormal(bullet1, 0.2f, -3f);
                shootNormal(bullet1, -0.2f, 3f);
                shootNormal(bullet1, 0.2f, -15f);
                shootNormal(bullet1, -0.2f, 15f);
                break;
            case 2:
                shootNormal(bullet1, 0.1f, 0f);
                shootNormal(bullet1, -0.1f, 0f);
                shootNormal(bullet1, 0.2f, -3f);
                shootNormal(bullet1, -0.2f, 3f);
                break;
            case 1:
                shootNormal(bullet1, 0.0f, 0f);
                shootNormal(bullet1, 0.2f, 0f);
                shootNormal(bullet1, -0.2f, 0f);

                break;
            default:    //0
                shootNormal(bullet1, 0.15f, 0);
                shootNormal(bullet1, -0.15f, 0);
                break;
        }
        yield return new WaitForSeconds(cooldown);
        bul1ready = true;
    }

    IEnumerator shoot2(float cooldown) 
    {
        int powerLevel = gameObject.GetComponent<player_collisions>().powerLevel;
        bul2ready = false;
        switch (powerLevel)
        {
            case 3:
                shootNormal(bullet2, 0f, 0f);
                shootNormal(bullet2, 0.20f, 40f);
                shootNormal(bullet2, -0.20f, -40f);
                break;
            case 2:
                shootNormal(bullet2, 0.20f, 40f);
                shootNormal(bullet2, -0.20f, -40f);
                break;
            case 1:
                shootNormal(bullet2, 0f, 0f);
                break;
            default:    //0
                shootNormal(bullet2, 0.0f, 0f);
                break;
        }
        yield return new WaitForSeconds(cooldown);
        bul2ready = true;
    }

    //cooldowns


    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    void shootNormal(GameObject bullet, float offset, float angle) 
    {
        IEnumerator coroutine;
        Quaternion shootDir = CMath.DirCalc(crosshair,firePoint, angle);

        GameObject bul = Instantiate(bullet, firePoint.transform.position, shootDir);
        bul.GetComponent<SpriteRenderer>().enabled = false;

        coroutine = show();
        StartCoroutine(coroutine);
        bul.transform.Translate(new Vector3(offset, 0, 0) * 1, Space.Self);

        IEnumerator show() 
        {
            yield return new WaitForSeconds(0.04f);
            bul.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
