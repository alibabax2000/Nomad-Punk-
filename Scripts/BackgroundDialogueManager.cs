using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // для смены сцены

[System.Serializable]
public class DialogueEntry
{
    public string text;         // текст диалога
    public Sprite background;   // фон для этого текста
    public float duration;      // через сколько секунд сменится на следующий
}

public class BackgroundDialogueManager : MonoBehaviour
{
    public Image backgroundImage;       // UI Image для фона
    public TMP_Text dialogueText;       // TextMeshPro
    public List<DialogueEntry> dialogueEntries; // список диалогов

    private int currentIndex = 0;

    void Start()
    {
        if (dialogueEntries.Count > 0)
        {
            StartCoroutine(PlayDialogue());
        }
    }

    IEnumerator PlayDialogue()
    {
        while (currentIndex < dialogueEntries.Count)
        {
            DialogueEntry entry = dialogueEntries[currentIndex];

            // Меняем текст и фон
            dialogueText.text = entry.text;
            backgroundImage.sprite = entry.background;

            // Ждём заданное время
            yield return new WaitForSeconds(entry.duration);

            currentIndex++;
        }

        // После последнего диалога загружаем следующую сцену по Build Index
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Проверка, чтобы индекс не выходил за пределы
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Это последняя сцена в Build Settings!");
        }
    }
}
