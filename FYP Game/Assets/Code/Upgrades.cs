using TMPro;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text countText;
    public TMP_Text incomeInfoText;
    public int startNumber = 15;
    public float upgradeNumberMultiplier;
    public float NumberPerUpgrade = 0.1f;

    int level = 0;

    private void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        countText.text = CalculateNumber().ToString();
        incomeInfoText.text = level.ToString() + " x " + NumberPerUpgrade + "/s";
        // 5 x 0.5/s
    }

    int CalculateNumber()
    {
        int number = Mathf.RoundToInt(startNumber * Mathf.Pow(upgradeNumberMultiplier, level));
        return number;
    }
    public float CalculateIncomePerSecond()
    {
        return NumberPerUpgrade * level;
    }
}
