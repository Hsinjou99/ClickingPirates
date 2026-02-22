using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [Header("Stats")]
    public double brainPower = 0;
    public int clickStrength = 1;
    public double bpPerSecond = 0;
    public float multiplier = 1f;
    

    [Header("Objects")]
    public TextMeshProUGUI bpText;
    public GameObject brainPowerTextObject;
    public GameObject upgradeMenu;

    [Header("Upgrades")]
    public TextMeshProUGUI upgrade1Text;
    public TextMeshProUGUI upgrade2Text;
    public TextMeshProUGUI upgrade3Text;
    public TextMeshProUGUI upgrade4Text;

    [Header("Upgrade Costs")]
    public double upgrade1Cost = 5;
    public double upgrade2Cost = 25;
    public double upgrade3Cost = 50;
    public double upgrade4Cost = 200;

    [Header("Settings")]
    public double menuThreshold = 15;
    public double textThreshold = 10;

    
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "ToolsEra")
        {
            brainPower = 0;
            clickStrength = 100;
            bpPerSecond = 0;
            multiplier = 1f;

            upgrade1Cost = 500;
            upgrade2Cost = 2500;
            upgrade3Cost = 5000;
            upgrade4Cost = 20000;

            menuThreshold = 0;
            textThreshold = 0;
        }
        else if (SceneManager.GetActiveScene().name == "AgriculturalEra")
        {
            brainPower = 0;
            clickStrength = 1000;
            bpPerSecond = 0;
            multiplier = 1f;

            upgrade1Cost = 5000;
            upgrade2Cost = 25000;
            upgrade3Cost = 50000;
            upgrade4Cost = 200000;

            menuThreshold = 0;
            textThreshold = 0;
        }
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Game")
        {
            brainPowerTextObject.SetActive(false);
            upgradeMenu.SetActive(false);
        }
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

    public void TransitionToNextEra()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Game")
        {
            SceneManager.LoadScene("ToolsEra");
        }
        else if (currentScene == "ToolsEra")
        {
            SceneManager.LoadScene("AgriculturalEra");
        }
    }

    public void ClickAction()
    {
        brainPower += clickStrength * multiplier;
        UpdateUI();
        CheckThresholds();
    }

    // Upgrade 1 function: increase click strength
    public void BuyUpgrade1()
    {
        if (brainPower >= upgrade1Cost)
        {
            brainPower -= upgrade1Cost;
            clickStrength++;
            upgrade1Cost *= 1.5f;
            UpdateUI();
        }
    }

    // Upgrade 2 function: passive income
    public void BuyUpgrade2()
    {
        if (brainPower >= upgrade2Cost)
        {
            brainPower -= upgrade2Cost;
            bpPerSecond += 2;
            upgrade2Cost *= 3;
            UpdateUI();
        }
    }

    public void BuyUpgrade3()
    {
        if (brainPower >= upgrade3Cost)
        {
            brainPower -= upgrade3Cost;
            multiplier += 0.5f;
            upgrade3Cost *= 4;
            UpdateUI();
        }
    }

    // Upgrade 4 function: cut costs
    public void BuyUpgrade4()
    {
        if (brainPower >= upgrade4Cost)
        {
            brainPower -= upgrade4Cost;
            upgrade1Cost /= 2;
            upgrade2Cost /= 2;
            upgrade3Cost /= 2;
            upgrade4Cost = double.PositiveInfinity; // Make it unpurchasable after one purchase
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

        if (upgrade1Text) upgrade1Text.text = $"Upgrade 1 ({upgrade1Cost.ToString("F0")} BP)";
        if (upgrade2Text) upgrade2Text.text = $"Upgrade 2 ({upgrade2Cost.ToString("F0")} BP)";
        if (upgrade3Text) upgrade3Text.text = $"Upgrade 3 ({upgrade3Cost.ToString("F0")} BP)";
        if (upgrade4Text) upgrade4Text.text = $"Upgrade 4 ({upgrade4Cost.ToString("F0")} BP)";
    }
}

