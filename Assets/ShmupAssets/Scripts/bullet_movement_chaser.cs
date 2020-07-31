using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMathFunctions;

[RequireComponent(typeof(Rigidbody2D))]
public class bullet_movement_chaser : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public float rotateSpeed = 200f;

    public Rigidbody2D bullet;
    public Transform target;

    CMath cmath;

    void Start()
    {
        IEnumerator coroutine;
        target = findClosestEnemy();
        if(target != null) 
        {
            coroutine = home(target);
            StartCoroutine(coroutine);
        }
        else 
        {
            bullet.AddForce(transform.up * speed, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {

    }


    IEnumerator home(Transform target)
    {
        while (target != null)
        {
            Vector2 direction = (Vector2)target.position - bullet.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            bullet.angularVelocity = -rotateAmount * rotateSpeed;
            bullet.velocity = transform.up * speed;

            yield return new WaitForSeconds(0.01f);
        }
    }


    Transform findClosestEnemy() 
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        if (gos.Length > 0)
        {
            foreach (GameObject go in gos)
            {
                Vector2 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
        }

        if(closest == null) 
        {
            return null;
        }
        else 
        {
            Debug.DrawLine(transform.position, closest.transform.position, Color.red);
            return closest.transform;
        }
        /*
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        //iterates through all found objects
        foreach (GameObject go in gos)
        {
            //distance to current object
            Vector2 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        */

    }

}
