using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePickup : Pickup
{
    protected override void Picked(GameObject player)
    {
        player.GetComponent<BombController>().IncreaseExplosionRadius();
        base.Picked(player);
    }
}
