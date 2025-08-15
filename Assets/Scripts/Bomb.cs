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
        CancelInvoke(); // potrzebne do nast�pnej lekcji
        // stw�rz eksplozj�, przeka� rozmiar od w�a�ciciela bomby

        // zwi�ksz w�a�cicielowi liczb� dost�pnych bomb
        owner.IncreaseBombsRemaining();

        Destroy(gameObject);
    }
}
