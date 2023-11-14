using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxSpeed = 5f;
    private float horizontal = 0;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            isJumping = true;
        }

        horizontal = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(1 * horizontal * moveSpeed, 0));
        if (horizontal != 0)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity.Normalize();
        }
    }
  

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(1 * horizontal * moveSpeed, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Icicle" || collision.gameObject.tag == "Fall")
        {
            SceneManager.LoadScene(0);
        }

        if (collision.gameObject.CompareTag ("Ground"))
        {
            isJumping = false;
        }
    }
}
