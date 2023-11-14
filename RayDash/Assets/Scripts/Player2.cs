using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float moveSpeed;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");

            // Vector2.up == new Vector2(0, 1)
            // (0, 1) * 12 == (0*12, 1*12) == (0, 12)
        }

        float horizontal = Input.GetAxis("Horizontal");

        //Input.GetAxis() -> -1.00 to 1.00
        // Not pressing anything -> 0
        // Pressing right arrow or d -> 1
        // Pressing left arrow or a -> -1

        transform.Translate(new Vector2(horizontal * moveSpeed * Time.deltaTime, 0));
        if (horizontal != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
