using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private CollectibleSpawner collectibleSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SOCollectibles collectibleObject;
    
    [SerializeField] private AudioSource collectSoundEffect;

    private CollectibleType _collectibleType;
    private bool _isRespawnable;

    private void Start()
    {
        SetCollectible();
    }

    private void CollectSound()
    {
        collectSoundEffect.Play();
    }
    
    public CollectibleType GetCollectibleInfoOnContact()
    {
        //AudioManager.instance.PlayerSFX(7);
        CollectSound();
        gameObject.SetActive(false);

        if (_isRespawnable)
        {
            collectibleSpawner.StartRespawningCountdown();
        }
        return _collectibleType;
    }
    
    private void SetCollectible()
    {
        collectibleSpawner.SetOutlineSprite(collectibleObject.GetOutlineSprite());
        spriteRenderer.sprite = collectibleObject.GetSprite();
        _collectibleType = collectibleObject.GetCollectibleType();
        _isRespawnable = collectibleObject.GetRespawnable();
    }
}
