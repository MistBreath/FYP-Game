using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text countText;

    int count = 0;
    void Start()
    {
        UpdateUI();
    }
    public void ClickAction()
    {
        Debug.Log("CLICK!!!!");
        count++;
        UpdateUI();
        
    }
    

    void UpdateUI()
    {
        countText.text = count.ToString(); 
    }

}
