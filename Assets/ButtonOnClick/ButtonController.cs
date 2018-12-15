using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button theButton;
    private RectTransform buttonRectTransform;

    // Use this for initialization
    void Start()
    {
        theButton.onClick.AddListener(TaskOnClickMethod);

        buttonRectTransform = theButton.GetComponent<RectTransform>();
    }

    void TaskOnClickMethod()
    {
        Debug.Log("Clicked you fucker");

        float x = buttonRectTransform.sizeDelta.x;
        float y = buttonRectTransform.sizeDelta.y;

        theButton.GetComponent<RectTransform>().sizeDelta = new Vector2(x * 0.8f, y * 0.8f);
    }
}
