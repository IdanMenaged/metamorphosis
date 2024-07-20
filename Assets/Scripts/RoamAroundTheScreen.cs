using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamAroundTheScreen : MonoBehaviour
{
    public float speed;
    public float stayInPlaceTime;
    public float startDelay;

    private Vector3 minPos;
    private Vector3 maxPos;
    private Vector3 target;
    
    // Start is called before the first frame update
    void Start()
    {
        minPos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        maxPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        target = transform.position;
        StartCoroutine(InitialTarget());
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == target) {
            StartCoroutine(NewTarget());
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    IEnumerator NewTarget() {
        yield return new WaitForSeconds(stayInPlaceTime);
        target = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0);
    }

    IEnumerator InitialTarget() {
        yield return new WaitForSeconds(startDelay);
        target = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0);
    }
}
