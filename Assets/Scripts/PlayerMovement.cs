using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private ParticleSystem bubbles;
    public float moveSpeed = 5f;
    private Vector2 moveV;
    private Animator animator;
    private Vector2 particleStartPos;
    private ParticleSystem.EmissionModule emission;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        particleStartPos = bubbles.transform.localPosition;
        emission = bubbles.emission;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveV = moveInput.normalized * moveSpeed;
        if (Input.GetAxisRaw("Horizontal") != 0) {
            animator.SetFloat("X", (Input.GetAxisRaw("Horizontal")));
            emission.rateOverTime = 20;
            //animator.SetFloat("Y", (Input.GetAxisRaw("Vertical")));
            //animator.SetBool("isRunning", true);
            if (Input.GetAxisRaw("Horizontal") > 0){
                bubbles.transform.localPosition = particleStartPos;
                bubbles.transform.rotation = Quaternion.Euler(0,0,0);
            }else{
                Vector2 bubblesPos = particleStartPos;
                bubblesPos.x *= -1f;
                bubbles.transform.localPosition = bubblesPos;
                bubbles.transform.rotation = Quaternion.Euler(0,180,0);
            }
        }else{
            emission.rateOverTime = 3;
        }
        
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + moveV * Time.fixedDeltaTime);
    }
}
