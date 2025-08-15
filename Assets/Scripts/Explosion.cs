using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public static LayerMask EXPLOSION_LAYER_MASK { get => LayerMask.NameToLayer("Explosion"); }

    [SerializeField] private GameObject explosionObject;

    private void DestroyExplosion()
    {
        Destroy(transform.parent.gameObject);
    }

}
