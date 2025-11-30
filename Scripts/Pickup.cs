using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelManager.instance.AddPickUp();  // ← сообщаем что пикап собран
            Destroy(gameObject);
        }
    }
}
