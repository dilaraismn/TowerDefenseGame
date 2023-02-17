using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] Transform pivot, model, target;
    [HideInInspector] public Vector3 targetPoint;
    [SerializeField] private float moveSpeed;
    
    void Start()
    {
        Vector3 startPos = transform.position;
        
        targetPoint = target.position;

        Vector3 centerPosition = (transform.position + targetPoint) * 0.5f;
        transform.position = centerPosition;

        transform.right = targetPoint - transform.position;

        model.transform.position = startPos;
    }

    void Update()
    {
        pivot.localRotation =
            Quaternion.RotateTowards(pivot.localRotation, Quaternion.Euler(0, 0, 180), moveSpeed * Time.deltaTime);
        
        model.rotation = Quaternion.identity;
    }
}
