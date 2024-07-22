using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = .25f;

    private Vector3 currentVelocity;

    private void LateUpdate() {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position, 
            ref currentVelocity, 
            smoothTime
        );
    }
}
