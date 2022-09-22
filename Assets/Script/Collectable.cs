using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour
{
    public CollectableType collectableType;
    public Powerup powerup;
    public GameManager _gameManager;
    [SerializeField] private SpriteRenderer Sr;
    [SerializeField] private SOScriptable collectableObject;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChangeRGB();
            Power();
        }
    }

    public void ChangeRGB()
    {
        switch (collectableType)
        {
            case CollectableType.Yellow:
                Sr.color = Color.yellow;
                break;
            case CollectableType.Blue:
                Sr.color = Color.blue;
                break;
            case CollectableType.Green:
                Sr.color = Color.green;
                break;
            case CollectableType.Red:
                Sr.color = Color.red;
                break;
        }
    }

    public void Power()
    {
        switch (powerup)
        {
            case Powerup.DoubleJump:
                Debug.Log("CanDoubleJump");
                break;
        }
    }
}