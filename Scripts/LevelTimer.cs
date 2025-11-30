using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public float levelTime = 30f;      // Сколько секунд даётся игроку
    private float timer;

    public TMP_Text timerText;         // Текст на UI
    private bool isDead = false;

    void Start()
    {
        timer = levelTime;
        UpdateTimerUI();
    }

    void Update()
    {
        if (isDead) return;

        timer -= Time.deltaTime;
        if (timer < 0) timer = 0;

        UpdateTimerUI();

        if (timer <= 0)
        {
            isDead = true;
            TimeEnded();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(timer);
            timerText.text = "Time: " + seconds;
        }
    }

    void TimeEnded()
    {
        // Используем GameManager для смерти
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.PlayerDied();
        }
    }
}
