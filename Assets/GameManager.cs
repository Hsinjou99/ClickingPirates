using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Stats")]
    public double brainPower = 0;
    public double bpPerSecond = 0;
    public float multiplier = 1f;

    [Header("Objects")]
    public TextMeshProUGUI bpText;
    public GameObject brainPowerTextObject;
    public GameObject upgradeMenu;

    [Header("Upgrades")]
    public TextMeshProUGUI upgrade2Text;
    public TextMeshProUGUI upgrade3Text;
    public TextMeshProUGUI upgrade4Text;

    [Header("Upgrade Costs")]
    public double upgrade2Cost = 10;
    public double upgrade3Cost = 50;
    public double upgrade4Cost = 200;

    [Header("Settings")]
    public double menuThreshold = 15;
    public double textThreshold = 10;

    public int clickStrength = 1;
    void Start()
    {
        brainPowerTextObject.SetActive(false);
        upgradeMenu.SetActive(false);
        UpdateUI();
    }

    void Update()
    {
        if (bpPerSecond > 0)
        {
            brainPower += bpPerSecond * multiplier * Time.deltaTime;
            UpdateUI();
            CheckThresholds();
        }
    }
    public void ClickAction()
    {
        brainPower += clickStrength;
        UpdateUI();
        CheckThresholds();
    }

    // Upgrade 2 function: passive income
    public void BuyUpgrade2()
    {
        if (brainPower >= upgrade2Cost)
        {
            brainPower -= upgrade2Cost;
            bpPerSecond += 2;
            upgrade2Cost *= 2;
            UpdateUI();
        }
    }

    public void BuyUpgrade3()
    {
        if (brainPower >= upgrade3Cost)
        {
            brainPower -= upgrade3Cost;
            multiplier += 0.5f;
            upgrade3Cost *= 3;
            UpdateUI();
        }
    }

    void CheckThresholds()
    {
        if (brainPower >= textThreshold)
        {
            brainPowerTextObject.SetActive(true);
        }
        if (brainPower >= menuThreshold)
        {
            upgradeMenu.SetActive(true);
        }
    }
    public void UpdateUI()
    {
        bpText.text = "Brain Power: " + brainPower.ToString("F0");

        if (upgrade2Text) upgrade2Text.text = $"Upgrade 2 ({upgrade2Cost.ToString("F0")} BP)";
        if (upgrade3Text) upgrade3Text.text = $"Upgrade 3 ({upgrade3Cost.ToString("F0")} BP)";
    }
}

