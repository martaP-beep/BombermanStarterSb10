using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class PlayerController : MonoBehaviour
{
    public const string PLAYER_TAG = "Player";
    public static int PLAYER_LAYER_MASK { get => LayerMask.NameToLayer("Player"); }

    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;
    [SerializeField] private KeyCode leftKey = KeyCode.A;
    [SerializeField] private KeyCode rightKey = KeyCode.D;

    private MovementController movementController;

    private void Awake()
    {
        movementController = GetComponent<MovementController>();
    }

    void Update()
    {
        // Ustawiamy kierunek na podstawie Inputu gracza
        if (Input.GetKey(rightKey))
        {
            movementController.SetDirection(Vector3.right);
        }
        else if (Input.GetKey(leftKey))
        {
            movementController.SetDirection(Vector3.left);
        }
        else if (Input.GetKey(upKey))
        {
            movementController.SetDirection(Vector3.forward);
        }
        else if (Input.GetKey(downKey))
        {
            movementController.SetDirection(Vector3.back);
        }
        else
        {
            movementController.SetDirection(Vector3.zero);
        }
    }
}
