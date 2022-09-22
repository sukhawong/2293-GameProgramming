using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    
    private Collider2D _playerCollider;

    private GameManager _gameManager;

    private void Start() 
    {
        _gameManager = FindObjectOfType<GameManager>();
        _playerCollider = GetComponent<Collider2D>();
    }

    private void TakeDamage()
    {
        _gameManager.ProcessPlayerDeath();
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {



        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            TakeDamage();
        }
    }
        

}
