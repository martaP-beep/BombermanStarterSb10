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
        // Obliczamy moveVector jako kierunek pomno�ony razy
        // pr�dko�� i czas od ostatniego ticka silnika fizyki
        Vector3 moveVector = Direction * speed * Time.fixedDeltaTime;
        
        // przesuwamy pozycj� rigidbody gracza
        // jako obecna plus moveVector
        Rigidbody.MovePosition(Rigidbody.position + moveVector);
    }

    private void RotateObject()
    {
        // je�li kierunek jest ustawiony (r�ny od Vector3.zero)
        // oblicz obr�t i obr�� posta� o wyliczony obr�t
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
