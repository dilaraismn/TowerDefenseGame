using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed, timeBetweenAttacks, damagePerAttack;

    public float speedMod = 1;
        
    private Path _path;
    private Castle _castle;
    
    private float attackCount;
    private int currentPoint, selectedAttackPoint;
    private bool reachedEnd;
    
    void Start()
    {
        if (_path == null)
        {
            _path = FindObjectOfType<Path>();
        }

        if (_castle == null)
        {
            _castle = FindObjectOfType<Castle>();
        }
        
        attackCount = timeBetweenAttacks;
    }

    void Update()
    {
        if (!LevelManager.instance.levelActive) return;
       
        if (!reachedEnd)
        {
            transform.LookAt(_path.pathPoints[currentPoint]);
        
            transform.position = Vector3.MoveTowards(transform.position, _path.pathPoints[currentPoint].position, moveSpeed * Time.deltaTime * speedMod);

            if (Vector3.Distance(transform.position, _path.pathPoints[currentPoint].position) < 0.1f)
            {
                currentPoint = currentPoint + 1;
                if (currentPoint >= _path.pathPoints.Length)
                {
                    reachedEnd = true;
                    selectedAttackPoint = Random.Range(0, _castle.attackPoints.Length);
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _castle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime * speedMod);
            
            attackCount -= Time.deltaTime;
            if (attackCount <= 0)
            {
                attackCount = timeBetweenAttacks;
                _castle.TakeDamage(damagePerAttack);
            }
        }
        
    }

    public void Setup(Castle newCastle, Path newPath)
    {
        _castle = newCastle;
        _path = newPath;
    }
}
