using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_health : MonoBehaviour {

    public float health = 100f;
    public GameObject deadCorps;
    public Image greenBar;

    private float damagePlayerBy = 15f;
    private float damageEnemyBy = 15f;

    private float easy = 0;
    private float medium = 1;
    private float hard = 2;


    internal void ChangeDifficulty(int value)
    {
        switch (value)
        {
            case 0:

                damagePlayerBy = 10f;
                damageEnemyBy = 50f;
                break;

            case 1:
                damagePlayerBy = 15f;
                damageEnemyBy = 15f;
                break;

            case 2:
                damagePlayerBy = 100f;
                damageEnemyBy = 5f;
                break;

            default:
                damagePlayerBy = 15f;
                damageEnemyBy = 15f;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            DamagePlayer();

            //Check Health Status
            if (health <= 0)
            {
                PlayerDies();
            }
        }
        
    }

    private void DamagePlayer()
    {
        modulateGUIBar();

        if (transform.tag == "Player")
        {

            health -= damagePlayerBy;

        }
        else
        {
            health -= damageEnemyBy;
        }
    }

    private void PlayerDies()
    {
        Transform deathPosition;

        deathPosition = transform;

        if (gameObject.transform.tag != "Player")
        {
            Destroy(this.gameObject);
            GameManager.addScore();
        }
        else
        {
            RespawnPlayer();
        }

        Instantiate(deadCorps, deathPosition.position, deathPosition.rotation);
    }


    private void RespawnPlayer()
    {
        health = 100;
        modulateGUIBar();

        transform.position = new Vector3(0, 1, 0);

        GameManager.score = 0;
    }

    private void modulateGUIBar()
    {
        float healthPercent = health / 100f;

        if (healthPercent >= 0)
        {
            greenBar.rectTransform.localScale = new Vector3( healthPercent, 1, 1 );
        }
    }

}
