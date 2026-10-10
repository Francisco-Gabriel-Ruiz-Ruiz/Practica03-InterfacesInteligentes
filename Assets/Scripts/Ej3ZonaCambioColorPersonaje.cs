using UnityEngine;

public class Ej3ZonaCambioColorPersonaje : MonoBehaviour
{

    public Color playerColorInside = new Color(0f, 0f, 0f);
    private Color originalPlayerColor;
    // No pongo aquí el MeshRenderer de player por si entran varios. Es buena idea?

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            MeshRenderer playerRenderer = other.gameObject.GetComponent<MeshRenderer>();
            originalPlayerColor = playerRenderer.material.color;
            playerRenderer.material.color = playerColorInside;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            MeshRenderer playerRenderer = other.gameObject.GetComponent<MeshRenderer>();
            playerRenderer.material.color = originalPlayerColor;
        }
    }
}
