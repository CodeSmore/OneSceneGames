using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour {
    public Image energyWheel;
    public Text energyPercent;

    private float timer = 0;
    private float secondsPerCycle = 10;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= secondsPerCycle)
        {
            StatsController.energy += StatsController.energyRegen;
            Mathf.Clamp(StatsController.energy, 0, StatsController.maxEnergy);
            timer = 0;
        }

        UpdateUI();
	}

    void UpdateUI()
    {
        Mathf.Clamp(StatsController.energy, 0, StatsController.maxEnergy);

        energyWheel.fillAmount = timer / secondsPerCycle;
        energyPercent.text = StatsController.energy.ToString() + "/" + StatsController.maxEnergy.ToString();
    }
}
