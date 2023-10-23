using UnityEngine;

public class FollowMouseInCircle : MonoBehaviour
{
    public Transform center; // Centro do círculo imaginário
    public float radius = 2.0f; // Raio do círculo
    public float rotationSpeed = 90.0f; // Velocidade de rotação

    private void FixedUpdate()
    {
        // Obter a posição do mouse na tela
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10; // Distância da câmera para a tela

        // Converter a posição do mouse para coordenadas do mundo
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcular a direção do objeto em relação ao centro do círculo
        Vector3 direction = worldPosition - center.position;

        // Calcular a rotação do objeto
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Normalizar a direção (para manter o objeto na borda do círculo)
        direction = direction.normalized;

        // Mover o objeto para a posição calculada no círculo
        transform.position = center.position + direction * radius;

        // Rotacionar o objeto para direcioná-lo em relação ao centro do círculo
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Ajustar a rotação do objeto com base na velocidade de rotação
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
