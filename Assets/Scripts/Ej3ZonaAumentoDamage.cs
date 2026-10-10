using UnityEngine;

public class Ej3ZonaAumentoDamage : MonoBehaviour
{
    public int damageIncrease = 1;

    void Start() {
        if (damageIncrease == 0) {
            Debug.LogWarning("Aumento de daño está en 0");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Aumentando daño del jugador en " + damageIncrease + "...");
            other.gameObject.GetComponent<Ej3PlayerStats>().ModifyDamage(damageIncrease);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Revirtiendo daño del jugador...");
            other.gameObject.GetComponent<Ej3PlayerStats>().ModifyDamage(-damageIncrease);
        }
    }
}
