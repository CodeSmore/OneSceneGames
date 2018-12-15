using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour {

    public Text currencyText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateUI();
	}

    void UpdateUI()
    {
        currencyText.text = StatsController.currency.ToString();
    }
}
