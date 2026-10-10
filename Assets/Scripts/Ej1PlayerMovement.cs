using UnityEngine;

public class Ej1PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rigidbody;
    private Vector3 moveDirection;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        float moveStep = speed * Time.fixedDeltaTime;
        float horizontalMovement = Input.GetAxis("Horizontal") * moveStep;
        float verticalMovement = Input.GetAxis("Vertical") * moveStep;
        moveDirection = new Vector3(horizontalMovement, 0f, verticalMovement);
    }

    void FixedUpdate() {
        rigidbody.MovePosition(rigidbody.position + moveDirection);
    }
}
