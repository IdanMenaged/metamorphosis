using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }
    public void AnimationAndTransition() {
        anim.SetTrigger("End Of Scene");
    }

    private void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
