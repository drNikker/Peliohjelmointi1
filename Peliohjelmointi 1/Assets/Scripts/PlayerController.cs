using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    Animator animator;
    private Rigidbody2D player1;
    public bool punching;
    public Slider healthSlider;
    public int EnemyHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        player1 = GetComponent<Rigidbody2D>();
        EnemyHealth = 100;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        player1.AddForce(movement * Speed);

        if (Input.GetKeyDown("q"))
        {
           
            animator.SetTrigger("leftpunch");
            
        }

        if (Input.GetKeyDown("e"))
        {
           
            animator.SetTrigger("rightpunch");
            
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hand2") && punching)
        {
            Debug.Log("Hit");
            EnemyHealth -= 10;
            healthSlider.value = EnemyHealth;
        }

    }

    public void PunchStart()
    {
        punching = true;
    }

    public void PunchEnd()
    {
        punching = false;
    }
}

