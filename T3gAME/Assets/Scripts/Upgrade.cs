using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControl;

public class Upgrade : MonoBehaviour
{
    PlayerController playerControl;
    private void Awake()
    {
        playerControl = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        if (transform.position.y < -5f)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Trio"))
        {
            playerControl.bullet = Resources.Load("BulletTrio") as GameObject;
        }
        else if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Mega"))
        {
            playerControl.bullet = Resources.Load("BulletMega") as GameObject;
        }
        else if (collision.gameObject.CompareTag("Player") && gameObject.CompareTag("One"))
        {
            playerControl.bullet = Resources.Load("Bullet") as GameObject;
        }

        Destroy(gameObject);
    }
}
