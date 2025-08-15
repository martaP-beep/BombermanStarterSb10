using UnityEngine;

public class Bomb : MonoBehaviour
{
    public static LayerMask BOMB_LAYER_MASK { get => LayerMask.NameToLayer("Bomb"); }

    [SerializeField] private float fuseTime = 3f;

    private BombController owner;
    public void SetOwner(BombController owner) => this.owner = owner;

    public void Start()
    {
        Invoke(nameof(Explode), fuseTime);
    }

    public void Explode()
    {
        CancelInvoke(); // potrzebne do nastêpnej lekcji
        // stwórz eksplozjê, przeka¿ rozmiar od w³aœciciela bomby

        // zwiêksz w³aœcicielowi liczbê dostêpnych bomb
        owner.IncreaseBombsRemaining();

        Destroy(gameObject);
    }
}
