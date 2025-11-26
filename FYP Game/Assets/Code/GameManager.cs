using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using TMPro

public class GameManager : MonoBehaviour
{
    public TMP_Text countText;

    int count = 0;
    void ClickAction()
    {
        count++;
        UpdateUI();
    }

    void UpdateUI()
    {
        countText.text = count.ToString(); 
    }

}
