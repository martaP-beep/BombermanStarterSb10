using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Explosion.EXPLOSION_LAYER_MASK)
        {
            OnPlayerDeath();
        }
    }

    private void OnPlayerDeath()
    {
        gameObject.SetActive(false);
    }
}
