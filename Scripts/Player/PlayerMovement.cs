using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public InputAction PlayerControls;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float healLimit;
    [SerializeField] private float potionLimit;
    private int healsUsed;
    private float potionsUsed;
    private Animator anim;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float gravityForce;
    private float blockCooldown;
    private float wallJumpSideForce;
    private float wallJumpUpForce;
    private float horizontalInput;
    private bool isAttacking;
    private int limitOneAttack;
    private float frontOrNah;

    private KeybindSettings obj;
    private string leftBind;
    private string rightBind;
    private string jumpBind;
    private string fireballBind;
    private string healBind;
    private string manaRegainBind;
    private string blockBind;
    SpriteRenderer spriteRend;

    private void OnEnable()
    {
        //PlayerControls.Enable();
    }

    private void OnDisable()
    {
        //PlayerControls.Disable();
    }
    private void Awake()
    {
        //Grab references for rigidBody and animator from object
        body = GetComponent<Rigidbody2D>(); // used to get component of an object
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        gravityForce = 5; // used for global gravityForce
        wallJumpSideForce = 3; // used for global wallJumpForce
        wallJumpUpForce = 6;
        isAttacking = false;
        leftBind = KeybindSettings.lefter;
        fireballBind = KeybindSettings.firer;
        rightBind = KeybindSettings.righter;
        jumpBind = KeybindSettings.jumper;
        healBind = KeybindSettings.healer;
        manaRegainBind = KeybindSettings.magicer;
        blockBind = KeybindSettings.blocked;
        healsUsed = 0;
        spriteRend = GetComponent<SpriteRenderer>();
        //obj = new KeybindSettings();
    }
    // Start is called before the first frame update
    void Start()
    {
        /*if(leftBind == null || rightBind == null || jumpBind == null || fireballBind == null || healBind == null)
        {
            leftBind = "A";
            rightBind = "D";
            jumpBind = "W";
            fireballBind = "Q";
            healBind = "R";
            manaRegainBind = "E";
            blockBind = "space";
        }*/
        //print("this is the end");
        //jumpBind = obj.getKey("jump");
    }

    private void FixedUpdate()
    {
        
    }

    public void HealPlayer(float _Amount)
    {
        if(healsUsed < healLimit)
        {
            GetComponent<Health>().AddHealth(_Amount);
        }      
    }
    public void RegainMana(float _Amount) {
        if(potionsUsed < potionLimit)
        {
            GetComponent<Magic>().AddMana(_Amount);
        }      
    }
    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKeyDown(blockBind.ToLower()))
        {
            anim.SetTrigger("block");
            GetComponent<Health>().Invulnerable();
        }

        if (Input.GetKeyDown(manaRegainBind.ToLower()))
        {
            spriteRend.color = Color.blue;
            potionsUsed += 1;
            RegainMana(1.5f);
            spriteRend.color = Color.white;
        }

        if (Input.GetKeyDown(healBind.ToLower()))
        {
            healsUsed += 1;
            HealPlayer(0.5f);
        }
        /*leftBind = GetComponent<KeybindSettings>().leftKey;
        rightBind = GetComponent<KeybindSettings>().rightKey;*/
        //attack on click
        /*if (!onWall())
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                isAttacking = true;
                Attacking();
            }
            else
            {
                isAttacking = false;
                Attacking();
            }
        }*/

        //Put every key if statements in here



        //move character left or right
        //horizontalInput = Input.GetAxisRaw("Horizontal"); // set keys for left and right

        //Flip Character sprite in direction they walk
        frontOrNah = 0.0f;
        /*if(horizontalInput > 0.01f)*/if(Input.GetKey(rightBind.ToLower()))
        {
           // print("right key pressed");
            horizontalInput = 1.0f;
            transform.localScale = new Vector3(3.8f, 4, 1);
            frontOrNah = 1;
        }
        /*else if(horizontalInput < -0.01f)*/if(Input.GetKey(leftBind.ToLower()))
        {
            //print("left key pressed");
            horizontalInput = -1.0f;
            transform.localScale = new Vector3(-3.8f, 4, 1);
            frontOrNah = -1;
        }
        else
        {
            horizontalInput = 0;
        }

        //set animator parameters
        anim.SetBool("Run", frontOrNah != 0);
        //anim.SetBool("Run", Input.GetKey(rightBind.ToLower()) || Input.GetKey(leftBind.ToLower()));
        anim.SetBool("Grounded", isGrounded());

        //wall jump code below
        if(wallJumpCooldown > 0.2f)
        {
            //move character left or right
            body.velocity = new Vector2(frontOrNah * speed, body.velocity.y);
            
            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                body.gravityScale = gravityForce;
            }

            if (Input.GetKey(jumpBind.ToLower()))
            {
                Jump();
            }

            //let charactor jump if they are touching ground
        }
        else
        {
            wallJumpCooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            anim.SetTrigger("Jump");
        }
       else if(onWall() && !isGrounded())
        {
            wallJumpCooldown = 0;
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            /*if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
            }
            else {
                wallJumpCooldown = 0;
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * jumpForce, 6);
                //body.velocity = new Vector3(-Mathf.Sign(transform.localScale.x) * wallJumpSideForce, transform.localScale.y, transform.localScale.z);
            }*/
            //wallJumpCooldown = 0;
        }
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    public bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    /*private void Attacking()
    {
        anim.SetBool("Attack1", isAttacking);
    }*/

    public bool canAttack()
    {
        return !onWall();
    }
}
