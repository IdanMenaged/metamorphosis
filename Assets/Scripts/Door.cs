using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{
    public InputActionAsset actions;

    private bool inRange = false;
    private Animator anim;
    private AudioSource sfx;
    private GameObject hint;
    
    // Start is called before the first frame update
    void Start()
    {
        actions.FindActionMap("Main").FindAction("Interact").performed += OnInteract;

        anim = GetComponent<Animator>();
        anim.enabled = true;

        sfx = transform.Find("SFX").GetComponent<AudioSource>();
        hint = transform.Find("Hint").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnInteract(InputAction.CallbackContext context) {
        if (inRange) {
            sfx.Play();
            anim.SetTrigger("Door Opening");
            Destroy(hint);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        inRange = false;
    }

    private void OnEnable() {
        actions.FindActionMap("Main").Enable();
    }

    private void OnDisable() {
        actions.FindActionMap("Main").Disable();
    }
}
