using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SNESInteraction : MonoBehaviour
{
    public GameObject player;

    public Camera snesCamera;
    public Camera playerCamera;

    private void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        snesCamera = this.GetComponentInChildren<Camera>(true);
        snesCamera.enabled = false;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("enter snes");
            playerCamera.enabled = false;
            snesCamera.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("exit snes");
            playerCamera.enabled = true;
            snesCamera.enabled = false;
        }
    }
}
