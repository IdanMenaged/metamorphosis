using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerAndDisappearOnMovement : MonoBehaviour
{
    public float interval = .5f;

    private SpriteRenderer renderer;
    private bool isVisible = true;
    private Color visibleColor = new Color(1, 1, 1, 1);
    private Color invisibleColor = new Color(1, 1, 1, 0);
    private float timer = 0;
    private bool moved = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        // check player movement
        if (!moved) {
            timer += Time.deltaTime;
            if (timer >= interval) {
                // change opacity
                if (isVisible) {
                    isVisible = false;
                    renderer.color = invisibleColor;
                }
                else {
                    isVisible = true;
                    renderer.color = visibleColor;
                }

                // reset timer
                timer = 0;
            }

            // stop on movement
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
                renderer.color = invisibleColor;
                moved = false;
            }
        }
    }
}
