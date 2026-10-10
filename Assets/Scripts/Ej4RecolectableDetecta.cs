using System;
using UnityEngine;

public class Ej4RecolectableDetecta : MonoBehaviour
{
    void Start() {
        Collider collider = GetComponent<Collider>();
        if (!collider || !collider.isTrigger) {
            Debug.LogWarning("Recolectable sin isTrigger. Activándoselo.");
            collider.isTrigger = true;
        }

        int collectableLayer = LayerMask.NameToLayer("Collectable");
        if (collectableLayer != gameObject.layer) {
            Debug.LogWarning("Script de recolectable asignado a un GameObject sin layer Collectable.");
        }
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter detectó al GameObject: " + other.name);
    }

    void OnTriggerExit(Collider other) {
        Debug.Log("OnTriggerExit dejó de detectar al GameObject: " + other.name);
    }
}
