using UnityEngine;

public class Ej3PlayerStats : MonoBehaviour
{
    public int damage;

    private int previousDamage;

    void Update() {
        if (damage > previousDamage) {
            Debug.Log("Player más fuerte: daño pasó de " + previousDamage + " a " + damage);
        } else if (damage < previousDamage) {
            Debug.Log("Player más débil: daño pasó de " + previousDamage + " a " + damage);
        }
        previousDamage = damage;
    }

    public void ModifyDamage(int damageChange) {
        if (damageChange == 0) {
            Debug.LogWarning("Se ha intentado cambiar el daño con un valor de 0");
        }
        damage += damageChange;
    } 
}
