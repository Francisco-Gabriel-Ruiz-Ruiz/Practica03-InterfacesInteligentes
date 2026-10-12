using UnityEngine;

public class Ej5LanzarObjeto : MonoBehaviour
{
    public float multiplicadorFuerza = 1f;
    public Vector3 throwDirection = new Vector3(0f, 5f, 10f);

    private Rigidbody rigidbody;
    private float fireInput;
    private bool objectThrown;

    void Start() {
        if (Mathf.Approximately(0f, multiplicadorFuerza)) {
            Debug.LogWarning("El multiplicador de fuerza es aproximadamente 0 (anula el lanzamiento del GameObject).");
        }
        rigidbody = GetComponent<Rigidbody>();
        if (!rigidbody) {
            Debug.LogError("¡El GameObject a lanzar no tiene Rigidbody!");
        }
        objectThrown = false;
    }

    void Update() {
        fireInput = Input.GetAxis("LanzarObjeto");
    }

    void FixedUpdate() {
        if (!rigidbody) {
            return;
        }
        if (!objectThrown && fireInput > 0f) {
            objectThrown = true;
            rigidbody.AddForce(throwDirection * multiplicadorFuerza, ForceMode.Impulse);
        }
        
    }

}
