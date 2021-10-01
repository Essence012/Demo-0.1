using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
   Rigidbody2D rigidbody2d;
   Animator animator;
   SpriteRenderer sprite;
   [SerializeField]
   int speed;
   [SerializeField]
   int jumpspeed;
   [SerializeField]
   Transform groundCheck;
   [SerializeField]
   GameObject attackHitBox;

   public int health { get { return currentHealth; }}
   int currentHealth;

   public float timeInvincible = 2.0f;
   bool isInvincible;
   float invincibleTimer;

   bool isGrounded;
   public float checkRadius;
   public LayerMask whatIsGround;
   bool isAttacking = false;
   public int maxHealth = 100;
   private void Start()
   {
		  animator= GetComponent<Animator>();
		  rigidbody2d= GetComponent<Rigidbody2D>();
		  sprite = GetComponent<SpriteRenderer>();
		  attackHitBox.SetActive(false);
		  currentHealth = maxHealth;
   }

   private void Update()
   {  
        
          
		  if (Input.GetButtonDown("Fire1") && !isAttacking)
		  {
		    isAttacking = true;
			if (isGrounded == false)
			{
			animator.Play("Player_FlyAttack");
			}
			else 
			{
			int choose = UnityEngine.Random.Range(1,2); //выбор от 1 до 5 для вариации атак
			animator.Play("Player_Attack"+choose);  //играть анимацию + номер анимации если несколько видов атаки
			}

			
			StartCoroutine(DoAttack());

		  }
		  if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
   }
   
   private void FixedUpdate()
   {
         
         isGrounded= Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);		  
		  if (Input.GetKey(KeyCode.D))
    	  {
		    rigidbody2d.velocity = new Vector2(speed,rigidbody2d.velocity.y);
		    if (isGrounded && !isAttacking)
		    animator.Play("Player_Run") ; 
			transform.localScale = new Vector3(1,1,1);
		  }
		  else if (Input.GetKey(KeyCode.A))
		       {
		          rigidbody2d.velocity = new Vector2(-speed,rigidbody2d.velocity.y);
		          if (isGrounded && !isAttacking)
		          animator.Play("Player_Run") ; 
		          transform.localScale = new Vector3(-1,1,1);
		       }
		       else 
		       {
		           rigidbody2d.velocity= new Vector2(0,rigidbody2d.velocity.y);
		           if (isGrounded)
		           {
			          if (!isAttacking)
				      {
		              animator.Play("Player_Idle"); 
			          }
			       }
		       }
		  if (Input.GetKey(KeyCode.Space) && isGrounded == true)
		  {
				rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x,jumpspeed);
				if (isAttacking== false)
				{
				 animator.Play("Player_Jump") ; 
				}
          }

   }
   IEnumerator DoAttack()
   {
          Debug.Log("атака");
          attackHitBox.SetActive(true);
		  yield return new WaitForSeconds(1f);
		  attackHitBox.SetActive(false);
		  isAttacking = false;
   }
   public void ChangeHealth(int amount)
    {
	Debug.Log(currentHealth);
        if (amount < 0)
        {
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    } 	 
}