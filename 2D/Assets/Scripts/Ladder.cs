using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour

{
    [SerializeField]  
    float speed = 4;

    Animator animator;

    void OnTriggerStay2D(Collider2D other)
    {      
        if (other.gameObject.CompareTag("Player"))
        {
        animator = other.GetComponent<Animator>();
        other.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (Input.GetKey(KeyCode.W))
            {
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,speed);
                Debug.Log("W");
                animator.Play("Player_Ladder");
            }
        
            else if (Input.GetKey(KeyCode.S))
            {
             other.GetComponent<Rigidbody2D>().gravityScale = 0;
             other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
             Debug.Log("S");
             animator.Play("Player_Ladder");
            }
             else
             {
             other.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
             animator.Play("Player_Ladder");
             }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
    other.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}