using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text countText;
    public TMP_Text incomeInfoText;
    public TMP_Text percentageInfoText;
    public int startNumber = 5;
    public float upgradeNumberMultiplier;
    public float NumberPerUpgrade = 1f;
    [Header("Managers")]
    public GameManager gameManager;
    [Header("Generator values")]
    int level = 0;

    private void Awake()
    {
        Debug.Log("countText = " + countText);
        Debug.Log("incomeInfoText = " + incomeInfoText);
        Debug.Log("gameManager = " + gameManager);
    }

    private void Start()
    {
       UpdateUI();
    }
    public void ClickAction()
    {
        Canvas c = FindAnyObjectByType<Canvas>();
       

        //Canvas c = GetComponentInParent<Canvas>();
        GameManager gm = c.GetComponent<GameManager>();

        int price = CalculateNumber();
        bool buySuccess = gm.buyAction(price); // gameManager.buyAction(price);
        if (buySuccess)
        {
            level++;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        countText.text = CalculateNumber().ToString();
        percentageInfoText.text = incomeInfoText.text;
        incomeInfoText.text = level.ToString() + " x " + NumberPerUpgrade + "/s";

        //if(time_since_last_update > 1000)
        //{
        //    Canvas c = FindAnyObjectByType<Canvas>();

        //    GameManager gm = c.GetComponent<GameManager>();

        //    gm.count = gm.count + level;

        //    time_since_last_updte = now;
        //}
        // 5 x 0.5/s
    }

    int CalculateNumber()
    {
        int number = Mathf.RoundToInt(startNumber * Mathf.Pow(upgradeNumberMultiplier, level));
        Debug.Log(number);
        return number;
    }
    public float CalculateIncomePerSecond()
    {
        return NumberPerUpgrade * level;
    }
}
