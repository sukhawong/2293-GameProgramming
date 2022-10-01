using TMPro;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void updateLifeText(int life)
    {
        scoreText.text = $"Life: {life}";
    }
}