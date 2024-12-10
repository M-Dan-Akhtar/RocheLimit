using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementWithDashing : MonoBehaviour
{
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    [SerializeField]private float speed;
    private Rigidbody2D body;
    private bool grounded;


    private void Awake()
    {
      body = GetComponent<Rigidbody2D> ();
    }

    private void Update()
    {
        if (isDashing)
        {
            return;
        }

      body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

      if(Input.GetKey(KeyCode.Space) && grounded)
      {
        Jump();
      }

      if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
      {
           StartCoroutine(Dash());
      }
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
