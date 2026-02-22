using UnityEngine;
using TMPro;

public class ClickerUpgrade : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public TMP_Text strengthInfoText;


    public int startPrice = 10;
    public float priceMultiplier;

    int level = 0;

    public void Start()
    {
        UpdateUI();
    }
    void UpdateUI()
    {
        priceText.text = CalculatePrice().ToString();
        strengthInfoText.text = (level + 1).ToString();
    }

    int CalculatePrice()
    {
        return Mathf.RoundToInt(startPrice * Mathf.Pow(priceMultiplier, level));
    }
}

