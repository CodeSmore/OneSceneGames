using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupportController : MonoBehaviour {

    public Support[] supports;

    // Use this for initialization
    void Start () {
        UpdateSupportUI();	
	}

    public Support[] GetAllSupports()
    {
        return supports;
    }

    public void SupportUpgrade(int supportNum)
    {
        int index = supportNum - 1;

        int energyUse = Mathf.Clamp(StatsController.energy, 0, supports[index].GetUpgradeCost());

        StatsController.energy -= energyUse;
        supports[index].CurrentEnergy += energyUse;

        if (supports[index].GetUpgradeCost() == 0)
        {
            supports[index].LevelUp();
        }

        UpdateSupportUI();
    }

    void UpdateSupportUI()
    {
        foreach (Support support in supports)
        {
            support.levelText.text = support.Level.ToString();
            support.powerText.text = support.CurrentPower.ToString();
            support.upgradeCostText.text = support.GetUpgradeCost().ToString();
        }
    }
}

[System.Serializable]
public class Support
{
    public string Name;
    public int Level;
    public int BasePower;
    [HideInInspector]
    public int CurrentPower;
    public int CurrentEnergy;
    public Type Type;

    // UI elements
    public Text levelText;
    public Text powerText;
    public Text upgradeCostText;

    // states whether support is assigned already
    public bool Assigned;

    public void LevelUp()
    {
        Level++;
        CurrentPower = BasePower + Level;
    }

    public int GetUpgradeCost()
    {
        var EnergyToLevelUp = Level * 13 * BasePower;

        var upgradeCost = EnergyToLevelUp - CurrentEnergy;

        return upgradeCost;
    }
}

public enum Type
{
    Enhancement, Transmision, Psychic
};
