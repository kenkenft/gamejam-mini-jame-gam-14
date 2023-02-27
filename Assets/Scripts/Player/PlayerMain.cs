using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    bool isInteracting = false,isPaused = false, isPlaying = false, isFacingRight = true;
    PlayerMove playerMove;
    // UIManager uiManager;
    PlayerInteract playerInteract;
    Vector3 playerStartPos = new Vector3(1f, -4.5f, 1f);
    SpriteRenderer playerSpriteRenderer;
    float horizontalSpeed = 0f;
    public GameObject playerSpawn;
    [SerializeField] int levelState = 0;

    public Animator animator;
    AudioManager audioManager;

    public void SetUp()
    {
        levelState = 0;
        playerMove = GetComponent<PlayerMove>();
        playerMove.SetUp();
        playerInteract = GetComponent<PlayerInteract>();
        // uiManager = FindObjectOfType<UIManager>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        SetPlayerStartPos();
        audioManager = GetComponentInParent<AudioManager>();
    }
    void Update()
    {
        if(!isPaused && isPlaying)
        {
            if(Input.GetKeyDown("space"))
            {    
                playerMove.Jump();
                if(playerMove.GetPlayerVerticalVel() > 0f)
                    animator.SetBool("IsJumping", true);
                audioManager.Play("Jump");
            }

            horizontalSpeed = Input.GetAxis("Horizontal");
            if(horizontalSpeed !=0 )
            {    
                playerMove.Move(horizontalSpeed);
                animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));

                if(horizontalSpeed > 0f && !isFacingRight)
                    FlipSprite(); 
                else if(horizontalSpeed < 0f && isFacingRight) 
                    FlipSprite();
                
            }
            
            playerMove.VelocityDecay();

            if( Input.GetKeyDown(KeyCode.F) && playerInteract.GetIsInteracting() )
            {
                isInteracting = playerInteract.PickUp(levelState);
                // audioManager.Play("Interact");
            }
        }
    }

    void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void SetPlayerStartPos()
    {
        gameObject.transform.position = playerStartPos;
        gameObject.transform.position = playerSpawn.transform.position;
    }

    public void SetIsPlaying(bool state)
    {
        isPlaying = state;
    }

    public void SetLevelState(int newLevelState)
    {
        levelState = newLevelState;
        // Debug.Log("Game state advanced to state: " + newLevelState);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.contacts[0].normal == Vector2.up)
        {
            animator.SetBool("IsJumping", false);
        }
    }
}
