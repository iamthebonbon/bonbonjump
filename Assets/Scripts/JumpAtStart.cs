using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.EventSystems;

public class JumpAtStart : MonoBehaviour
{

    private Rigidbody pRigidbody;
    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float gravityModifier = 2f;

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
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

            if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended)
            {
                pRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collided with {collision}");
    }
}
