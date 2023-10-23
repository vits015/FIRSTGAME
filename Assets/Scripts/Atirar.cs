using UnityEngine;

public class Atirar : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform pontoDeOrigem;
    public float forcaTiro = 10.0f;
    public float taxaDeTiro = 0.2f; // Tempo entre cada tiro (em segundos)

    private float proximoTiro = 0.0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= proximoTiro) // Substitua "Fire1" pela entrada de tiro desejada.
        {
            AtirarBala();
            proximoTiro = Time.time + taxaDeTiro;
        }
    }

    void AtirarBala()
    {
        GameObject bala = Instantiate(balaPrefab, pontoDeOrigem.position, pontoDeOrigem.rotation);
        Rigidbody rb = bala.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(pontoDeOrigem.forward * forcaTiro, ForceMode.Impulse);
        }
    }
}
