using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float spawnX = 0;
    public float spawnY = 0;
    public float spawnZ = 0;

    public float speed = 3.0f;
    public float jumpForce = 2.0f;
    public Vector2 jump;
    Rigidbody2D rb2d;
    Animator animator;

    Vector2 lookDirection = new Vector2(1, 0);
    public int maxHealth = 5;
    public float timeInvincivle = 2.0f;
    public float timeDeath = 10.0f;
    public bool isGrounded;

    public int health { get { return currentHealth; }}
    int currentHealth;
    bool isInvincible = false;
    float invincibleTimer;
    int quantDiamond;
    bool isDeath = false;
    float deathTimer;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>();
        jump = new Vector2(0.0f, 2.0f);

        currentHealth = maxHealth;
        quantDiamond = 0;

    }

    void OnCollisionEnter2D()
    {
        isGrounded = true;
    }

    void OnCollisionExit2D()
    {
        isGrounded = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "TPArea")
        {
            rb2d.Sleep();
            transform.position = new Vector3(spawnX, spawnY, spawnZ);
            ChangeHealth(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");


        Vector2 move = new Vector2(horizontal, 0);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Speed", move.magnitude);
        animator.SetBool("Ground", isGrounded);
        
        //Animacion de combate sin usar:

        //animator.SetBool("Attack", false);

        //if(Input.GetKeyDown(KeyCode.E))
        //{
        //    animator.SetBool("Attack", true);
        //}

        Vector2 position = transform.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        transform.position = position;
        
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (isDeath == false && isInvincible == false)
            {
                rb2d.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

        if (isInvincible)
        {
            speed = 0.0f;
            invincibleTimer -=Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                speed = 3.5f;
            }
        }
        if (isDeath)
        {
            speed = 0;
            deathTimer -=Time.deltaTime;
            if (deathTimer < 0)
            {
                isDeath = false;
                speed = 3.5f;
                ChangeHealth(5);
            }
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            if(currentHealth + amount > 0)
            {
                animator.SetTrigger("Hit");
                isInvincible = true;
                invincibleTimer = timeInvincivle;
            }
            else
            {
                rb2d.Sleep();
                isDeath = true;
                deathTimer = timeDeath;
                animator.SetTrigger("Death");
            }
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIScript.instance.ChangeHealthBar(currentHealth);


    }

    public void ChangeDiamond(int amount)
    {
        quantDiamond = quantDiamond + amount;
        UIScript.instance.ChangeDiamondCounter(quantDiamond);
    }
}
