using UnityEngine;

public class Bomb : MonoBehaviour
{
    [HideInInspector] public Vector3 targetPoint;

    [SerializeField] Transform pivot, model;
    [SerializeField] private GameObject explodeEffect;
    [SerializeField] private float moveSpeed, damageAmount, explodeRange;
    [SerializeField] private LayerMask whatIsEnemy;
    
    void Start()
    {
        Vector3 startPos = transform.position;
        
        Vector3 centerPosition = (transform.position + targetPoint) * 0.5f;
        transform.position = centerPosition;

        transform.right = targetPoint - transform.position;

        model.transform.position = startPos;
        
        AudioManager.instance.PlaySFX(1);
    }

    void Update()
    {
        pivot.localRotation =
            Quaternion.RotateTowards(pivot.localRotation, Quaternion.Euler(0, 0, 180), moveSpeed * Time.deltaTime);
        
        model.rotation = Quaternion.identity;

        if (Vector3.Distance(model.position, targetPoint) < .1f)
        {

            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, explodeRange, whatIsEnemy);
            foreach (Collider col in collidersInRange)
            {
                col.GetComponent<EnemyHealthController>().TakeDamage(damageAmount);
            }
            
            if (explodeEffect != null)
            {
                Instantiate(explodeEffect, model.position, Quaternion.identity);
            }
            
            AudioManager.instance.PlaySFX(0);
            Destroy(gameObject);
        }
    }
}
