using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BombSpawner : MonoBehaviour
{
    
    public static BombSpawner Instance { get; private set; }

    [SerializeField] private GameObject bombPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            DestroyImmediate(gameObject);
    }

    public void PlaceBomb(Vector3 position, BombController owner)
    {
        // znormalizuj podan� w parametrze pozycj� u�ywaj�c
        // metody NormalizePosition() z klasy HelperFunctions

        position = HelperFunctions.NormalizePosition(position);

        // stw�rz obiekt bomby na scenie w znormalizowanej pozycji
      GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
       
        bomb.GetComponent<Bomb>().SetOwner(owner);
    }
   
}
