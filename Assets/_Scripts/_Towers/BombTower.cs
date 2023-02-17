using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTower : MonoBehaviour
{
    public float timeBetweenBomb;
    private Tower _tower;
    private float bombCounter;
    void Start()
    {
       _tower = GetComponent<Tower>();
       bombCounter = timeBetweenBomb;
    }

    void Update()
    {
        
    }
}
