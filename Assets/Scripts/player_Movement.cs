using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    Rigidbody2D rigid;

    private float dirX = 0f;

    float speed = 15f;

    public projectile_Behavior projectilePrefab;
    public Transform launchOffset;
    private SpriteRenderer sprite;

    private bool isPaused = false;

    GameObject backToMainMenu; 

    private enum MovementState {idle, running}

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        backToMainMenu = GameObject.FindGameObjectWithTag("ShowWhenPaused");
        backToMainMenu.SetActive(false);
    }

    void FixedUpdate()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rigid.velocity = new Vector2(dirX * speed, rigid.velocity.y);


        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = !isPaused;
                backToMainMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                isPaused = !isPaused;
                backToMainMenu.SetActive(false);
            }
        }

        UpdateAnimationState();
    }


    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            //Flip();
            state = MovementState.running;
            sprite.flipX = false;
            //Flip();
        }

        else if (dirX < 0f)
        {
            //Flip();
            state = MovementState.running;
            sprite.flipX = true;
            //Flip();
        }
        else
        {
            state = MovementState.idle;
        }

        anim.SetInteger("state", (int)state);
    }
}
