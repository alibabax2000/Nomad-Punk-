using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;      // игрок
    public float smoothSpeed = 0.125f;
    public Vector3 offset;        // если хочешь сместить камеру

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = new Vector3(
            smoothedPosition.x,
            smoothedPosition.y,
            transform.position.z // сохраняем z камеры
        );
    }
}
