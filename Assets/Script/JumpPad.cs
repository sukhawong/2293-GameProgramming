using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpPadForce = 13f;
    [SerializeField] private float additionalSleepJumpTime = 0.3f;

    private static readonly int Bounce = Animator.StringToHash("Bounce");

    public float GetJumpPadForce() => jumpPadForce;
    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;

    public void TriggerJumpPad()
    {
        animator.SetTrigger(Bounce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerJumpPad();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPadForce, ForceMode2D.Impulse);
        }
    }
}
