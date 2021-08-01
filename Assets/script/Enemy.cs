using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float force = 10;

    public LayerMask ground;
    protected float leftBound, rightBound;
    protected float direction = -1;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected Collider2D coll;
    void Start()
    {
        leftBound = transform.Find("leftBound").transform.position.x;
        rightBound = transform.Find("rightBound").transform.position.x;

        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator ani = collision.gameObject.GetComponent<Animator>();
            Vector3 pos = collision.gameObject.transform.position;
            PlayerControl player = collision.gameObject.GetComponent<PlayerControl>();
            if (player == null)
            {
                return;
            }
            if (ani.GetBool("isfall"))
            {
                Destroy(gameObject);
                player.Jump();
            }
            else if(pos.x < transform.position.x){
                player.AddDirForce(new Vector2(-force, 0));
            }
            else if(pos.x> transform.position.x)
            {
                player.AddDirForce(new Vector2(force, 0));
            }
           
        }
    }
}
