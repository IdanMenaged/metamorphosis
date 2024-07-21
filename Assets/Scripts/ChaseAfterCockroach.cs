using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAfterCockroach : MonoBehaviour
{
    public Transform cockroach;
    public float speed;

    public bool startChase = false;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startChase) {
            anim.enabled = false;
            transform.position = Vector3.MoveTowards(transform.position, cockroach.position, speed * Time.deltaTime);
        }
    }
}
