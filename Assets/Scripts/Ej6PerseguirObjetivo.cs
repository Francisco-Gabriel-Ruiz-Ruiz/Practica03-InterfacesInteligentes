using UnityEngine;

public class Ej6PerseguirObjetivo : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public GameObject obstacle;
    public Material newMaterialForObstacle;

    private bool cuboAlcanzado = false;

    void Start() {
        if (!target) {
            Debug.LogError("¡No hay GameObject para perseguir!");
        }
        if (Mathf.Approximately(0f, speed)) {
            Debug.LogWarning("La velocidad de persecución es aproximadamente 0 (no perseguirá).");
        }
        if (!obstacle) {
            Debug.LogError("¡No hay GameObject definido como obstáculo!");
        }
        if (!newMaterialForObstacle) {
            Debug.LogError("¡No hay material asignado al que vaya a cambiar el obstáculo!");
        }
    }

    // Update is called once per frame
    void Update() {
        if (!target || !obstacle || !newMaterialForObstacle) {
            return;
        }
        // 1. Movimiento hacia el cilindro
        Vector3 targetPosition = target.transform.position;
        Vector3 moveDirection = targetPosition - transform.position;
        float moveStep = speed * Time.deltaTime;
        Vector3 finalMovement = moveDirection.normalized * moveStep;
        transform.Translate(finalMovement);

        // 2. Detección por distancia con el cubo (ya que no se puede usar OnCollisionEnter sin Rigidbody)
        if (!cuboAlcanzado) {
            float distanciaAlCubo = Vector3.Distance(transform.position, obstacle.transform.position);
            // Si la esfera se acerca al cubo a menos de 1 metro.
            if (distanciaAlCubo < 0.9f) {
                cuboAlcanzado = true;
                Debug.Log("La esfera ha alcanzado al obstáculo.");
                MeshRenderer rendererCubo = obstacle.GetComponent<MeshRenderer>();
                if (rendererCubo != null) {
                    rendererCubo.material = newMaterialForObstacle;
                }
            }
        }
    }
}
