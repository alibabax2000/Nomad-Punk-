using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public float hopHeight = 0.3f;

    private Vector3 visualOffset = Vector3.zero;
    [HideInInspector]
    public bool canChooseDirection = true;

    // Словарь текущего соответствия клавиш направлениям
    [HideInInspector]
    public Dictionary<KeyCode, Vector3> keyMapping = new Dictionary<KeyCode, Vector3>();

    private int moveCounter = 0; // счётчик шагов

    void Start()
    {
        movePoint.parent = null;
        RandomizeControls();
    }

    void Update()
    {
        // Плавное движение + визуальный эффект подпрыгивания
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position + visualOffset, moveSpeed * Time.deltaTime);

        if (canChooseDirection)
        {
            HandleInput();
        }
    }

    void HandleInput()
    {
        foreach (var entry in keyMapping)
        {
            if (Input.GetKeyDown(entry.Key))
            {
                Vector3 dir = entry.Value;
                if (!IsWallAt(movePoint.position + dir))
                {
                    canChooseDirection = false;
                    movePoint.position += dir;
                    StartCoroutine(Hop());
                    break;
                }
            }
        }
    }

    bool IsWallAt(Vector3 pos)
    {
        // Проверка коллайдеров по тегу "Wall"
        Collider2D hit = Physics2D.OverlapCircle(pos, 0.2f);
        return hit != null && hit.CompareTag("Wall");
    }

    IEnumerator Hop()
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * moveSpeed;
            float y = Mathf.Sin(t * Mathf.PI) * hopHeight;
            visualOffset = new Vector3(0, y, 0);
            yield return null;
        }
        visualOffset = Vector3.zero;

        canChooseDirection = true;

        // Увеличиваем счётчик ходов
        moveCounter++;

        // Меняем управление каждые 3 хода
        if (moveCounter >= 3)
        {
            RandomizeControls();
            moveCounter = 0;
        }
    }

    // Случайное соответствие WASD направлениям
    void RandomizeControls()
    {
        List<Vector3> directions = new List<Vector3> { Vector3.up, Vector3.down, Vector3.left, Vector3.right };
        List<KeyCode> keys = new List<KeyCode> { KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D };

        keyMapping.Clear();

        while (keys.Count > 0)
        {
            int dirIndex = Random.Range(0, directions.Count);
            int keyIndex = Random.Range(0, keys.Count);

            keyMapping[keys[keyIndex]] = directions[dirIndex];

            keys.RemoveAt(keyIndex);
            directions.RemoveAt(dirIndex);
        }
    }
}
