using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHint : MonoBehaviour
{
    private GameObject hint;
    // Start is called before the first frame update
    void Start()
    {
        hint = transform.Find("Hint").gameObject;
        hint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("door");
        hint.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        hint.SetActive(false);
    }
}
