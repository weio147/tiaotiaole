using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    public float jumpForce = 10;
    public float length = 20;
    public override void Update()
    {
        base.Update();
        Vector3 pos = transform.position;
        if (transform.position.x > rightBound)
            transform.position = new Vector3(rightBound, pos.y, pos.z);
        if (transform.position.x < leftBound)
            transform.position = new Vector3(leftBound, pos.y, pos.z);    

        if (rb.velocity.y < 0)
        {
            animator.SetBool("isjump", false);
            animator.SetBool("isfall", true);
        }

        if (coll.IsTouchingLayers(ground))
        {
            animator.SetBool("isfall", false);
            animator.SetBool("isidle", true);
        }
    }
    //animation event 调用
    public void Jump()
    {
        Vector3 pos = transform.position;
        if (pos.x < leftBound + length)
        {
            direction = 1;
        }
        else if (pos.x > rightBound - length)
        {
            direction = -1;
        }
        rb.velocity = new Vector2(direction * jumpForce, jumpForce);
        transform.localScale = new Vector3(-direction, 1, 1);
        animator.SetBool("isjump", true);
    }
}
