using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public void DestroyWall()
    {
        PickupsSpawner.Instance.CreateRandomPickup(transform.position);
        Destroy(gameObject);
    }
}
