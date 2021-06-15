using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthDragonAI : MonoBehaviour
{
    public float healthMAX = 2310;
    public float health = 2310;

    public CharacterController dragController;
    public Animator dragAnim;
    public Vector3 facingDirection;
    public Vector3 currentFacingRotation;
    public Vector3 moveDirection;
    public float maxRadDelta;
    public float maxMagDelta;

    public GameObject target1;
    public GameObject target2;
    public GameObject mainTarget;
    public Vector3 targetLocation;

    public GameObject meteor;
    public List<Transform> meteorSpawns;

    public int phase = 1;

    public int randomNumber = 0;
    public float aggroTimer;
    public float aggroCounter;

    public float speed;

    public bool canMove = true;

    public List<Collider> hitboxes;
    //Mouth
    //Left
    //Right

    public List<GameObject> arenaSegments;

    public int attackID;
    public bool canAttack = true;
    public float attackCDTimer;
    public float attackCDCounter;
    public float attackCounter;
    public float attack1Timer;
    public float attack2Timer;
    public float attack3Timer;
    public float attack4Timer;
    public float attack5Timer;

    public float meteorRainTimer = 10f;
    public float meteorRainCounter;
    public float meteorTimer = 1f;
    public float meteorCounter;

    public bool damaged;
    public Renderer dragMesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (health <= healthMAX / 3 && phase == 1)
        {
            phase = 2;
            meteorRainTimer = 200;
            Destroy(arenaSegments[0]);
            Destroy(arenaSegments[1]);
        }
        if (health <= 0)
        {
            meteorRainCounter = 0;
            canMove = false;
            dragAnim.SetInteger("AttackID", 0);
            dragAnim.SetBool("Death", true);
            hitboxes[0].enabled = false;
            hitboxes[1].enabled = false;
            hitboxes[2].enabled = false;
        }
        else
        {
            randomNumber = Random.Range(0, 100);
            if (!damaged)
            {
                dragMesh.enabled = true;
            }
            if (damaged)
            {
                dragMesh.enabled = false;
                damaged = false;
            }


            //Timers
            if (aggroCounter > 0)
            {
                aggroCounter -= Time.deltaTime;
            }
            attackCDCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                canAttack = true;
                canMove = true;
            }
            if (attackCounter < -5f)
            {
                if (randomNumber > 70)
                {
                    //Roar
                    dragAnim.SetInteger("AttackID", 4);
                    attackCounter = attack4Timer;
                    attackCDCounter = attackCDTimer + attack4Timer;
                    canAttack = false;
                    attackID = 4;
                    canMove = false;
                }
            }
            if (meteorRainCounter > 0)
            {
                meteorRainCounter -= Time.deltaTime;
                meteorCounter -= Time.deltaTime;
                if (meteorCounter <= 0)
                {
                    meteorCounter = meteorTimer;
                    randomNumber = Random.Range(0, 7);
                    Instantiate(meteor, meteorSpawns[randomNumber]);
                }
            }


            if (attackCounter > 0)
            {
                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    dragAnim.SetInteger("AttackID", 0);
                    if (attackID == 2)
                    {
                        dragController.Move(new Vector3(0, 0, -15f));
                    }
                    attackID = 0;
                }
            }

            if (attackID == 1)
            {
                if (attackCounter < 5f && attackCounter > 2.5)
                {
                    canMove = false;
                    hitboxes[0].enabled = true;
                }
                if (attackCounter <= 2.5)
                {
                    canMove = false;
                    hitboxes[0].enabled = false;
                    hitboxes[1].enabled = true;
                    hitboxes[2].enabled = true;
                }
            }
            if (attackID == 2)
            {
                hitboxes[1].enabled = false;
                hitboxes[2].enabled = false;
                if (attackCounter < 0.8f)
                {
                    hitboxes[0].enabled = false;
                }
            }
            if (attackID == 3)
            {
                if (attackCounter < 0.75)
                {
                    hitboxes[1].enabled = false;
                }
            }
            if (attackID == 4)
            {
                if (attackCounter < 2)
                {
                    meteorRainCounter = meteorRainTimer;
                }
            }
            if (attackID == 5)
            {
                meteorCounter -= Time.deltaTime;
                if (meteorCounter <= 0)
                {
                    meteorCounter = meteorTimer * 1.25f;
                    randomNumber = Random.Range(0, 7);
                    int randomNumber2 = Random.Range(0, 7);
                    while (randomNumber2 == randomNumber)
                    {
                        randomNumber2 = Random.Range(0, 7);
                    }
                    Instantiate(meteor, meteorSpawns[randomNumber]);
                    Instantiate(meteor, meteorSpawns[randomNumber2]);
                }
            }

            //if Not Attacking
            if (attackCounter <= 0 && aggroCounter <= 0)
            {
                ChangeTarget();
            }

            //Rotate
            if (canMove)
                targetLocation = mainTarget.transform.position;
            MoveTowardsTarget();

            if (canAttack && attackCDCounter <= 0)
            {
                //If Slam Attack

                //Melee
                if (!(targetLocation.x - transform.position.x < -4f) && !(targetLocation.x - transform.position.x > 4f))
                {
                    if (randomNumber >= 0)
                    {
                        //Slam
                        dragAnim.SetInteger("AttackID", 1);
                        attackCounter = attack1Timer;
                        attackCDCounter = attackCDTimer + attack1Timer;
                        canAttack = false;
                        canMove = true;
                        attackID = 1;
                        hitboxes[0].enabled = false;
                        hitboxes[1].enabled = true;
                        hitboxes[2].enabled = true;
                    }

                    if (randomNumber > 20)
                    {
                        //Bite
                        dragAnim.SetInteger("AttackID", 2);
                        attackCounter = attack2Timer;
                        attackCDCounter = attackCDTimer + attack2Timer;
                        canAttack = false;
                        attackID = 2;
                        canMove = false;
                        if (randomNumber <= 40)
                        {
                            dragController.Move(new Vector3(0, 0, 15f));
                        }
                        hitboxes[0].enabled = true;
                        hitboxes[1].enabled = false;
                        hitboxes[2].enabled = false;
                    }

                    if (randomNumber > 40)
                    {
                        //Sweep
                        dragAnim.SetInteger("AttackID", 3);
                        attackCounter = attack3Timer;
                        attackCDCounter = attackCDTimer + attack3Timer;
                        canAttack = false;
                        attackID = 3;
                        hitboxes[0].enabled = false;
                        hitboxes[1].enabled = true;
                        hitboxes[2].enabled = false;
                    }

                    if (randomNumber > 80)
                    {
                        //Roar
                        dragAnim.SetInteger("AttackID", 4);
                        attackCounter = attack4Timer;
                        attackCDCounter = attackCDTimer + attack4Timer;
                        canAttack = false;
                        attackID = 4;
                        canMove = false;
                        hitboxes[0].enabled = false;
                        hitboxes[1].enabled = false;
                        hitboxes[2].enabled = false;

                    }
                    if (randomNumber > 93)
                    {
                        //Heavy
                        dragAnim.SetInteger("AttackID", 5);
                        attackCounter = attack5Timer;
                        attackCDCounter = attackCDTimer + attack5Timer;
                        canAttack = false;
                        attackID = 5;
                        canMove = false;
                        hitboxes[0].enabled = false;
                        hitboxes[1].enabled = true;
                        hitboxes[2].enabled = true;
                    }
                }
            }
        }
    }

    void ChangeTarget()
    {
        if (randomNumber > 50)
        {
            mainTarget = target1;
        }
        else
        {
            mainTarget = target2;
        }
        aggroCounter = aggroTimer;
    }

    void MoveTowardsTarget()
    {
        if (targetLocation.x - transform.position.x > 3f)
        {
            dragController.Move(new Vector3(speed, -2, 0));
            dragAnim.SetInteger("MoveID", 2);
            //move right
        }
        else if (targetLocation.x - transform.position.x < -3f)
        {
            dragController.Move(new Vector3(-speed, -2, 0));
            dragAnim.SetInteger("MoveID", -2);
            //move left
        }
        else
        {
            dragController.Move(new Vector3(0, -2, 0));
            dragAnim.SetInteger("MoveID", 0);
        }

    }

    public void HurtBoss(float damage)
    {
        health -= damage;
        damaged = true;
    }
}
