using UnityEngine;

public class IdleDestroyer : MonoBehaviour
{
    public float maxIdleTime = 3f; // Время без движения до "смерти"
    private float idleTime = 0f;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (transform.position != lastPosition)
        {
            idleTime = 0f;
            lastPosition = transform.position;
        }
        else
        {
            idleTime += Time.deltaTime;
        }

        if (idleTime >= maxIdleTime)
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.PlayerDied(); // Вызов экрана смерти вместо Destroy
            }

            gameObject.SetActive(false); // Скрываем игрока
        }
    }
}
