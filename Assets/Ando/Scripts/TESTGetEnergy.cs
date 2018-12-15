using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTGetEnergy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        StatsController.energy += 100;
    }
}
