using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementController : MonoBehaviour
{
    [SerializeField] private bool isRotating = true;

    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float rotationSpeed = 7f;

    public Vector3 Direction { get; private set; } = Vector3.zero;
    public Rigidbody Rigidbody { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveObject();
        if(isRotating) RotateObject();
    }

    private void MoveObject()
    {
        // Obliczamy moveVector jako kierunek pomno¿ony razy
        // prêdkoœæ i czas od ostatniego ticka silnika fizyki
        Vector3 moveVector = Direction * speed * Time.fixedDeltaTime;
        
        // przesuwamy pozycjê rigidbody gracza
        // jako obecna plus moveVector
        Rigidbody.MovePosition(Rigidbody.position + moveVector);
    }

    private void RotateObject()
    {
        // jeœli kierunek jest ustawiony (ró¿ny od Vector3.zero)
        // oblicz obrót i obróæ postaæ o wyliczony obrót
        if (Direction != Vector3.zero) {
            Quaternion newRotation = Quaternion.LookRotation(Direction, Vector3.up);

            Rigidbody.MoveRotation(Quaternion.Lerp(Rigidbody.rotation,
                newRotation, rotationSpeed *Time.fixedDeltaTime));
        }
    }

    // dodaj ustawianie kierunku
    public void SetDirection(Vector3 newDirection)
    {
        Direction = newDirection;
    }

}
