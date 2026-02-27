using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

}