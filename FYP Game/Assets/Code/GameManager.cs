using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] TMP_Text countText;
    [SerializeField] TMP_Text incomeText;
    [SerializeField] Upgrades[] upgrades;


    float count = 0;
    int count2 = 0;
    float nextTimecheck = 1;
    float lastIncomeValue = 0;
    float sum = 0;
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
        sum = 0f;
        foreach (var upgrade in upgrades)
        {
            sum += upgrade.CalculateIncomePerSecond();
        }
        lastIncomeValue = sum;
        count += sum;

        UpdateUI();
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
        count++;
        Debug.Log(count);
        UpdateUI();
        
    }
    

    void UpdateUI()
    {
        countText.text = Mathf.RoundToInt(count).ToString();
        //countText.text = "" + count;
        
        incomeText.text = lastIncomeValue.ToString() + "/s";
    }

}
