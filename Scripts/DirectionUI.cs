using TMPro;
using UnityEngine;

public class DirectionUI : MonoBehaviour
{
    public PlayerController player;

    public TMP_Text upText;
    public TMP_Text downText;
    public TMP_Text leftText;
    public TMP_Text rightText;

    void Update()
    {
        foreach (var entry in player.keyMapping)
        {
            if (entry.Value == Vector3.up) upText.text = entry.Key.ToString();
            if (entry.Value == Vector3.down) downText.text = entry.Key.ToString();
            if (entry.Value == Vector3.left) leftText.text = entry.Key.ToString();
            if (entry.Value == Vector3.right) rightText.text = entry.Key.ToString();
        }
    }
}
