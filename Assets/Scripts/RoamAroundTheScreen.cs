using System.Collections;
using UnityEngine;

public class RoamAroundTheScreen : MonoBehaviour
{
    public float speed;
    public float stayInPlaceTime;
    public float startDelay;

    private Vector3 minPos;
    private Vector3 maxPos;
    private Vector3 target;
    private bool currentlyIdle = true;
    
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
            currentlyIdle = true;
            StartCoroutine(NewTarget());
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }

    IEnumerator NewTarget() {
        yield return new WaitForSeconds(stayInPlaceTime);
        if (currentlyIdle) {
            currentlyIdle = false;
            target = RandomPos();
        }
    }

    IEnumerator InitialTarget() {
        yield return new WaitForSeconds(startDelay);
        target = RandomPos();
    }

    Vector3 RandomPos() {
        Vector3 candidate = new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0);
        return candidate;
    }
}
