using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    private float timer = 0;

    public float secondsBetweenSpawns = 0.5f;

    private float xMin, xMax, yMin, yMax;

    public GameObject target;

	// Use this for initialization
	void Start () {
        SetBoundsForTargets();
	}
	
	// Update is called once per frame
	void Update () {
        HandleTimer();
	}

    void HandleTimer()
    {
        timer += Time.deltaTime;

        if (timer >= secondsBetweenSpawns)
        {
            timer = 0;
            Vector3 spawnPosition = GetSpawnPosition();
            Instantiate(target, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetSpawnPosition()
    {
        float newX = Random.Range(xMin, xMax);
        float newY = Random.Range(yMin, yMax);

        Vector3 spawnPosition = new Vector3(newX, newY, 0);

        return spawnPosition;
    }

    void SetBoundsForTargets()
    {
        var vertExtent = Camera.main.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        xMin = 0 - horzExtent / 2;
        xMax = horzExtent / 2;

        yMin = 0 - vertExtent / 2;
        yMax = vertExtent / 2;
    }
}
