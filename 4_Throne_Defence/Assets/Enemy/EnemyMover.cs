using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0, 10)] float speed = 5f;
    const float speedMultiplicator = 0.000001f;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPos = transform.position;
            Vector3 endPos = waypoint.transform.position;
            float travelPercent = 0;

            transform.LookAt(endPos);

            while (travelPercent < 1f)
            {
                transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
                travelPercent += speed * speedMultiplicator / Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
