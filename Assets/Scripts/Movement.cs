using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    
    private AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (Input.GetAxisRaw("Vertical") * transform.up + Input.GetAxisRaw("Horizontal") * transform.right).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (direction == Vector3.zero) {
            sfx.Stop();
        }
        else if (!sfx.isPlaying) {
            sfx.Play();
        }
    }
}
