using UnityEngine;

public class PLayerAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetAnimatorParameter(Vector2 playerVelocity)
    {
        animator.SetFloat("Verocity", Mathf.Abs(playerVelocity.x));

    }
}
