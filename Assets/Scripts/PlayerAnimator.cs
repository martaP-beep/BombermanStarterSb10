using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(MovementController))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private MovementController movementController;

    private const string RUN_PARAM = "Run";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movementController = GetComponent<MovementController>();
    }

    private void Update()
    {
        SetRuning(movementController.Direction != Vector3.zero);
    }

    public void SetRuning(bool value)
    {
        animator.SetBool(RUN_PARAM, value);
    }
}
