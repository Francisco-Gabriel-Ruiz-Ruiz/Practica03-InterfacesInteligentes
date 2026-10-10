using UnityEngine;

public class Ej5LanzarObjeto : MonoBehaviour
{
    public float multiplicadorFuerza = 1f;
    public Vector3 throwDirection = new Vector3(0f, 0f, 10f);

    private Rigidbody rigidbody;
    private float fireInput;

    void Start() {
        if (Mathf.Approximately(0f, multiplicadorFuerza)) {
            Debug.LogWarning("El multiplicador de fuerza es aproximadamente 0 (anula el lanzamiento del GameObject).");
        }
        rigidbody = GetComponent<Rigidbody>();
        if (!rigidbody) {
            Debug.LogError("¡El GameObject a lanzar no tiene Rigidbody!");
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
