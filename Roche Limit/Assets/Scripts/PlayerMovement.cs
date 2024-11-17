using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField]private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private float dashDirV = 0f;
    [SerializeField] private TrailRenderer tr;
    private void Awake()
    {
      body = GetComponent<Rigidbody2D> ();
      anim = GetComponent<Animator> ();
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }
        float horizontalInput = Input.GetAxis("Horizontal");

      body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

      // Flips player image when moving left or right
      if(horizontalInput > 0.01f)
      {
        transform.localScale = Vector3.one;
      }
      else if(horizontalInput < -0.01f)
      {
        transform.localScale = new Vector3(-1,1,1);
      }


      if(Input.GetKey(KeyCode.Space) && grounded)
      {
        Jump();
      }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKey(KeyCode.W))
        {
            dashDirV = 1;
            print("W Pressed, dir UP");
        }

        if (Input.GetKey(KeyCode.S))
        {
            dashDirV = -1;
            print("S Pressed, dir DOWN");
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            dashDirV = 0;
            print("vertical direction 0, will go straight");
        }

        // Change running animation
        anim.SetBool("run",horizontalInput != 0);
      anim.SetBool("grounded",grounded);
    }
    private void FixedUpdate()
    {
        if (isDashing)
        { return; }
    }
    private void Jump()
    {
      body.velocity = new Vector2(body.velocity.x, speed);
      grounded = false;
      anim.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Ground")
      {
        grounded = true;
            canDash = true;
      }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            canDash = true;
        }
    }


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;

        // Check the horizontal input to determine dash direction
        float dashDirH = Input.GetAxisRaw("Horizontal");
        if (dashDirH == 0 && dashDirV == 0) dashDirH = transform.localScale.x; // Use the character's current facing direction as a fallback

        if(dashDirV != 0 && dashDirH != 0)
        {
            body.velocity = new Vector2(dashDirH * (dashingPower / 2), dashDirV * (dashingPower / 3));
        }
        else
        {
            body.velocity = new Vector2(dashDirH * dashingPower, dashDirV * (dashingPower / 3));
        }

        

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);

        tr.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
    }
}
