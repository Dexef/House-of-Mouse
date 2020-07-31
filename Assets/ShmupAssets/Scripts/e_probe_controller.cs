using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMathFunctions;

public class e_probe_controller : MonoBehaviour
{
    //movement
    public float moveSpeed;
    private float direction;

    //bullets
    public GameObject bullet1;

    //shooting
    public float bullet1Speed;
    public float cooldown1;

    private IEnumerator fire1;

    //shooting function
    //get player direction

    // gameObject/component references
    private Rigidbody2D rb;
    private GameObject player;

    CMath CMath;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody2D>();
        direction = gameObject.GetComponent<EnemyController_basic>().direction;

        fire1 = shooting(cooldown1);
        StartCoroutine(fire1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator shooting(float cooldown) 
    {
        while (player != null)
        {
            shoot();
            yield return new WaitForSeconds(cooldown);
        }
    }

    void shoot()
    {
        if (player != null)
        {
            Quaternion shootDir = CMath.DirCalc(player, gameObject);
            GameObject bul = Instantiate(bullet1, gameObject.transform.position, shootDir);
            Rigidbody2D bulRB = bul.GetComponent<Rigidbody2D>();
            bulRB.AddForce(bulRB.transform.up * bullet1Speed, ForceMode2D.Impulse);
        }
    }

    //movement and direction
    void FixedUpdate()
    {
        float rad = direction * Mathf.Deg2Rad;
        float vectorX = moveSpeed * Mathf.Cos(rad);
        float vectorY = moveSpeed * Mathf.Sin(rad);
        Vector2 angle = new Vector2(vectorX, vectorY);

        rb.MovePosition(rb.position + angle * Time.fixedDeltaTime);
    }
}
