using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Salud")]
    public int maxHealth = 100; // La vida total con la que empieza
    private int currentHealth;  // La vida que tiene en este momento
    [SerializeField] private Healthbar healthbar; // Arrastraremos el script aquí

    [Header("Efectos")]
    public GameObject deathEffect;
    public GameObject drop;

    // Nota: Quitamos la referencia directa deathSound si usas FindObjectOfType, 
    // o la mantenemos si la asignas en el inspector. La dejo como estaba:
    // public SoundLibrary deathSound; 

    void Start()
    {
        // Al inicio, la vida actual es igual a la máxima
        currentHealth = maxHealth;

        // Asegurarnos de que la barra empiece llena
        if (healthbar != null)
        {
            healthbar.UpdateHealthbar(maxHealth, currentHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Actualizamos la barra visualmente
        if (healthbar != null)
        {
            healthbar.UpdateHealthbar(maxHealth, currentHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Usamos FindObjectOfType como tenías en tu código original
        if (FindObjectOfType<SoundLibrary>() != null)
        {
            FindObjectOfType<SoundLibrary>().PlayExplosion();
        }

        // Instanciamos efectos y drops
        if (drop != null) Instantiate(drop, transform.position, Quaternion.identity);
        if (deathEffect != null) Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}