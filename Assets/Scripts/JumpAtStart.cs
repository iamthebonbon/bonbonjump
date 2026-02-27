using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.EventSystems;

public class JumpAtStart : MonoBehaviour
{

    [SerializeField]
    private int jumpCounter = 2;
    private Rigidbody pRigidbody;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float gravityModifier = 2f;
    private int runtimeJumpCounter = 0;
    private Animator animator;

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        pRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        foreach (var touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(touch.touchId))
            {
                continue;
            }

            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended && runtimeJumpCounter > 0)
            {
                runtimeJumpCounter--;
                if (Random.value > 0.7f)
                {
                    animator.SetTrigger("Jump");
                }
                else if (Random.value > 0.3f)
                {
                    animator.SetTrigger("ObstacleJump");
                }
                else
                {
                    animator.SetTrigger("WeirdJump");
                }
                pRigidbody.AddForce(Vector3.up * 7.5f, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collided with {collision}");
        runtimeJumpCounter = jumpCounter;
    }
}
