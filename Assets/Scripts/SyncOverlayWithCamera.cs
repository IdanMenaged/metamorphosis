using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncOverlayWithCamera : MonoBehaviour
{
    public float verticalOffset = -12.25f;

    private GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + verticalOffset, 0);
    }
}
