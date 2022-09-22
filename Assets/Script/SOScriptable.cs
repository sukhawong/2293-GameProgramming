using UnityEngine;

[CreateAssetMenu(menuName = "Collectable", fileName = "New Collectable")]

public class SOScriptable : ScriptableObject
{
    [SerializeField] private CollectableType CollectableType;
    [SerializeField] private Powerup powerupPickup;
    [SerializeField] private Sprite sprite;
    [SerializeField] private Sprite outlineSprite;
    [SerializeField] private bool respawnable;

    public Sprite GetSprite() => sprite;
    public CollectableType GetCollectableType() => CollectableType;
    public Sprite GetOutlineSprite() => outlineSprite;
    public bool GetRespawn() => respawnable;
}