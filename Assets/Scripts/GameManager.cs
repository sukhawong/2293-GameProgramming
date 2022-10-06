using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    
    [SerializeField] public int playerLife = 3;
    [SerializeField] private Transform lifeText;
    [SerializeField] private LifeDisplay _lifeDisplay;

    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() 
    {
        UpdateLife();  
    }

    private void Update()
    {
        if(playerLife <= 0)
        {
            Destroy(gameObject);
            LoadScene(0);
        }
        if(GetCurrentBuildIndex() == 0)
        {
            lifeText.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            lifeText.gameObject.SetActive(true);
        }
    }

    public IEnumerator ProcessPlayerDeath()
    {
        UpdateLife();
        yield return new WaitForSeconds(2f);
        LoadScene(GetCurrentBuildIndex());
    }

    public IEnumerator LoadNextLevel()
    {
        UpdateLife();
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        yield return new WaitForSeconds(2f);
        
        LoadScene(nextSceneIndex);
    }

    public IEnumerator LoadLevelone()
    {
        yield return new WaitForSeconds(2f);
        LoadScene(1);
    }

    public int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadScene(int buildindex)
    {
        UpdateLife();
        SceneManager.LoadScene(buildindex);
        DOTween.KillAll();
    }

    public void DecreaseLife()
    {
        playerLife--;
        UpdateLife();
    }

    public void UpdateLife()
    {
        _lifeDisplay.updateLifeText(playerLife);
    }
}
