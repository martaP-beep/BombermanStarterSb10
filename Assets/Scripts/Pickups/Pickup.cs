using System;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public static event EventHandler OnPickupPicked;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PlayerController.PLAYER_TAG))
        {
            Picked(other.gameObject);
        }
    }

    protected virtual void Picked(GameObject player)
    {
        OnPickupPicked?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);

       
    }
}
