using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public Button jumpButton;

    private Rigidbody2D rb;
    private BoxCollider2D box2d;
    private float inputHorizontal;
    private float inputVertical;

    [SerializeField]private GameObject playersBody;
    [SerializeField] private float speed;
    [SerializeField] private float gravityAfterStairs;
    [SerializeField] private float jumpforce;
    [SerializeField] private LayerMask stairCheck;
    [SerializeField] private LayerMask platformCheck;
    [SerializeField] private float rayDistance = 0.5f;

    [SerializeField] private Joystick joy;

    private void Start()
    {
        jumpButton.onClick.AddListener(Jump);
        box2d = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }  

    private void FixedUpdate()
    {
        Move();
        StairsCheck();
    }

   
    #region Move And Jump
    private void Move()
    {
        inputHorizontal = joy.GetAxis.x;
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        Flip();
    }

    public void Jump()
    {
        if (OnGround())
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }
    #endregion 
    #region Ground And Stairs Check
    private void StairsCheck()
    {
        var distance = 1f;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, stairCheck);
        if (hitInfo.collider != null)
        {
            inputVertical = joy.GetAxis.y;
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed * 1.5f);
            rb.gravityScale = 0;

        }
        else
        {
            rb.gravityScale = gravityAfterStairs;
        }
    }
    private bool OnGround()
    {
        
        RaycastHit2D raycast = Physics2D.BoxCast(box2d.bounds.center, box2d.bounds.size, 0f, Vector2.down, rayDistance, platformCheck);
        return raycast.collider != null;
    }
    #endregion 

    private void Flip()
    {
        var characterRotate = playersBody.transform.rotation;
        if (inputHorizontal < 0)
        {
            characterRotate.y = 180;
        }
        if (inputHorizontal > 0)
        {
            characterRotate.y = 0;
        }
        playersBody.transform.rotation = characterRotate;
    }
}
