using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speedForce = 10f, jumpForce = 10f;

    private Rigidbody2D playerBody;
	private Animator anim;
	private SpriteRenderer sr;

    [SerializeField] private bool isGrounded;
    private string GroundTag = "Ground";
    private string movingAnimation = "isMoving";
    private float movementX;
    // Start is called before the first frame update
    private void Awake() {
		playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
	}	

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * speedForce;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded){
            isGrounded = false;
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GroundTag))
        {
            isGrounded = true;
        }
    }

    void AnimatePlayer ()
    {
        if (movementX > 0)
        {
            sr.flipX= false;
            anim.SetBool(movingAnimation, true);
        }
        else if (movementX  < 0)
        {
            sr.flipX= true;
            anim.SetBool(movingAnimation, true);
        }
        else
        {
            anim.SetBool(movingAnimation, false);
        }
    }

  

}
