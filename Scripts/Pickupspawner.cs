using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public GameObject pickUpPrefab;

    public Vector2Int minGrid; // границы карты
    public Vector2Int maxGrid;

    public float minDistance = 2f; // минимальное расстояние до предыдущего пикапа
    public float maxDistance = 5f; // максимальное расстояние до предыдущего пикапа

    private GameObject currentPickUp;
    private Vector3 lastPosition = Vector3.positiveInfinity;

    public void SpawnPickUp()
    {
        if (currentPickUp != null) return;

        Vector3 newPos;
        int attempts = 0;

        do
        {
            newPos = new Vector3(
                Random.Range(minGrid.x, maxGrid.x + 1),
                Random.Range(minGrid.y, maxGrid.y + 1),
                0
            );

            attempts++;
            if (attempts > 100) break; // защита от зацикливания
        }
        while (lastPosition != Vector3.positiveInfinity &&
               (Vector3.Distance(newPos, lastPosition) < minDistance || Vector3.Distance(newPos, lastPosition) > maxDistance));

        currentPickUp = Instantiate(pickUpPrefab, newPos, Quaternion.identity);
        lastPosition = newPos;
    }

    public void ClearPickUp()
    {
        currentPickUp = null;
    }
}
