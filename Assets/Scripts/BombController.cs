using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombController : MonoBehaviour
{
    [Header("Key bindings")]
    [SerializeField] private KeyCode inputKey = KeyCode.Space;

    [Header("Bomb parameters")]
    [SerializeField] private  int bombAmount = 1;
    [SerializeField] private int explosionRadius = 2;
    public int GetExplosionRadius() => explosionRadius;

    private int bombsRemaining;
    private bool stayOnBomb = false;
    
    public void IncreaseExplosionRadius(int amount = 1)
    {
        explosionRadius += amount;
    }

    private void Awake()
    {
        bombsRemaining = bombAmount;
    }

    private void Update()
    {
        if (bombsRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            PlaceBomb();
        }
    }

    private void PlaceBomb()
    {
        // przerywamy jeœli gracz stoi na bombie
        if (stayOnBomb) return;

        // zmniejszamy liczbê dostêpnych bomb
        bombsRemaining--;



        // stawiamy bombê korzystaj¹c z BombSpawnera
        // podajemy w³asn¹ aktualn¹ pozycjê
        BombSpawner.Instance.PlaceBomb(transform.position, this);

        // ustawiamy ¿e stoimy na bombie aby zapobiec
        // stawianiu kolejnej do czasu odejœcia z kolejnej
        stayOnBomb = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == Bomb.BOMB_LAYER_MASK)
        {
            other.isTrigger = false;
            stayOnBomb = false;
        }
    }

    public void IncreaseBombsRemaining()
    {
        if(bombsRemaining < bombAmount)
        {
            bombsRemaining++;
        }
    }
}
