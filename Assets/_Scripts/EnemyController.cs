using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Path _path;
    private int currentPoint;
    private bool reachedEnd;
    
    void Start()
    {
        _path = FindObjectOfType<Path>();
    }

    void Update()
    {
        if (reachedEnd) return;
        transform.LookAt(_path.pathPoints[currentPoint]);
        
        transform.position = Vector3.MoveTowards(transform.position, _path.pathPoints[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _path.pathPoints[currentPoint].position) < 0.1f)
        {
            currentPoint = currentPoint + 1;
            if (currentPoint >= _path.pathPoints.Length)
            {
                reachedEnd = true;
            }
        }
    }
}
