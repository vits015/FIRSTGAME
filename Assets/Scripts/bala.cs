using UnityEngine;

public class Bala : MonoBehaviour
{
    public float forcaInicial = 10.0f;
    public float tempoDeVida = 3.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Aplica uma força inicial no momento da instância.
            rb.AddForce(transform.up * forcaInicial, ForceMode2D.Impulse);
        }

        // Destruir a bala após um tempo de vida especificado.
        Destroy(gameObject, tempoDeVida);
    }
}
