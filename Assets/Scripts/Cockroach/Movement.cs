using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    
    private AudioSource sfx;
    private Vector2 minPos;
    private Vector2 maxPos;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (Input.GetAxisRaw("Vertical") * transform.up + Input.GetAxisRaw("Horizontal") * transform.right).normalized;

        // recalculate bounds since camera is moving
        minPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // check for out of bounds
        Vector3 newPos = transform.position + direction * speed * Time.deltaTime;
        if (newPos.x >= minPos.x && newPos.x <= maxPos.x && newPos.y >= minPos.y && newPos.y <= maxPos.y) {
            transform.position = newPos;
        }

        // sfx
        if (direction == Vector3.zero) {
            sfx.Stop();
        }
        else if (!sfx.isPlaying) {
            sfx.Play();
        }
    }
}
