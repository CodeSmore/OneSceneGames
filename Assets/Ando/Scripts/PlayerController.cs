using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Button MaxEnergyUpgradeButton;
    public Button EnergyGainUpgradeButton;

    public Text maxEnergyText;
    public Text energyGainText;
    public Text maxEnergyUpgradeCostText;
    public Text energyGainUpgradeCostText;

    private int baseMaxEnergyUpgradeCost = 10;
    private int baseEnergyRegenUpgradeCost = 10;

	// Use this for initialization
	void Start () {
        MaxEnergyUpgradeButton.onClick.AddListener(UpgradeMaxEnergy);
        EnergyGainUpgradeButton.onClick.AddListener(UpgradeEnergyGain);

        UpdateUI();
	}
	
    void UpdateUI()
    {
        maxEnergyText.text = StatsController.maxEnergy.ToString();
        energyGainText.text = StatsController.energyRegen.ToString() + "energy / 10s";

        maxEnergyUpgradeCostText.text = (StatsController.maxEnergy * baseMaxEnergyUpgradeCost).ToString();
        energyGainUpgradeCostText.text = (StatsController.energyRegen * baseEnergyRegenUpgradeCost).ToString();
    }

    void UpgradeMaxEnergy()
    {
        if (StatsController.currency >= (StatsController.maxEnergy * baseMaxEnergyUpgradeCost))
        {
            StatsController.currency -= StatsController.maxEnergy * baseMaxEnergyUpgradeCost;
            StatsController.maxEnergy += 10;

            UpdateUI();
        }
    }

    void UpgradeEnergyGain()
    {
        if (StatsController.currency >= (StatsController.energyRegen * baseEnergyRegenUpgradeCost))
        {
            StatsController.currency -= StatsController.energyRegen * baseEnergyRegenUpgradeCost;
            StatsController.energyRegen += 1;

            UpdateUI();
        }

    }
}
