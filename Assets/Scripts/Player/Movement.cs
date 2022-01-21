using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
  public Rigidbody2D playerRB;
  public Collider2D playerCollider;
  public SpriteRenderer playerSprite;
  public Animator playerAnim;

  public float speedX = 2, speedY = 2;
  public float maxSpeedX = 5, maxSpeedY = 5;
  float despX;
  public float sprint1, sprint2;
  bool isRunning = false;
  float runTime;

  public LayerMask ground;
  public Transform feet;
  public float checkRadius;
  bool isJumping = false, isGrounded;
  public float jumpForce;
  public float jumpTime;
  private float jumpTimeCounter;
  Vector2 leftPoint, rightPoint;

/*   // Start function
  // void Start()
  // {
  //   playerRB = GetComponent<Rigidbody2D>();
  //   playerCollider = GetComponent<Collider2D>();
  //   playerSprite = GetComponent<SpriteRenderer>();
  //   playerAnim = GetComponent<Animator>();
  // } */

  void FixedUpdate()
  {
    Walk();
  }

  // Update is called once per frame
  void Update()
  {
    Jump();
  }

  void Jump()
  {
    // Check if the player is grounded, in the two point of the down vertices
    leftPoint = new Vector2(feet.position.x - checkRadius, feet.position.y - 0.01f);
    rightPoint = new Vector2(feet.position.x + checkRadius, feet.position.y - 0.01f);

    isGrounded = Physics2D.OverlapPoint(leftPoint, ground) || Physics2D.OverlapPoint(rightPoint, ground);
    // print((Physics2D.OverlapPoint(leftPoint, ground), Physics2D.OverlapPoint(rightPoint, ground)));
    // pressJump=Input.GetKey(KeyCode.W);
    if (isGrounded)
    {
      playerAnim.SetBool("isGrounded", true);
      if (Input.GetKeyDown(KeyCode.W))
      {
        playerAnim.SetBool("isJumping", true);
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        // playerRB.AddForce(new Vector2(0,jumpForce));
        isJumping = true;
        jumpTimeCounter = jumpTime;
      }
    }
    else
    {
      playerAnim.SetBool("isGrounded", false);
    }
    if (Input.GetKey(KeyCode.W) && isJumping)
    {
      if (jumpTimeCounter > 0)
      {
        playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        // playerRB.AddForce(new Vector2(0, jumpForce));
        jumpTimeCounter -= Time.deltaTime;
      }
      else
      {
        playerAnim.SetBool("isJumping", false);
        isJumping = false;
      }
    }
    if (Input.GetKeyUp(KeyCode.W))
    {
      playerAnim.SetBool("isJumping", false);
      isJumping = false;
    }
  }

  void Walk()
  {
    despX = Input.GetAxis("Horizontal") * speedX;
    isRunning = Input.GetKey(KeyCode.LeftShift);
    // print((despX, isRunning));
    if (despX != 0)
    {
      if (isRunning)
      {
        despX *= sprint1;
        playerAnim.SetFloat("isRunning", 1.25f);
      }
      else
      {
        playerAnim.SetFloat("isRunning", 1f);
      }
      playerAnim.SetBool("isWalking", true);
      playerRB.velocity = new Vector2(despX, playerRB.velocity.y);
      // playerRB.AddForce(new Vector2(despX, 0));
      if (despX < 0)
      {
        playerSprite.flipX = true;
        if (-playerRB.velocity.x > maxSpeedX)
        {
          playerRB.AddForce(new Vector2(-maxSpeedX - playerRB.velocity.x, 0));
        }
      }
      else if (despX > 0)
      {
        playerSprite.flipX = false;
        if (playerRB.velocity.x > maxSpeedX)
        {
          playerRB.AddForce(new Vector2(maxSpeedX - playerRB.velocity.x, 0));
        }
      }
    }
    else
    {
      playerAnim.SetBool("isWalking", false);
    }
  }
  /* 
    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //   print("Colision");
    // // }
    // GameObject backState, newState;
    // void OnTriggerEnter2D(Collider2D collider)
    // {
    //   print(collider.tag);
    //   if (collider.tag == "RedMushroom")
    //   {
    //     if (PlayerState == "Small")
    //     {
    //       backState = transform.GetChild(1).gameObject;
    //       newState = transform.GetChild(2).gameObject;
    //       backState.gameObject.SetActive(false);
    //       newState.gameObject.SetActive(true);
    //       collider.gameObject.SetActive(false);

    //       playerCollider = newState.GetComponent<Collider2D>();
    //       playerSprite = newState.GetComponent<SpriteRenderer>();
    //       playerAnim = newState.GetComponent<Animator>();
    //     }
    //   }
    // }
  */
}
