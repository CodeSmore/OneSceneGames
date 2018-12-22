using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTGetEnergy : MonoBehaviour {

    public bool Enabled = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (Enabled)
        {
            StatsController.energy += 100;
            StatsController.currency += 10000;
        }   
    }
}
