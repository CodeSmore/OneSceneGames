using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float lifetime = 3;

    private float timer = 0;

    private float xScale, yScale;
	// Use this for initialization
	void Start () {
        xScale = gameObject.transform.localScale.x;
        yScale = gameObject.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
        HandleTimer();
	}

    void HandleTimer()
    {
        timer += Time.deltaTime;

        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
        else
        {
            // change scale of gameObject based on timer : lifetime ratio
            gameObject.transform.localScale = new Vector3(xScale - timer / lifetime, yScale - timer / lifetime, gameObject.transform.localScale.z);
        }
    }

    private void OnMouseDown()
    {
        CountController.UpdateCounter(1);
        Destroy(gameObject);
    }
}
