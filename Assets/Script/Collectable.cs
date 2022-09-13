using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType collectableType;

    [SerializeField] private SpriteRenderer Sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ChangeRGB();

            Destroy(gameObject);
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
}