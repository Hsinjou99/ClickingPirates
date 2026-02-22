using UnityEngine;
using TMPro;

public class ClickerUpgrade : MonoBehaviour
{
    [Header("Components")]
    public TMP_Text priceText;
    public TMP_Text strengthInfoText;

    [Header("Managers")]
    public GameManager gameManager;

    public int price = 10;
    public float priceMultiplier;

    int level = 0;

    public void Start()
    {
        UpdateUI();
    }

    public void ClickAction()
    {
        int newPrice = CalculatePrice();
        if (gameManager.brainPower >= newPrice)
        {
            gameManager.brainPower -= newPrice;
            level++;
            gameManager.clickStrength++;
            price = newPrice;
            UpdateUI();
            gameManager.UpdateUI();
        }
    }
    void UpdateUI()
    {
        priceText.text = CalculatePrice().ToString();
        strengthInfoText.text = "Strength: +" + level.ToString();
    }

    int CalculatePrice()
    {
        return (int) (price * 1.2);
    }
}

