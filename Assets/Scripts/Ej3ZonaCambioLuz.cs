using UnityEngine;

public class Ej3ZonaCambioLuz : MonoBehaviour
{
    public Light light;
    public float intensityValueInside = 0f;

    private float previousIntensity;

    void Start() {
        if (!light) {
            Debug.LogError("¡No hay luz referenciada!");
        }
    }

  void OnTriggerEnter(Collider other) {
        if (!light) {
            return;
        }
        if (other.gameObject.CompareTag("Player")) {
            previousIntensity = light.intensity;
            light.intensity = intensityValueInside;
        }
    }

    void OnTriggerExit(Collider other) {
        if (!light) {
            return;
        }
        if (other.gameObject.CompareTag("Player")) {
            light.intensity = previousIntensity;
        }
    }
}
