using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D body;
    private bool grounded;

    private void Awake()
    {
      body = GetComponent<Rigidbody2D> ();
    }
    private void Update()
    {
      body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

      if(Input.GetKey(KeyCode.Space) && grounded)
      {
        Jump();
      }
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
}
