using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //managing health of Player
    public int maxHealth = 100;
    public int currHealth = 0;

    public HealthBar healthBar;

    [SerializeField] private float speed, jumpSpeed;
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
        //healthBar = GetComponent<HealthBar>(); // Todo: right this way?
    }
    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        //DontDestroyOnLoad(gameObject);
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

    // Update is called once per frame
    void Update()
    {
        
        if(isAlive()) //Todo i can still run when dying
        { 
             Move();
        }

        
        if(gameObject.tag == "EnemyCloud")
        //if(Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(10);
        }
/*
        if(gameObject.tag == "Heart")
        {
            GainLife(10);
        }
*/
    }

    private void TakeDamage(int damage)
    {
        currHealth -= damage;

        healthBar.setHealth(currHealth);
    }
/*
    private void GainLife(int plus)
    {
        currHealth += plus;

        healthBar.setHealth(currHealth);
    }
 */   

    private void Move ()
    {
        // Read the movement value
        float movementInput = playerActionControls.Land.Move.ReadValue<float>();

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

    private IEnumerator OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            animator.SetBool("Shutdown", true);

            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

/*
    private void OnCollisionEnter(Collision2D other){
        if(other.gameObject.tag == "EnemyCloud") {
            TakeDamage(10);
        }
    }
*/

    private bool isAlive()
    {
        if(animator.Equals("Shutdown") )
        {
            return false;
        }
        return true;
    }
    

}
