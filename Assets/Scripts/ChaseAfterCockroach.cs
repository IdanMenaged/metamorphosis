using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAfterCockroach : MonoBehaviour
{
    public Transform cockroach;
    public Sprite sprite;
    public float speed;

    private bool chasing = false;

    private Animator anim;
    private SpriteRenderer renderer;
    private GameObject hands;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        hands = GameObject.Find("Hands & Broom");
    }

    // Update is called once per frame
    void Update()
    {
        if (chasing) {
            transform.position = Vector3.MoveTowards(transform.position, cockroach.position, speed * Time.deltaTime);
        }
    }

    public void StartChase() {
        renderer.sprite = sprite;
        anim.enabled = false;
        hands.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1); // inc opacity
        chasing = true;
    }
}
