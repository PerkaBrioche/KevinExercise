using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    public float DestroyAfter;
    void Start()
    {
        Destroy(gameObject, DestroyAfter);
    }

}
