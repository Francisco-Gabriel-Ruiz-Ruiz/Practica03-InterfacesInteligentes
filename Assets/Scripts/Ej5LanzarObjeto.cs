using UnityEngine;

public class Ej5LanzarObjeto : MonoBehaviour
{
    public float multiplicadorFuerza = 1f;
    public Vector3 throwDirection = new Vector3(0f, 0f, 10f);

    private Rigidbody rigidbody;
    private float fireInput;

    void Start() {
        if (multiplicadorFuerza == 0f) {
            Debug.LogWarning("El multiplicador de fuerza es 0 (anula el lanzamiento de objeto).");
        }
        rigidbody = GetComponent<Rigidbody>();
        if (!rigidbody) {
            Debug.LogError("¡El objeto a lanzar no tiene Rigidbody!");
        }
    }

    void Update() {
        fireInput = Input.GetAxis("LanzarObjeto");
    }

    void FixedUpdate() {
        if (!rigidbody) {
            return;
        }
        rigidbody.AddForce(throwDirection * fireInput, ForceMode.Impulse);
    }

}
