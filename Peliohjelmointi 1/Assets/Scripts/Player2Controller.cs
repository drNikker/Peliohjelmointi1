using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Controller : MonoBehaviour
{
    public float Speed;
    Animator animator;
    private Rigidbody2D player2;
    public bool punching;
    public Slider healthSlider;
    public int EnemyHealth;


    void Start()
    {
        animator = GetComponent<Animator>();
        player2 = GetComponent<Rigidbody2D>();
        EnemyHealth = 100;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal2");
        float moveVertical = Input.GetAxis("Vertical2");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        player2.AddForce(movement * Speed);

        if (Input.GetKeyDown("u"))
        {
            
            animator.SetTrigger("leftpunch");
            
        }

        if (Input.GetKeyDown("o"))
        {
            
            animator.SetTrigger("rightpunch");
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("hand1") && punching)
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
