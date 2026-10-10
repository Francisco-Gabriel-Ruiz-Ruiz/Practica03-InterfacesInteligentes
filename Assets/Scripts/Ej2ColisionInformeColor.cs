using System;
using UnityEngine;
using Random=UnityEngine.Random;

public class Ej2ColisionInformeColor : MonoBehaviour
{
    private MeshRenderer gameObjectRenderer;

    void Start() {
        gameObjectRenderer = GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision collision) {
        gameObjectRenderer.material.color = randomColorGenerator();
        Debug.Log("Colisión de " + name + " con " + collision.gameObject.name);
    }

    Color randomColorGenerator() {
        float randomR = Random.Range(0.0f, 1.0f);
        float randomG = Random.Range(0.0f, 1.0f);
        float randomB = Random.Range(0.0f, 1.0f);
        return new Color(randomR, randomG, randomB);
    }
}
