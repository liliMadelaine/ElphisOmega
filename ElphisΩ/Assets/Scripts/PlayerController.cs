using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currHealth;
    public HealthBar healthBar;

    [SerializeField] private float speed, jumpSpeed;
    private bool currKnockedBack = false;
    private bool isDead = false;
    [SerializeField] private LayerMask ground;
    private PlayerActionControls playerActionControls;
    private Rigidbody2D rb;
    private Collider2D col;
    private Animator animator;
    private SpriteRenderer spriteRender;

    private void Awake(){
        playerActionControls = new PlayerActionControls();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }
    
    private void OnEnable()
    {
        playerActionControls.Enable();

        //set starting health value = maxHealth
        if(SceneManager.GetActiveScene().buildIndex == 2){
            PlayerPrefs.SetInt("score", maxHealth);
        }
        
        //get current health value
        currHealth  =  PlayerPrefs.GetInt("score");
    }

    private void OnDisable()
    {
        playerActionControls.Disable();

    }

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.setHealth(currHealth);
        
        playerActionControls.Land.Jump.performed += _ => Jump();
    }

    private void Jump()
    {
        if(IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }
    }

    private bool IsGrounded()
    {
        Vector2 topLeftPoint = transform.position;
        topLeftPoint.x -= col.bounds.extents.x;
        topLeftPoint.y += col.bounds.extents.y;

        Vector2 bottomRightPoint = transform.position;
        bottomRightPoint.x += col.bounds.extents.x;
        bottomRightPoint.y -= col.bounds.extents.y;

        return Physics2D.OverlapArea(topLeftPoint, bottomRightPoint, ground);
    }

    void Update()
    {
        if(!isDead && !currKnockedBack)
        { 
            Move();
        }
    }

    private void Move ()
    {
        // Read the movement value
        float movementInput = playerActionControls.Land.Move.ReadValue<float>();

        // Sound effect
        if(movementInput == 0) {
            FindObjectOfType<AudioManager>().Play("accelerate_elphis");
        }

        // Move the player
        Vector3 currPos = transform.position;
        currPos.x += movementInput * speed * Time.deltaTime;
        transform.position = currPos;

        //Animation
        if(movementInput != 0) {
            animator.SetBool("Run", true);
        } else {
             animator.SetBool("Run", false);
        }

        //Sprite flip
        if(movementInput == -1)
        {
            spriteRender.flipX = true;
        } else if (movementInput == 1)
        {
            spriteRender.flipX = false;
        }
    }

    private void TakeDamage(int damage)
    {   
        currHealth -= damage;
        healthBar.setHealth(currHealth);
    }
    
    private void Heal(int amount)
    {   
        currHealth += amount;
        if(currHealth > maxHealth) {
            currHealth = 100;
        }
        healthBar.setHealth(currHealth);
    } 

    private IEnumerator OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "EnemyCloud")
        {
            TakeDamage(15);
        }

        if(other.gameObject.tag == "Spike")
        {
            TakeDamage(5);
        }

        if(other.gameObject.tag == "Tornado")
        {
            currKnockedBack = true;
            animator.SetTrigger("KnockBack");
            TakeDamage(10);
            yield return new WaitForSeconds(1.3f);
            currKnockedBack = false;
        } 

        if(other.gameObject.tag == "Enemy" || currHealth <= 0)
        {
            healthBar.setHealth(0);
            animator.SetTrigger("ShutDown");

            isDead = true;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(other.gameObject.tag == "Heart")
        {
            Heal(10);
            Destroy(other.gameObject);
        }
    }

}
