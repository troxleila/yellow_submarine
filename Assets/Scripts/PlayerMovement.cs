using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Vector2 moveV;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveV = moveInput.normalized * moveSpeed;
        if (Input.GetAxisRaw("Horizontal") != 0) {
            animator.SetFloat("X", (Input.GetAxisRaw("Horizontal")));
            //animator.SetFloat("Y", (Input.GetAxisRaw("Vertical")));
            //animator.SetBool("isRunning", true);
        }
        //else{
            //animator.SetBool("isRunning", false);
        //}
        
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + moveV * Time.fixedDeltaTime);
    }
}
