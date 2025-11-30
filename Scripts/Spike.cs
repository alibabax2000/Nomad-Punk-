using UnityEngine;

public class Spike : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.PlayerDied();
            }

            // Скрываем игрока, чтобы он не мешал после смерти
            other.gameObject.SetActive(false);
        }
    }
}
