using UnityEngine;

public class RemoveParent : MonoBehaviour
{
    void Start()
    {
        transform.parent = null;
    }
}
