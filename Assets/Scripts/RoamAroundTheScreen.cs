using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamAroundTheScreen : MonoBehaviour
{
    public float speed;

    private bool currentlyIdle = true;

    private Vector3 minPos;
    private Vector3 maxPos;
    
    // Start is called before the first frame update
    void Start()
    {
        minPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (currentlyIdle) {
            currentlyIdle = false;
        }
    }
}
