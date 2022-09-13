using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private float move;
    [SerializeField] private float jump;
    private float MoveInput;


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(MoveInput * move, rb.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        MoveInput = value.Get<float>();
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(jump * transform.up, ForceMode2D.Impulse);
        }
    }

}