using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair_pointer : MonoBehaviour
{
    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint
            (
                new Vector3
                (
                    Input.mousePosition.x,
                    Input.mousePosition.y,
                    crosshair.transform.position.z
                )
            );
        crosshair.transform.position = target;
    }
}
