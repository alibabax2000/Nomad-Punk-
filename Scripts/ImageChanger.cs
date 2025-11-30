using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Image imageComponent; // UI Image
    public Sprite newSprite;     // картинка, на которую мен€ем

    // ¬ызываем этот метод, когда нужно помен€ть картинку
    public void ChangeImage()
    {
        if (imageComponent != null && newSprite != null)
        {
            imageComponent.sprite = newSprite;
        }
    }
}
