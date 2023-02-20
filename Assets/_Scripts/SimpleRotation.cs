using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
