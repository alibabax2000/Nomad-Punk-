using UnityEngine;
using TMPro; // если используешь TextMeshPro

public class TextTrigger : MonoBehaviour
{
    public TMP_Text textComponent; // текст на экране
    public ImageChanger imageChanger; // ссылка на скрипт ImageChanger

    public string triggerText = "ѕомен€ть картинку"; // текст, после которого мен€ем картинку

    void Update()
    {
        if (textComponent.text == triggerText)
        {
            imageChanger.ChangeImage();
        }
    }
}
