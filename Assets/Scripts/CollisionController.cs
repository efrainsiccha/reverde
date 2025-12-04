using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    public GameObject tree;
    public GameObject deathEffect;

    // VARIABLE NUEVA: Esta es la "bandera" de seguridad
    // Sirve para que el juego sepa que ya moriste y no te quite vidas extra
    private bool isDead = false;

    void Start()
    {
        // Al iniciar el nivel, nos aseguramos de estar "vivos"
        isDead = false;

        if (tree != null)
            tree.gameObject.SetActive(false);
    }

    void Update()
    {
        // Vacío, no necesitamos nada aquí por ahora
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // 1. BLOQUEO DE SEGURIDAD:
        // Si la bandera 'isDead' ya es verdadera, significa que ya chocamos hace un milisegundo.
        // El 'return' hace que el código se detenga aquí y no reste otra vida.
        if (isDead) return;

        // --- LÓGICA DE MUERTE ---
        if (other.gameObject.CompareTag("Trap") || other.gameObject.CompareTag("Enemy"))
        {
            isDead = true; // ¡Marcamos inmediatamente que morimos!

            // Instanciamos el efecto de muerte
            if (deathEffect != null)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
            }

            // Avisamos al GameManager para que reste 1 vida y reinicie/acabe el juego
            FindObjectOfType<GameManager>().EndGame();

            // Destruimos al jugador
            Destroy(gameObject);
        }

        // --- LÓGICA DE VICTORIA (PASAR DE NIVEL) ---
        // Esta parte la dejé igual a tu original
        if (other.gameObject.CompareTag("EndPlatform") && Score.bottles >= 5)
        {
            Score.bottles = 0;
            GameManager.lives = 4; // Restauras vidas al pasar (según tu diseño original)

            if (tree != null)
                tree.gameObject.SetActive(true);

            Invoke("NextLevel", 3f);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}