using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy1))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0, 10)] float speed = 5f;

    Enemy1 enemy;

    const float speedMultiplicator = 0.000001f;

    private void Start() 
    {
        enemy = FindObjectOfType<Enemy1>();
    }

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach(Transform child in parent.transform)
        {
            Tile waypoint = child.GetComponent<Tile>();

            if (waypoint != null)
            {
                path.Add(child.GetComponent<Tile>());
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator FollowPath()
    {
        foreach (Tile waypoint in path)
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

        FinishPath();
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
}
