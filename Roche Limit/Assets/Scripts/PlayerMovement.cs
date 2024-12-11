using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    [SerializeField]private float speed = 5;
    [SerializeField]private float jumpSpeed = 8;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;


    //Sounds
    [SerializeField] private AudioClip jumpingSound;
    [SerializeField] private AudioClip dashingSound;
    private void Awake()
    {
      body = GetComponent<Rigidbody2D> ();
      anim = GetComponent<Animator> ();
      tr.emitting = false;
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
            SoundManger.instance.PlaySound(jumpingSound);
            Jump();
      }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            SoundManger.instance.PlaySound(dashingSound);
            StartCoroutine(Dash());
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
      body.velocity = new Vector2(body.velocity.x, jumpSpeed);
      grounded = false;
      anim.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Ground")
      {
        grounded = true;
      }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;

        // Check the horizontal input to determine dash direction
        float dashDirection = Input.GetAxisRaw("Horizontal");
        if (dashDirection == 0) dashDirection = transform.localScale.x; // Use the character's current facing direction as a fallback

        body.velocity = new Vector2(dashDirection * dashingPower, 0f);

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);

        tr.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
