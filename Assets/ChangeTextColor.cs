using TMPro;
using UnityEngine;

public class ChangeTextColor : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;

    void Start()
    {
        text.color = Color.white;
        text1.color = Color.white;
        text2.color = Color.white;
        text3.color = Color.white;
        text4.color = Color.white;
    }
}