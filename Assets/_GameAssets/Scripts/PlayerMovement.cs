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
        if(GameStateManager.Instance != null) GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    public int maxJumps = 2;

    public int jumps;
   

    
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(horizontalInput * playerMovementSpeed, player.velocity.y);
        //Flipping Player Sprite
        if (horizontalInput > 0.01f) transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f) transform.localScale = new Vector3(-1,1,1);

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        animator.SetBool("run", horizontalInput != 0);
    }
    private void Jump()
    {
        if (jumps > 0)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            grounded = false;
            jumps = jumps - 1;
        }
        if (jumps == 0)
        {
            return;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            animator.SetBool("grounded", true);
            grounded = true;
            jumps = maxJumps;
        }
    }
    public bool CanAttack()
    {
        return horizontalInput == 0 && grounded == true;
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }

}
