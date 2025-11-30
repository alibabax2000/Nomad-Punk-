using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deathScreen; // Панель UI для экрана смерти

    private bool isDead = false;

    void Start()
    {
        if (deathScreen != null)
            deathScreen.SetActive(false);
    }

    void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void PlayerDied()
    {
        isDead = true;
        if (deathScreen != null)
            deathScreen.SetActive(true);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
