using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothTime = .25f;
    public float startFollowingAfter; // seconds
    public float stopFollowingAt; // x position
    public Vector3 endPos;

    private Vector3 currentVelocity;
    private bool following = false;

    private void Start() {
        StartCoroutine(WaitAndFollow());
    }

    private void LateUpdate() {
        if (following) {
            transform.position = Vector3.SmoothDamp(
                transform.position,
                target.position + offset, 
                ref currentVelocity, 
                smoothTime
            );
        }

        if (target.position.x >= stopFollowingAt) {
            following = false;
            transform.position = Vector3.SmoothDamp(
                transform.position,
                endPos, 
                ref currentVelocity, 
                smoothTime
            );
        }
    }

    private IEnumerator WaitAndFollow() {
        yield return new WaitForSeconds(startFollowingAfter);
        following = true;
    }
}
