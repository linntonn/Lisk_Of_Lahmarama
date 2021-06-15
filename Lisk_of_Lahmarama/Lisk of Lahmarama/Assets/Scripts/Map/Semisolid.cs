using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semisolid : MonoBehaviour
{

    [SerializeField]
    private BoxCollider trigger;
    [SerializeField]
    private Collider platformCollider;

    [SerializeField]
    private float fallThroughTimer = 0.25f;

    private PlayerInput player1;
    private PlayerInput player2;

    private bool ignorePlayer1 = false;
    private bool ignorePlayer2 = false;

    private float p1Timer;
    private float p2Timer;

    private void Update()
    {
        if (ignorePlayer1)
        {
            p1Timer -= Time.deltaTime;
            if (p1Timer <= 0)
            {
                player1.gameObject.layer = 9;
                ignorePlayer1 = false;
            }
        }

        if (ignorePlayer2)
        {
            p2Timer -= Time.deltaTime;
            if (p2Timer <= 0)
            {
                player2.gameObject.layer = 9;
                ignorePlayer2 = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<PlayerInput>() != null)
        {
            Physics.IgnoreCollision(other, platformCollider, true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.position.y > transform.position.y && other.tag == "Player")
        {
            PlayerInput pi = other.gameObject.GetComponent<PlayerInput>();

            if (pi != null )
            {
                if ((pi.playerNumber == 1 && ignorePlayer1) || (pi.playerNumber == 2 && ignorePlayer2))
                {
                    pi.gameObject.layer = 10;
                }
                else if (pi.heldDirection == 2 && pi.resetJumpPress == true)
                {
                    pi.gameObject.layer = 10;
                    pi.crouches.Clear();
                    if (pi.playerNumber == 1)
                    {
                        ignorePlayer1 = true;
                        player1 = pi;
                        p1Timer = fallThroughTimer;
                    }
                    else
                    {
                        ignorePlayer2 = true;
                        player2 = pi;
                        p2Timer = fallThroughTimer;
                    }
                    
                }
                else if (pi.moveDirection.y < pi.baseWeight)
                {
                    Physics.IgnoreCollision(other, platformCollider, false);
                }
            }
        }
    }
}
