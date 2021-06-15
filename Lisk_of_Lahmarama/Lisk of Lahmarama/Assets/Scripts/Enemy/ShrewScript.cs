using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrewScript : MonoBehaviour
{
    public float aggroRange = 10.0f;
    public GameObject[] targets;
    public GameObject target1;
    public GameObject target2;
    public Vector3 targetLoc;
    public EnemyManager enemy;

    public float aggroRangeX = 50f;
    public float aggroRangeY = 10f;

    public bool active = false;

    public CharacterController shrewController;
    public Animator shrewAnim;

    public float speed;
    public float attackSpeed;
    public float JumpPower;
    public Vector3 moveDirection;
    public float yStore;
    public float gravityScale = -1f;

    public float attackDirection;

    public bool canAttack;
    public float attackTimer = 3f;
    public float attackCounter;
    public float aggroTimer = 1f;
    public float aggroCounter;

    public float directionChangeCDTimer = 0.3f;
    public float directionChangeCDCounter = 0f;
    public float lastMoveX;


    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].GetComponent<PlayerInput>() != null)
            {
                if (target1 == null)
                    target1 = targets[i];
                else
                    target2 = targets[i];
            }
        }
        aggroCounter = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (aggroCounter > 0)
        {
            aggroCounter -= Time.deltaTime;
        }
        if (aggroCounter <= 0)
        {
            if (Vector3.Distance(transform.position, target1.transform.position) < Vector3.Distance(transform.position, target2.transform.position))
            {
                targetLoc = target1.transform.position;
                aggroCounter = aggroTimer;
            }
            else
            {
                targetLoc = target2.transform.position;
                aggroCounter = aggroTimer;
            }
        }
        if (WithinRange())
        {
            active = true;
        }
        else
        {
            active = false;
        }
        if (active)
        {
            if (shrewController.isGrounded)
            {
                moveDirection.y = -3.5f;
            }
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0f)
            {
                if (attackCounter <= -0.5f)
                {
                    if (attackCounter <= -4f)
                    {
                        canAttack = true;
                    }
                    shrewAnim.SetBool("Attack", false);
                    //Movement
                    yStore = moveDirection.y;
                    if (directionChangeCDCounter > 0)
                    {
                        directionChangeCDCounter -= Time.deltaTime;
                    }

                    moveDirection = new Vector3((targetLoc.x - transform.position.x), 0, 0);
                    moveDirection = moveDirection.normalized * speed;
                    if (lastMoveX != moveDirection.x && directionChangeCDCounter > 0)
                    {
                        moveDirection.x = lastMoveX;
                    }
                    else
                    {
                        directionChangeCDCounter = directionChangeCDTimer;
                    }
                    lastMoveX = moveDirection.x;
                    moveDirection.y = yStore;
                    if (!shrewController.isGrounded)
                    {
                        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
                    }
                    //ENEMY FACING ----------------------------------------------------------------------

                    Vector3 facingDirection = new Vector3(0, 0, -moveDirection.x);
                    if (facingDirection != Vector3.zero)
                    {
                        transform.forward = facingDirection;
                    }

                    //Jump
                    /*if ((targetLoc.y - transform.position.y > 2f) && shrewController.isGrounded)
                    {
                        print(targetLoc.y - transform.position.y);
                        print(transform.position.y);
                        moveDirection.y = JumpPower;
                    }*/


                    //Attack
                    if (shrewController.isGrounded && canAttack)
                    {
                        //attack
                        attackCounter = attackTimer;
                        attackDirection = targetLoc.x - transform.position.x;
                        shrewAnim.SetBool("Attack", true);
                        canAttack = false;
                    }
                    if (enemy.EnemyAICommand != 1)
                    {
                        shrewController.Move(moveDirection);
                    }
                }
            }
            else
            {
                yStore = moveDirection.y;
                moveDirection = new Vector3(attackDirection, 0, 0);
                moveDirection = moveDirection.normalized * attackSpeed;
                moveDirection.y = yStore;
                if (!shrewController.isGrounded)
                {
                    moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
                }
                if (enemy.EnemyAICommand != 1)
                {
                    shrewController.Move(moveDirection);
                }
            }
        }

        if (shrewController.transform.position.z != 27)
        {
            if (shrewController.transform.position.z > 27)
                shrewController.Move(new Vector3(0, -0.01f, -0.01f));
            if (shrewController.transform.position.z < 27)
                shrewController.Move(new Vector3(0, -0.01f, 0.01f));
        }
        enemy.EnemyAICommand = 0;
    }

    bool WithinRange()
    {
        if ((targetLoc.x - transform.position.x < aggroRangeX && targetLoc.x - transform.position.x > 0) | (targetLoc.x - transform.position.x > -aggroRangeX && targetLoc.x - transform.position.x < 0))
        {
            if ((targetLoc.y - transform.position.y < aggroRangeY && targetLoc.y - transform.position.y > 0) | (targetLoc.y - transform.position.y > -aggroRangeY && targetLoc.y - transform.position.y < 0))
            {
                return true;
            }
        }

        return false;
    }
}
