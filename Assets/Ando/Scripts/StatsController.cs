using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour {

    public static int currency { get; set; }
    public static int energy { get; set; }
    public static int maxEnergy { get; set; }
    public static int energyRegen { get; set; }

    private void Awake()
    {
        currency = 0;
        energy = 0;
        maxEnergy = 100;
        energyRegen = 1;
    }
}
