using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour {

    public static int currency { get; set; }
    public static int energy { get; set; }

    private void Start()
    {
        currency = 100;
        energy = 10;
    }
}
