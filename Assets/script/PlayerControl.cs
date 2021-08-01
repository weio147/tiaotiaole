using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    public float speed;
    public float jumpSpeed;
    public LayerMask ground;
    public Collider2D cll;

    [SerializeField]
    public Text cherryNum;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (animator.GetBool("isHurt"))
        {
            if (Mathf.Abs(rb.velocity.x) < 0.1)
            {
                animator.SetBool("isHurt", false);
                animator.SetBool("isidle", true);
            }
        }
        else
        {
            Movement();
        }
    }
    private void Update()
    {
        if (!animator.GetBool("isHurt"))
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        
    }
    void Movement()
    {
        float horizontalmove = Input.GetAxis("Horizontal");
        float horizontalDeriction = Input.GetAxisRaw("Horizontal");
        float verticalDeriction = Input.GetAxisRaw("Vertical");
        if (horizontalmove != 0)
        {
            animator.SetFloat("isRun", Mathf.Abs(horizontalDeriction));
            rb.velocity = new Vector2(horizontalmove * Time.deltaTime * speed, rb.velocity.y);
        }
        if (horizontalDeriction != 0)
        {
            Vector3 v = transform.localScale;
            transform.localScale = new Vector3(horizontalDeriction, v.y, v.z);
        }
        
        if (verticalDeriction==-1)
        {
            animator.SetBool("isSquat", true);
        }
        else
        {
            animator.SetBool("isSquat", false);
        }
        if (rb.velocity.y < 0)
        {
            animator.SetBool("isfall",true);
            animator.SetBool("isjump", false);
        }
        if (cll.IsTouchingLayers(ground))
        {
            animator.SetBool("isidle", true);
            animator.SetBool("isfall", false);
        }
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        animator.SetBool("isjump", true);
    }
    public void AddDirForce(Vector2 force)
    {
        rb.velocity = force;
        animator.SetBool("isHurt", true);
    }
}
