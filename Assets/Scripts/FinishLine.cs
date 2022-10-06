using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private AudioSource nextLevelSoundEffect;
    private const string PlayerTag = "Player";

    private GameManager _gameManager;
    
    // Why are we checking if the player reaches the finish line here? So, we do not
    // have to check for every time the player collides with something for a finish line.
    
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        nextLevelSoundEffect.Play();
        if (!col.CompareTag(PlayerTag)) return;

        if (_gameManager.GetCurrentBuildIndex() < 3)
        {
            StartCoroutine(_gameManager.LoadNextLevel());
        }
        else
        {
            StartCoroutine(_gameManager.LoadLevelone());
        }
    }
}
