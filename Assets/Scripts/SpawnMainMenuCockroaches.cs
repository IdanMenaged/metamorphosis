using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMainMenuCockroaches : MonoBehaviour
{
    public int amount;
    public GameObject prefab;
    public float minSpeed;
    public float maxSpeed;
    public float minStayInPlaceTime;
    public float maxStayInPlaceTime;
    public float minStartDelay;
    public float maxStartDelay;

    private System.Tuple<Vector3, Vector3> inclusivePositionRange;

    // Start is called before the first frame update
    void Start()
    {
        inclusivePositionRange = System.Tuple.Create(
            Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)), 
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0))
        );

        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(inclusivePositionRange.Item1.x, inclusivePositionRange.Item2.x), 
                Random.Range(inclusivePositionRange.Item1.y, inclusivePositionRange.Item2.y), 
                0
            );

            GameObject cockroach = Instantiate(prefab, position, Quaternion.identity);
            RoamAroundTheScreen roamingParams = cockroach.GetComponent<RoamAroundTheScreen>();
            roamingParams.speed = Random.Range(minSpeed, maxSpeed);
            roamingParams.stayInPlaceTime = Random.Range(minStayInPlaceTime, maxStayInPlaceTime);
            roamingParams.startDelay = Random.Range(minStartDelay, maxStartDelay);
        }
    }
}
