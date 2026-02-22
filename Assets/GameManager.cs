using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Stats")]
    // currency
    public double brainPower = 0;
    // passive income value
    public double bpPerSecond = 0;
    // upgrade multipliers
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
    public double upgrade4Cost = 100;

    [Header("Settings")]
    public double menuThreshold = 15;
    public double textThreshold = 10;

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
            brainPower += bpPerSecond * Time.deltaTime;
            UpdateUI();
            CheckThresholds();
        }
    }

    // clicking the rock
    public void ClickAction()
    {
        brainPower += 1;
        UpdateUI();
        CheckThresholds();
    }

    // upgrade buttons

    // upgrade 2: passive income
    public void BuyUpgrade2()
    {
        if (brainPower >= upgrade2Cost)
        {
            brainPower -= upgrade2Cost;
            bpPerSecond += 2;
            upgrade2Cost *= 1.4;
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
    void UpdateUI()
    {
        bpText.text = "Brain Power: " + brainPower.ToString("F0");

        // update upgrade buttons
        if (upgrade2Text) upgrade2Text.text = $"Upgrade 2 ({upgrade2Cost.ToString("F0")} BP)";
    }
}
