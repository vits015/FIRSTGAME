using UnityEngine;

namespace OcelotDev
{
    public class move : MonoBehaviour
    {
        [Header("Movement")]
        public float movementSpeed = 12f;
        private float horizontalMovement;
        private Rigidbody2D rB;

        [Header("Jumping")]
        public float jumpForce = 20f;
        private bool justJumped = false;

        [Header("Dash")]
        public float dashForce = 30f;
        private float dashCooldown = 1f;
        private float lastDashTime = -1f;
        private bool isDashing = false;

        [Header("Ground")]
        public bool onGround = false;
        public Collider2D floorCollider;
        public ContactFilter2D floorFilter;

        private void Start()
        {
            rB = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Checar se o personagem está no chão
            onGround = floorCollider.IsTouching(floorFilter);

            // Definir a velocidade do pulo e pular
            rB.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rB.velocity.y);

            if (justJumped)
            {
                justJumped = false;
                rB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            if (!justJumped && Input.GetKeyDown(KeyCode.Space) && onGround)
                justJumped = true;

            // Mover o personagem e inverter o sprite horizontalmente
            Vector3 characterScale = transform.localScale;
            if (Input.GetAxis("Horizontal") < 0)
            {
                characterScale.x = Mathf.Abs(characterScale.x);
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                characterScale.x = Mathf.Abs(characterScale.x) * -1;
            }

            transform.localScale = characterScale;

            // Dash suave para a frente
            if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - lastDashTime > dashCooldown)
            {
                lastDashTime = Time.time;
                float dashDirection = (characterScale.x > 0) ? 1f : -1f;
                rB.velocity = new Vector2(dashDirection * dashForce, rB.velocity.y);
                isDashing = true;
            }

            // Parar o dash
            if (isDashing && Time.time - lastDashTime > 0.1f)
            {
                rB.velocity = new Vector2(0, rB.velocity.y);
                isDashing = false;
            }
        }

        private void FixedUpdate()
        {

        }
    }
}
