using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [Header("Stats")]
    public double brainPower = 0;

    [Header("Objects")]
    public TextMeshProUGUI bpText;
    public GameObject brainPowerTextObject;
    public GameObject upgradeMenu;

    [Header("Settings")]
    public double menuThreshold = 15;
    public double textThreshold = 10;

    void Start()
    {
        brainPowerTextObject.SetActive(false);
        upgradeMenu.SetActive(false);
        UpdateUI();
    }

    public void ClickAction()
    {
        brainPower += 1;
        UpdateUI();
        CheckThresholds();
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
    }
}
