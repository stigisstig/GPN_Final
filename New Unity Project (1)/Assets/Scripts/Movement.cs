using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public float sprintspeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public BulletTime bullet;
    public Vector3 Vector3;
    public GameObject Player;
    public float health;


    public Quaternion callit(Quaternion qu)
    {
        Quaternion holy = qu;
        return holy;
    }



    private Vector3 moveDirection = Vector3.zero;

    Animator animator;
    void Start()
    {
        health = 100;
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    public void palyermovement()
    {
        float PlayerFacing = transform.rotation.y;
        animator.SetFloat("Debugdig", PlayerFacing);
        float playermove = Input.GetAxis("Horizontal");
        if (characterController.isGrounded)
        {
            animator.SetBool("isGrounded", true);
            


            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            moveDirection *= speed;

            animator.SetFloat("movenig", playermove);
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
            }
            else
            {
                animator.ResetTrigger("Jump");
            }
            if (Input.GetKey(KeyCode.LeftShift) && !(Input.GetKey(KeyCode.K)))
            {
                animator.SetBool("Sprint", true);
                moveDirection *= sprintspeed;
            } 
            else
            {
                animator.SetBool("Sprint", false);
            }
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Crouch", true);
            }
            else
            {
                animator.SetBool("Crouch", false);
            }
            if (Input.GetKey(KeyCode.J))
            {
                animator.SetTrigger("Attack1");
            }
            else
            {
                animator.ResetTrigger("Attack1");
            }
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping Up 1"))
            {
                moveDirection.y = jumpSpeed;
            }
            

        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            bullet.bulletbullettime();
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            bullet.backtonormal();
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

    void Update()
    {
        if(transform.position.z != 0)
        {
            Vector3 vector = transform.position;
            vector.z = 0;
            transform.position = vector;
        }
        if (Input.GetKey(KeyCode.K))
        {
            animator.SetTrigger("Block");
        }
        else
        {
            animator.ResetTrigger("Block");
        }
        palyermovement();

    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.transform);
    }
    public void PlayerGetHit()
    {
        
        if(health > 0)
        {
            health -= 1;
        }
        else
        {
            Destroy(Player);
        }
    }
    public string HealthPlayer()
    {
        return health.ToString();
    }
}

