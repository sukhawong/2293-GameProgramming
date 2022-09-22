using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PLayerAnimatorController animatorController;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float move;
    [SerializeField] private float jump;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private bool isOnGround;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Animator anim;
    [SerializeField] private bool canJump;
    [SerializeField] private Transform playerTransform;
    private float MoveInput;


    private void Update() 
    {
        Flip();
        GroundCheck();
        CheckCanJump();
        Animation();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void OnMove(InputValue value)
    {
        MoveInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (canJump)
        {
            if (value.isPressed)
            {
                rb.AddForce(jump * transform.up, ForceMode2D.Impulse);
            }
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(MoveInput * move, rb.velocity.y);
    }

    private void Flip()
    {
        if (MoveInput == -1)
        {
            playerTransform.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (MoveInput == 1)
        {
            playerTransform.transform.localScale = Vector3.one;
        }
    }

    private void GroundCheck()
    {
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);
    }

    private void CheckCanJump()
    {
        if(isOnGround)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void Animation()
    {
        anim.SetBool("Is_On_Ground", isOnGround);
        anim.SetFloat("Verocity", Mathf.Abs(rb.velocity.x));
    }
}