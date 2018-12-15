using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountController : MonoBehaviour {

    public static Text counterText;
    private static int globalCount = 0;

    private void Start()
    {
        counterText = GameObject.Find("TouchCountText").GetComponent<Text>();

        UpdateCounterUI();
    }

    public static void UpdateCounter(int count)
    {
        globalCount += count;

        UpdateCounterUI();
    }

    public static void UpdateCounterUI()
    {
        counterText.text = globalCount.ToString();
    }
}
