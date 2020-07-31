using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomMathFunctions;

public class LevelManager : MonoBehaviour
{

    IEnumerator levelFLow;
    Vector3 topBorder;

    private GameObject enemy_Probe;
    private GameObject powerUp1;

    private void Awake()
    {
        enemy_Probe = Resources.Load<GameObject>("Prefabs/Enemies/enemy_Probe") as GameObject;
        powerUp1 = Resources.Load<GameObject>("Prefabs/Items/power-up 1") as GameObject;
    }
    void Start()
    {
        topBorder = new Vector3(0.0f, 1.2f, 10f);

        levelFLow = section1();
        StartCoroutine(levelFLow);
    }

    IEnumerator section1() 
    {
        //wave 1
        spawn(enemy_Probe, 0.2f, 0f , 0f);
        spawn(enemy_Probe, 0.6f, -0.1f, 0f);

        yield return new WaitForSeconds(3f);

        //wave2
        /*
        for(int i = 1; i <= 10; i += 2) 
        {
            spawn(enemy_Probe, 0.0f + 0.1f * i, 0f, 0f);
        }

        for (int i = 0; i <= 10; i += 2)
        {
            spawn(enemy_Probe, 0.0f + 0.1f * i, -0.2f, 0f);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        
    }

    //used to spawn an enemy, xoff and yoff are the offsets of the spawn location, ranging from 0 to 1 relative to the camera
    //dir is the spawn direction angle, 0 goes from top to bottom
    public void spawn(GameObject obj, float xoff, float yoff, float dir)
    {
        float camx = topBorder.x + xoff;
        float camy = topBorder.y + yoff;

        var instance = Instantiate(obj, Camera.main.ViewportToWorldPoint(new Vector3(topBorder.x + xoff, topBorder.y + yoff, topBorder.z)), new Quaternion(0,0,0,0));
        //var instance = Instantiate(obj, topBorder, new Quaternion(0, 0, 0, 0));
        instance.GetComponent<EnemyController_basic>().direction += dir;
        //print("x =" + instance.transform.position.x + " y = " + instance.transform.position.y);
    }
}
