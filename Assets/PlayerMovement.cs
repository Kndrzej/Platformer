using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float jumpSpeed;
    private Rigidbody2D player;
    private float horizontalInput;
    private Animator animator;
    public bool grounded;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(horizontalInput * playerMovementSpeed, player.velocity.y);
        //Flipping Player Sprite
        if (horizontalInput > 0.01f) transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f) transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKeyDown(KeyCode.Space) && grounded) Jump();
        animator.SetBool("run", horizontalInput != 0);
    }
    private void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        animator.SetBool("grounded", false);
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("grounded", true);
            grounded = true;
        }
    }
    public bool CanAttack()
    {
        return horizontalInput == 0 && grounded == true;
    }
}
