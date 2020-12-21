using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public bool canMove;

    [Header("Jump")]
    public bool canJump;
    public float jumpSpeed;
    public float fallSpeed;
    public float jumpHeight;

    private float jumpTargetHeight;
    private bool startJump;
    private bool jumpRising;
    private bool jumpFalling;

    /// Private ///

    private Vector2 moveVector;

    private void Update()
    {
        if (canMove)
        {
            moveVector = Vector2.right * speed;
        }

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            startJump = true;
        }

        if (startJump)
        {
            jumpTargetHeight = transform.position.y + jumpHeight;
            jumpRising = true;
            startJump = false;
        }
        if (jumpRising)
        {
            moveVector.y = Vector2.up.y * jumpSpeed;
            if(transform.position.y >= jumpTargetHeight)
            {
                jumpRising = false;
                jumpFalling = true;
            }
        }
        if (jumpFalling)
        {
            moveVector.y = -Vector2.up.y * fallSpeed;
        }

        transform.position += (Vector3)moveVector * Time.deltaTime;
        
        if(transform.position.y < 0)
        {
            jumpFalling = false;
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }
}
