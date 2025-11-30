using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public int pickUpsToNextLevel = 5;
    public int currentPickUps = 0;

    public PickUpSpawner spawner;
    public TMP_Text scoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreUI();
        spawner.SpawnPickUp();
    }

    public void AddPickUp()
    {
        currentPickUps++;
        UpdateScoreUI();

        spawner.ClearPickUp();
        spawner.SpawnPickUp();

        if (currentPickUps >= pickUpsToNextLevel)
            NextLevel();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + currentPickUps;
    }

    void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}
