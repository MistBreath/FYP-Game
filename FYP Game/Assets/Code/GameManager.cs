using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text countText;

    public int count = 0;
    int count2 = 0;
    float nextTimecheck = 1;
    void Start()
    {
        UpdateUI();
    }
    void Update()
    {
        if (nextTimecheck < Time.timeSinceLevelLoad)
        {
            IdleCalculate();
            nextTimecheck = Time.timeSinceLevelLoad + 1f;
        }
        
        
    }
    void IdleCalculate()
    {

    }
    public bool buyAction(int cost)
    {
        if (count >= cost)
        {
            count -= cost;
            UpdateUI();
            return true;
        }
        return false;
    }
    public void ClickAction()
    {
        Debug.Log("CLICK!!!!");
        count++;
        Debug.Log(count);
        UpdateUI();
        
    }
    

    void UpdateUI()
    {
        countText.text = count.ToString(); 
    }

}
