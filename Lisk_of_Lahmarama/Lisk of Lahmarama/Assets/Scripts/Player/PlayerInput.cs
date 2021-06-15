using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Range(1,2)]
    public int playerNumber;

    public int weaponType = 1;

    public GameObject equippedWeapon;
    public GameObject specialSpell;
    public PlayerAttack other;
    public PlayerAttackHitbox attackHitbox;

    [SerializeField]
    private CharacterController playerController;
    [SerializeField]
    private Animator playerAnim;
    [SerializeField]
    private List<Renderer> playerRenderers;
    [SerializeField]
    public List<Collider> playerHitboxes;

    private PlayerControls controls;
    public bool recenterZ = true;

    // Public Stats
    public int level = 1;
    public float healthMAX = 100;
    public float health = 100;
    public float manaMAX = 100;
    public float mana = 100;
    public float atk = 10; // ATTACK DAMAGE
    public float mag = 10; // SPECIAL DAMAGE
    public float def = 10; // DAMAGE REDUCTION
    public float dex = 10; // ATTACK SPEED
    public float speed = 10; // MOVE SPEED + DASH DISTANCE
    public float jump = 10; // JUMP HEIGHT
    public float manaRegenSpeed = 10;

    // Base Values
    [SerializeField]
    private float moveSpeed = 18;
    [SerializeField]
    private float jumpForce = 65f;
    [SerializeField]
    private float dashForce = 15f;

    public float baseWeight = -3.4335f;

    //Movement Variables
    public bool onGround;
    [SerializeField]
    public Vector3 moveDirection;
    [SerializeField]
    private Vector2 axisDirection;
    private float horizDirection;
    [SerializeField]
    private float gravityScale = 0.35f;
    private float yStore;
    [SerializeField]
    private float currentFacing;

    public float knockbackForce = 10;

    //Controls Variables
    public bool xPress; // E on keyboard
    private bool xInput;
    public float xHold;

    private bool aPress; // Space on keyboard
    private bool aInput;
    public float aHold;

    private bool yPress; // Q on keyboard
    private bool yInput;
    public float yHold;

    private bool ltPress; //lShift on keyboard
    private bool ltInput;
    public float ltHold;

    //Action Variables
    public int heldDirection;
    public bool crouching;
    public bool canAct = true;

    public bool canAttack = true;
    private bool dashing;
    private bool attacking;
    private bool damaged;

    public bool chargeAttack;
    public float chargeInputTimer;

    public Transform projectileSpawnLocation;
    public float specialInputTimer;

    public int airDash;
    public int airDashMax = 1;
    public int airAttack;
    public int airSpecial;
    public int attackType;

    public bool specialFired;

    //Action Timers;
    public float jumpTimer;
    public bool resetJumpPress;
    public bool jumped;

    public float dashTimer = 0.4f;
    [SerializeField]
    private float dashCounter = 0f;

    public float attack1Timer = 0.3f;
    public float attack2Timer = 0.3f;
    public float attackUPTimer = 0.3f;
    public float attackCROUCHTimer = 0.3f;
    public float attackCHARGETimer = 0.3f;
    public float attackAIRTimer = 0.3f;
    private float attackCounter = 0f;

    public float specialTimer = 0.2f;
    public bool heldSpecial;

    public float respawnTime = 2f;
    private float deathTimer = 0f;

    public float crouchFallWindow = 0.5f;
    public List<float> crouches = new List<float>();
    private float prevAxisDirection;

    //Damage Variables
    public float staggerTimer = 0.3f;
    public float staggerCounter;

    public bool invincible = false;
    public float invincibilityTimer = 0.7f;
    public float invincibilityCounter;

    //Action Cooldowns;
    public float dashCD = 0.3f;
    [SerializeField]
    private float dashCDCounter = 0f;
    public float attackCD = 0.2f;
    private float attackCDCounter = 0f;

    public IDictionary<string, float> statDict;

    //Weapon Dependant values

    public List<GameObject> fullPlayer;
    // 0 = sword
    // 1 = greatsword

    //Animator
    public List<Animator> weaponAnimator;

    //Meshes
    public List<Renderer> swordRenderers;
    public List<Renderer> greatswordRenderers;

    //Attack CDs
    public List<float> swordAttackTimers;
    public List<float> greatswordAttackTimers;

    //Attack hitboxes
    public List<PlayerAttackHitbox> weaponHitboxes;

    // Start is called before the first frame update

    void Awake()
    {

        SwitchWeapon(0);

        statDict = new Dictionary<string, float>()
        {
            {"healthMAX", healthMAX },
            {"manaMAX", manaMAX },
            {"atk", atk },
            {"mag", mag },
            {"def", def },
            {"dex", dex },
            {"speed", speed },
            {"jump", jump },
            {"manaRegenSpeed", manaRegenSpeed }
        };

        controls = new PlayerControls();
        canAct = true;
        canAttack = true;
        playerHitboxes[1].enabled = false;
        if (playerNumber == 1)
        {
            //Movement Controls
            controls.Gameplay.Move.performed += ctx => axisDirection = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => axisDirection = Vector2.zero;

            //Movement Controls Keyboard
            controls.Gameplay.KYBDMove.performed += ctx => axisDirection = ctx.ReadValue<Vector2>();
            controls.Gameplay.KYBDMove.canceled += ctx => axisDirection = Vector2.zero;

            //Button Controls

            //X
            controls.Gameplay.WButton.performed += ctx => xPress = true;
            controls.Gameplay.WButton.canceled += ctx => xPress = false;
            controls.Gameplay.WButton.performed += ctx => xInput = true;
            controls.Gameplay.WButton.canceled += ctx => xInput = false;

            //A
            controls.Gameplay.SButton.performed += ctx => aPress = true;
            controls.Gameplay.SButton.canceled += ctx => aPress = false;
            controls.Gameplay.SButton.performed += ctx => aInput = true;
            controls.Gameplay.SButton.canceled += ctx => aInput = false;

            //Y
            controls.Gameplay.NButton.performed += ctx => yPress = true;
            controls.Gameplay.NButton.canceled += ctx => yPress = false;
            controls.Gameplay.NButton.performed += ctx => yInput = true;
            controls.Gameplay.NButton.canceled += ctx => yInput = false;

            //LT
            controls.Gameplay.LT.performed += ctx => ltInput = true;
            controls.Gameplay.LT.canceled += ctx => ltInput = false;
        }
        else if (playerNumber == 2)
        {
            //Movement Controls
            controls.Gameplay.Move.performed += ctx => axisDirection = ctx.ReadValue<Vector2>();
            controls.Gameplay.Move.canceled += ctx => axisDirection = Vector2.zero;

            //Movement Controls Keyboard
            controls.Gameplay.KYBDMoveP2.performed += ctx => axisDirection = ctx.ReadValue<Vector2>();
            controls.Gameplay.KYBDMoveP2.canceled += ctx => axisDirection = Vector2.zero;

            //Button Controls

            //X
            controls.Gameplay.WButtonP2.performed += ctx => xPress = true;
            controls.Gameplay.WButtonP2.canceled += ctx => xPress = false;
            controls.Gameplay.WButtonP2.performed += ctx => xInput = true;
            controls.Gameplay.WButtonP2.canceled += ctx => xInput = false;

            //A
            controls.Gameplay.SButtonP2.performed += ctx => aPress = true;
            controls.Gameplay.SButtonP2.canceled += ctx => aPress = false;
            controls.Gameplay.SButtonP2.performed += ctx => aInput = true;
            controls.Gameplay.SButtonP2.canceled += ctx => aInput = false;

            //Y
            controls.Gameplay.NButtonP2.performed += ctx => yPress = true;
            controls.Gameplay.NButtonP2.canceled += ctx => yPress = false;
            controls.Gameplay.NButtonP2.performed += ctx => yInput = true;
            controls.Gameplay.NButtonP2.canceled += ctx => yInput = false;

            //LT
            controls.Gameplay.LTP2.performed += ctx => ltInput = true;
            controls.Gameplay.LTP2.canceled += ctx => ltInput = false;
        }
        
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ManageInputs();

        healthMAX = statDict["healthMAX"];
        manaMAX = statDict["manaMAX"];
        atk = statDict["atk"];
        mag = statDict["mag"];
        def = statDict["def"];
        dex = statDict["dex"];
        speed = statDict["speed"];
        jump = statDict["jump"];
        manaRegenSpeed = statDict["manaRegenSpeed"];
    }
    
    void FixedUpdate()
    {
        if (resetJumpPress)
        {
            resetJumpPress = false;
        }
        List<float> toRemove = new List<float>();
        for (int i = 0; i < crouches.Count; i++)
        {
            crouches[i] -= Time.deltaTime;
            if (crouches[i] <= 0)
            {
                toRemove.Add(crouches[i]);
            }
        }

        foreach (float f in toRemove)
        {
            crouches.Remove(f);
        }

        if (weaponType == 1 && attack1Timer == 0.5f)
        {
            SwitchWeapon(1);
        }
        if (weaponType == 0 && attack1Timer != 0.5f)
        {
            SwitchWeapon(0);
        }

        if (invincible)
        {
            invincibilityCounter -= Time.deltaTime;
            if (invincibilityCounter <= 0)
            {
                foreach (Renderer r in playerRenderers)
                {
                    r.enabled = true;
                }
                invincible = false;
            }
            else
            {
                foreach (Renderer r in playerRenderers)
                {
                    r.enabled = !r.enabled;
                }
            }
        }
        if (!attacking)
        {
            attackHitbox.DisableHitbox();
        }
        
        mana += Time.deltaTime * manaRegenSpeed / 10;
        if (mana > 100)
        {
            mana = 100;
        }
        

        //GROUNDED CHECK ----------------------------------------------------------------------
        if (playerController.isGrounded)
        {
            if (onGround == false)
            {
                moveDirection.y = baseWeight;
            }
            onGround = true;
            airDash = airDashMax;
            airAttack = 1;
            airSpecial = 1;
            playerAnim.SetBool("Grounded", true);
        }
        else
        {
            onGround = false;
            playerAnim.SetBool("Grounded", false);
        }

        //JUMP HOLD
        if (jumped)
        {
            if (aHold > 0f && jumpTimer <= 0.14f)
            {
                moveDirection.y = jumpForce * jump / 10 + (jumpTimer * 120);
                jumpTimer += Time.deltaTime;
            }
            else
            {
                jumped = false;
                jumpTimer = 0;
            }
            if (onGround)
            {
                jumped = false;
                jumpTimer = 0;
            }
        }

        //PLAYER STATE
        if (!canAct)
        {
            // IF DEAD ==================================================================
            if (health <= 0)
            {
                if (deathTimer >= 0 )
                {
                    deathTimer -= Time.deltaTime;
                    playerHitboxes[0].enabled = false;
                    playerHitboxes[1].enabled = false;
                    for (int i = 0; i < playerRenderers.Count; i++)
                    {
                        playerRenderers[i].enabled = false;
                    }
                }
                else
                {
                    canAct = true;
                    health = healthMAX;
                    playerHitboxes[0].enabled = true;
                    playerHitboxes[1].enabled = true;
                    for (int i = 0; i < playerRenderers.Count; i++)
                    {
                        playerRenderers[i].enabled = true;
                    }
                }
            }
            // IF DAMAGED ==================================================================
            else if (damaged) 
            {
                staggerCounter -= Time.deltaTime;
                if (staggerCounter <= 0)
                {
                    canAct = true;
                    damaged = false;
                }

                yStore = moveDirection.y;
                moveDirection = new Vector3(horizDirection, 0, 0);
                moveDirection = moveDirection * moveSpeed * speed / 10f;
                moveDirection.y = yStore;
                if (!onGround)
                {
                    moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
                }
                playerController.Move(moveDirection * Time.deltaTime);
            }
            // IF DASHING ==================================================================
            else if (dashing)
            {
                dashCounter -= Time.deltaTime;
                if (dashCounter <= 0)
                {
                    canAct = true;
                    dashing = false;
                }
                else
                {
                    yStore = moveDirection.y;
                    moveDirection.y = 0;
                    playerController.Move(moveDirection * Time.deltaTime);
                    moveDirection.y = yStore;
                    dashCDCounter = dashCD;
                }
            }
            // IF ATTACKING ==================================================================
            else if (attacking)
            {
                //equippedWeapon);
                //attackCheck();
                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    canAct = true;
                    attacking = false;
                }

                //Do this per Attack Type
                AttackCheck();

                //SPECIAL ATTACK
                if (attackType == 9 && attackCounter < specialTimer / 4)
                {
                    if (!specialFired)
                    {
                        Instantiate(specialSpell, projectileSpawnLocation);
                        specialFired = true;
                    }
                    if (yPress)
                    {
                        attacking = false;
                        playerAnim.SetInteger("ActionID", 0);
                        attackCounter = 0;
                        Dash();
                        attackType = 0;
                    }
                }
                if (attackType == 9 && !onGround)
                {
                    yStore = moveDirection.y;
                    moveDirection = new Vector3(horizDirection, 0, 0);
                    moveDirection = moveDirection * moveSpeed * speed / 10f;
                    moveDirection.y = yStore;
                    moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
                    playerController.Move(moveDirection * Time.deltaTime);
                    if (onGround)
                    {
                        attackType = 0;
                        attackCounter = 0;
                        playerAnim.SetInteger("ActionID", 0);
                        canAct = true;
                        attacking = false;
                    }
                }
                //Attack Data Block
            }
        }

        // MAIN GAMEPLAY LOOP
        else
        {
            if (health <= 0)
            {
                canAct = false;
                deathTimer = respawnTime;
                playerHitboxes[0].enabled = false;
                playerHitboxes[1].enabled = false;
                for (int i = 0; i < playerRenderers.Count; i++)
                {
                    playerRenderers[i].enabled = false;
                }
            }
            else
            {
                crouching = false;
                playerAnim.SetBool("Crouch", false);
                playerHitboxes[0].enabled = true;
                playerHitboxes[1].enabled = false;
                playerAnim.SetInteger("Dash", 0);
                playerAnim.SetInteger("ActionID", 0);
                playerAnim.SetBool("Damaged", false);
                if (dashCDCounter > 0)
                {
                    dashCDCounter -= Time.deltaTime;
                }
                if (attackCDCounter >= 0)
                {
                    attackCDCounter -= Time.deltaTime;
                    ltPress = false;
                }

                //CHARGE ATTACK CODE
                if (xHold > 0.8f)
                {
                    chargeAttack = true;
                    chargeInputTimer = 0;
                }
                if (xHold <= 0 && chargeAttack)
                {
                    chargeInputTimer += Time.deltaTime;
                    if (chargeInputTimer > 0.2f)
                    {
                        chargeAttack = false;
                        chargeInputTimer = 0;
                    }
                }

                //SPECIAL ATTACK CHARGE CODE
                if (ltPress)
                {
                    specialInputTimer += Time.deltaTime;
                    if (specialInputTimer > 0.2f)
                    {
                        ltPress = false;
                        specialInputTimer = 0;
                        heldSpecial = false;
                    }
                }


                //MOVE BLOCK ----------------------------------------------------------------------
                yStore = moveDirection.y;
                moveDirection = new Vector3(horizDirection, 0, 0);
                moveDirection = moveDirection * moveSpeed * speed / 10f;
                moveDirection.y = yStore;
                if (!onGround)
                {
                    moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
                }
                //PLAYER FACING ----------------------------------------------------------------------

                //Player is Moving
                Vector3 facingDirection = new Vector3(moveDirection.x, 0, 0);
                if (facingDirection != Vector3.zero)
                {
                    transform.forward = facingDirection;
                    playerAnim.SetBool("Run", true);
                    currentFacing = facingDirection.x;
                }
                //Player is Stationary
                else
                {
                    playerAnim.SetBool("Run", false);
                }

                //ACTIONS ----------------------------------------------------------------------

                //Dash Action
                if (yPress && dashCDCounter <= 0 && airDash > 0)
                {
                    Dash();
                }

                //Grounded Actions
                else if (onGround)
                {
                    //JUMP
                    if (aPress)
                    {
                        if (heldDirection != 2)
                        {
                            moveDirection.y = jumpForce * jump / 10;
                            jumped = true;
                        }
                        resetJumpPress = true;
                        
                    }
                    //CROUCH
                    else if (heldDirection == 2)
                    {
                        crouching = true;
                        playerAnim.SetBool("Crouch", true);
                        playerHitboxes[0].enabled = false;
                        playerHitboxes[1].enabled = true;

                        if (prevAxisDirection >= 0)
                        {
                            crouches.Add(crouchFallWindow);
                        }

                        if (xPress && canAttack && attackCDCounter < 0)
                        {
                            attackType = 4;
                            Attack(attackType);
                        }
                        else if (canAttack && ltPress && attackCDCounter < 0)
                        {
                            crouching = false;
                            playerAnim.SetBool("Crouch", false);
                            playerHitboxes[0].enabled = true;
                            playerHitboxes[1].enabled = false;
                            attackType = 9;
                            Attack(attackType);
                        }
                    }
                    else if (xPress && canAttack && attackCDCounter < 0)
                    {

                        if (heldDirection == 0)
                        {
                            attackType = 3;
                            Attack(attackType);
                        }
                        else
                        {
                            attackType = 1;
                            Attack(attackType);
                        }
                    }
                    else if (canAttack && xHold <= 0 && chargeAttack)
                    {
                        chargeAttack = false;
                        attackType = 5;
                        Attack(attackType);
                    }
                    else if (canAttack && ltPress && attackCDCounter < 0)
                    {
                        attackType = 9;
                        Attack(attackType);
                    }

                }
                //Airborne Actions
                else
                {
                    if (xPress && canAttack && airAttack > 0)
                    {
                        airAttack -= 1;
                        attackType = 6;
                        Attack(attackType);
                    }
                    else if (canAttack && ltPress && attackCDCounter < 0)
                    {
                        attackType = 9;
                        Attack(attackType);
                    }
                }

                //MOVE ACTION ----------------------------------------------------------------------
                playerController.Move(moveDirection * Time.deltaTime);
            }
            
        }
        //IF WE NEED TO KEEP RECENTERED
        if (playerController.transform.position.z != 27 && recenterZ && !dashing)
        {
            if (playerController.transform.position.z > 27)
                playerController.Move(new Vector3(0, -0.01f, -0.01f));
            if (playerController.transform.position.z < 27)
                playerController.Move(new Vector3(0, -0.01f, 0.01f));
        }

        prevAxisDirection = axisDirection.y;
    }

    void Attack(int attackID)
    {
        attackHitbox.EnableHitbox();
        attackCDCounter = attackCD;
        if (attackID == 1)
        {
            canAct = false;
            attacking = true;
            attackCounter = attack1Timer;
            playerAnim.SetInteger("ActionID", 1);
            playerAnim.SetBool("Run", false);
        }
        if (attackID == 2)
        {
            canAct = false;
            attacking = true;
            attackCounter = attack2Timer;
            playerAnim.SetInteger("ActionID", 2);
            playerAnim.SetBool("Run", false);
        }
        if (attackID == 3)
        {
            canAct = false;
            attacking = true;
            attackCounter = attackUPTimer;
            playerAnim.SetInteger("ActionID", 3);
            playerAnim.SetBool("Run", false);
        }
        if (attackID == 4)
        {
            canAct = false;
            attacking = true;
            attackCounter = attackCROUCHTimer;
            playerAnim.SetInteger("ActionID", 4);
            playerAnim.SetBool("Run", false);
        }
        if (attackID == 5)
        {
            canAct = false;
            attacking = true;
            attackCounter = attackCHARGETimer;
            playerAnim.SetInteger("ActionID", 5);
            playerAnim.SetBool("Run", false);
        }
        if (attackID == 6)
        {
            canAct = false;
            attacking = true;
            attackCounter = attackAIRTimer;
            playerAnim.SetInteger("ActionID", 6);
        }
        //SPECIAL
        if (attackID == 9)
        {
            //MAKE MANA COST RELATIVE TO SPELL
            ltPress = false;
            if (mana >= 30)
            {
                mana -= 30;
                if (heldSpecial && mana >= 60)
                {
                    mana -= 30;
                }
                canAct = false;
                attacking = true;
                attackCounter = specialTimer;
                specialFired = false;
                playerAnim.SetInteger("ActionID", 9);
            }
            else
            {
                //OOM
            }
            heldSpecial = false;
        }
    }

    void AttackCheck()
    {
        //Attack 1
        if (attackType == 1 && attackCounter < attack1Timer / 3)
        {
            if (xPress && canAttack)
            {
                attackType = 2;
                Attack(attackType);
            }
            else if (yPress)
            {
                attacking = false;
                playerAnim.SetInteger("ActionID", 0);
                attackCounter = 0;
                attackType = 0;
                Dash();
            }
            else if (ltPress)
            {
                attackType = 9;
                Attack(attackType);
            }
        }
        //Attack 2
        if (attackType == 2 && attackCounter < attack2Timer / 3)
        {
            if (yPress)
            {
                attacking = false;
                playerAnim.SetInteger("ActionID", 0);
                attackCounter = 0;
                attackType = 0;
                Dash();
            }
            else if (ltPress)
            {
                attackType = 9;
                Attack(attackType);
            }
        }
        //Attack Crouch
        if (attackType == 3 && attackCounter < attackCROUCHTimer / 3)
        {
            if (yPress)
            {
                attacking = false;
                playerAnim.SetInteger("ActionID", 0);
                attackCounter = 0;
                attackType = 0;
                Dash();
            }
            else if (ltPress)
            {
                attackType = 9;
                Attack(attackType);
            }
        }
        //Attack Overhead
        if (attackType == 4 && attackCounter < attackUPTimer / 3)
        {
            if (yPress)
            {
                attacking = false;
                playerAnim.SetInteger("ActionID", 0);
                attackCounter = 0;
                attackType = 0;
                Dash();
            }
            else if (ltPress)
            {
                attackType = 9;
                Attack(attackType);
            }
        }
        //Attack Charge
        if (attackType == 5 && attackCounter < attackCHARGETimer / 3)
        {
            if (yPress)
            {
                attacking = false;
                playerAnim.SetInteger("ActionID", 0);
                attackCounter = 0;
                attackType = 0;
                Dash();
            }
            else if (ltPress)
            {
                attackType = 9;
                Attack(attackType);
            }
        }
        if (attackType == 5)
        {

            yStore = moveDirection.y;
            moveDirection = new Vector3(horizDirection, 0, 0);
            if (currentFacing > 0)
            {
                moveDirection.x = dashForce * speed / 10 / 15;
            }
            else
            {
                moveDirection.x = -dashForce * speed / 10 / 15;
            }

            if (heldDirection == 1)
            {
                moveDirection.x = dashForce * speed / 10 / 15;
            }
            if (heldDirection == 3)
            {
                moveDirection.x = -dashForce * speed / 10 / 15;
            }
            if (attackCounter > attackCHARGETimer / 2)
            {
                moveDirection = moveDirection * moveSpeed * speed / 10f;
                moveDirection.y = yStore;
                moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
                playerController.Move(moveDirection * Time.deltaTime);
            }
        }
        //Attack Air
        if (attackType == 6 && attackCounter < attackAIRTimer / 3)
        {
            if (yPress && airDash > 0)
            {
                attacking = false;
                playerAnim.SetInteger("ActionID", 0);
                attackCounter = 0;
                Dash();
                attackType = 0;
            }
            else if (ltPress)
            {
                attackType = 9;
                Attack(attackType);
            }
        }
        if (attackType == 6)
        {
            yStore = moveDirection.y;
            moveDirection = new Vector3(horizDirection, 0, 0);
            moveDirection = moveDirection * moveSpeed * speed / 10f;
            moveDirection.y = yStore;
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
            playerController.Move(moveDirection * Time.deltaTime);
            if (onGround)
            {
                attackType = 0;
                attackCounter = 0;
                playerAnim.SetInteger("ActionID", 0);
                canAct = true;
                attacking = false;
            }
        }
    }

    void Dash()
    {
        playerAnim.SetBool("Crouch", false);
        playerHitboxes[0].enabled = true;
        playerHitboxes[1].enabled = false;
        airAttack = 1;
        airSpecial = 1;
        airDash -= 1;
        if (currentFacing > 0)
        {
            moveDirection.x = -dashForce * speed / 10;
        }
        else
        {
            moveDirection.x = dashForce * speed / 10;
        }

        if (heldDirection == 1)
        {
            moveDirection.x = dashForce * speed / 10;
        }
        if (heldDirection == 3)
        {
            moveDirection.x = -dashForce * speed / 10;
        }
        if ((currentFacing > 0 && moveDirection.x < 0) | (currentFacing < 0 && moveDirection.x > 0))
        {
            playerAnim.SetBool("Run", false);
            playerAnim.SetInteger("Dash", 1);
        }
        else
        {
            playerAnim.SetBool("Run", false);
            playerAnim.SetInteger("Dash", 2);
        }
        moveDirection.y = 0;
        canAct = false;
        dashing = true;
        dashCounter = dashTimer;
    }

    void ManageInputs()
    {
        //Move Direction Region
        #region
        if (axisDirection.x == 0 && axisDirection.y == 0)
        {
            heldDirection = -1;
            horizDirection = 0;
        }
        else if (axisDirection.y > -0.6 && axisDirection.y < 0.6)
        {
            horizDirection = axisDirection.x;

            //Holding RIGHT
            if (horizDirection > 0)
            {
                heldDirection = 1;
            }
            //Holding LEFT
            else
            {
                heldDirection = 3;
            }
        }
        else
        {
            if (onGround && !aPress)
            {
                horizDirection = 0;
            }
            //Holding UP
            if (axisDirection.y > 0.1)
            {
                heldDirection = 0;
            }
            //Holding DOWN
            else if (axisDirection.y < -0.1)
            {
                heldDirection = 2;
            }
        }
        //-.6 & .6
        #endregion
        //Button Holds
        if (xInput) { xHold += Time.deltaTime; if (xHold > 0.075) xPress = false; if (xHold > 10) xHold = 11; } else { if (xHold > 0) xHold = 0; }
        if (ltInput) { ltHold += Time.deltaTime; if (ltHold > 10) ltHold = 11; } else { if (ltHold > 0) { if (ltHold > 0.8f) heldSpecial = true; ltPress = true; ltHold = 0; } }
        if (aInput) { aHold += Time.deltaTime; if (aHold > 0.075) aPress = false; if (aHold > 10) aHold = 11; } else { if (aHold > 0) aHold = 0; }
        if (yInput) { yHold += Time.deltaTime; if (yHold > 0.075) yPress = false; if (yHold > 10) yHold = 11; } else { if (yHold > 0) yHold = 0; }
    }
    public void hurtPlayer(float damage)
    {
        if (!invincible) health -= damage;

        if (health <= 0)
        {
            canAct = false;
            deathTimer = respawnTime;
            playerHitboxes[0].enabled = false;
            playerHitboxes[1].enabled = false;
            for (int i = 0; i < playerRenderers.Count; i++)
            {
                playerRenderers[i].enabled = false;
            }
        }
    }
    public void KnockBack(Vector3 direction)
    {
        if (!invincible)
        {
            direction = new Vector3(direction.x, 0, 0);
            playerAnim.SetBool("Damaged", true);
            damaged = true;
            invincible = true;
            invincibilityCounter = invincibilityTimer;
            canAct = false;
            staggerCounter = staggerTimer;
            moveDirection = direction * knockbackForce;
            playerController.Move(moveDirection * Time.deltaTime);
        }
    }

    public void statChange(string stat, float num)
    {
        statDict[stat] += num;
    }

    public void allStatChange(float num)
    {
        statDict["healthMAX"] += num;
        statDict["manaMAX"] += num;
        statDict["atk"] += num;
        statDict["mag"] += num;
        statDict["def"] += num;
        statDict["dex"] += num;
        statDict["speed"] += num;
        statDict["jump"] += num;
        statDict["manaRegenSpeed"] += num;
    }

    public void SwitchWeapon(int WeaponID)
    {
        foreach (GameObject g in fullPlayer)
        {
            g.SetActive(false);
        }
        fullPlayer[WeaponID].SetActive(true);

        playerAnim = weaponAnimator[WeaponID];

        if (WeaponID == 0)
        {
            playerRenderers[0] = swordRenderers[0];
            playerRenderers[1] = swordRenderers[1];
            playerRenderers[2] = swordRenderers[2];
            playerRenderers[3] = swordRenderers[3];
            playerRenderers[4] = swordRenderers[4];
        }
        if (WeaponID == 1)
        {
            playerRenderers[0] = greatswordRenderers[0];
            playerRenderers[1] = greatswordRenderers[1];
            playerRenderers[2] = greatswordRenderers[2];
            playerRenderers[3] = greatswordRenderers[3];
            playerRenderers[4] = greatswordRenderers[4];
        }


        //Attack Timers
        if (WeaponID == 0)
        {
            attack1Timer = swordAttackTimers[0];
            attack2Timer = swordAttackTimers[1];
            attackUPTimer = swordAttackTimers[2];
            attackCROUCHTimer = swordAttackTimers[3];
            attackCHARGETimer = swordAttackTimers[4];
            attackAIRTimer = swordAttackTimers[5];
        }
        if (WeaponID == 1)
        {
            attack1Timer = greatswordAttackTimers[0];
            attack2Timer = greatswordAttackTimers[1];
            attackUPTimer = greatswordAttackTimers[2];
            attackCROUCHTimer = greatswordAttackTimers[3];
            attackCHARGETimer = greatswordAttackTimers[4];
            attackAIRTimer = greatswordAttackTimers[5];
        }
        attackHitbox = weaponHitboxes[WeaponID];
    }

    public float hurtPlayerPercentage(float percent)
    {
        float healthLoss = healthMAX * percent;
        hurtPlayer(healthLoss);
        return healthLoss;
    }

}
