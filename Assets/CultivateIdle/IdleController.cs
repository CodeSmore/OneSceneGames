using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleController : MonoBehaviour {

    public float idleTimeLimit = 5;

    public Image loadingBarImage;
    public Text levelText, quantityText;

    private float timer = 0;
    private int level = 1;
    private int quantity = 0;

	// Use this for initialization
	void Start () {
        UpdateUI();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTimer();

        UpdateIdleBar();
	}

    void UpdateTimer()
    {
        if (timer >= idleTimeLimit)
        {
            timer = 0;
            quantity += level;
            UpdateUI();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void UpdateUI()
    {
        levelText.text = "Lv." + level.ToString();
        quantityText.text = quantity.ToString();
    }

    void UpdateIdleBar()
    {
        loadingBarImage.fillAmount = timer / idleTimeLimit;
    }

    public void UpgradeLevel()
    {
        level++;
        UpdateUI();
    }
}
