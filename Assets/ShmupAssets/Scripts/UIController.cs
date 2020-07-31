using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //variables
    public int score;
    public int powerLevel;

    //UI components

    public static UIController Instance;
    public Text scoreText;
    public Text powerText;
    public Text specialText;

    //gameobject references
    public GameObject player;

    private void Start()
    {
        //inizializza singleton
        Instance = this;
        DontDestroyOnLoad(this);
    }


    //increase score, called when defeating enemies or other events
    public void addScore(int toAdd)
    {
        score += toAdd;
        scoreText.text = score.ToString();
    }

    //adds 1 point to power, called on power item pickup. Increases the power level at certain marks.
    public void powerUp(int oldPower, int newPower)
    {
        IEnumerator coroutine;
        coroutine = init();
        StartCoroutine(coroutine);

        IEnumerator init()
        {
            for (int i = oldPower; i < newPower; i++)
            {
                if (powerText.text.Length <= 60)
                {
                    powerText.text += "[]";
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    public void powerDown(int oldPower, int newPower)
    {
        IEnumerator coroutine;
        coroutine = init();
        StartCoroutine(coroutine);

        IEnumerator init() 
        {
            for (int i = oldPower; i > newPower; i--)
            {
                if (powerText.text.Length > 1) 
                {
                    powerText.text = powerText.text.Remove(powerText.text.Length - 2);
                }
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    public void specialChange(int oldSpecial, int newSpecial)
    {
        IEnumerator coroutine;

        //is special increases
        if (oldSpecial < newSpecial)
        {
            coroutine = increase();
            StartCoroutine(coroutine);
        }

        //if special decreases
        if(oldSpecial > newSpecial) 
        {
            coroutine = decrease();
            StartCoroutine(coroutine);
        }


        IEnumerator increase()
        {
            for (int i = oldSpecial; i < newSpecial; i++)
            {
                specialText.text += "[]";
                yield return new WaitForSeconds(0.01f);
            }
        }

        IEnumerator decrease()
        {
            for (int i = oldSpecial; i > newSpecial; i--)
            {
                specialText.text = specialText.text.Remove(powerText.text.Length - 2);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
