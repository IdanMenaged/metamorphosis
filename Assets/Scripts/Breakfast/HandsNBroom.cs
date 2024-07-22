using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsNBroom : MonoBehaviour
{
    public SceneTransition sceneTransition;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Cockroach>().Die();
        }
    }
}
