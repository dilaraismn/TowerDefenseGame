using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] private float checkTime = .5f;
    public List<EnemyController> enemiesInRange = new List<EnemyController>();
    private Collider[] collidersInRange;
    public float range = 3;
    private float checkCounter;
    
    void Start()
    {
        checkCounter = checkTime;
    }

    void Update()
    {
        checkCounter -= Time.deltaTime;
        
        if (checkCounter <= 0)
        {
            checkCounter = checkTime;
            collidersInRange = Physics.OverlapSphere(transform.position, range, whatIsEnemy);
        
            //can be expensive in terms of data usage so we can check and do in time range
            enemiesInRange.Clear();
            foreach (Collider col in collidersInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }
        }
    }
}
