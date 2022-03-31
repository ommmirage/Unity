using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy1))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0, 10)] float speed = 5f;
    const float speedMultiplicator = 0.000001f;

    Enemy1 enemy;
    GridManager gridManager;
    Pathfinder pathfinder;
    List<Node> path = new List<Node>();

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Awake() 
    {
        enemy = FindObjectOfType<Enemy1>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void FindPath()
    {
        path.Clear();
        path = pathfinder.GetNewPath();        
    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    IEnumerator FollowPath()
    {
        for (int i = 0; i < path.Count; i++)
        {
            float travelPercent = 0;
            Vector3 startPos = transform.position;
            Vector3 endPos = gridManager.GetPositionFromCoordinates(path[i].coordinates);

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
