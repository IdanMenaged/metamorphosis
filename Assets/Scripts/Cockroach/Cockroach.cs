using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cockroach : MonoBehaviour
{
    public Sprite deadSprite;

    private SceneTransition sceneTransition;
    private Movement movement;
    private SpriteRenderer renderer;

    private void Start() {
        sceneTransition = GameObject.Find("Scene Transition").GetComponent<SceneTransition>();
        movement = GetComponent<Movement>();
        renderer = GetComponent<SpriteRenderer>();
    }

    public void Die() {
        movement.enabled = false;
        renderer.sprite = deadSprite;
        sceneTransition.AnimationAndRestart();
    }
}
