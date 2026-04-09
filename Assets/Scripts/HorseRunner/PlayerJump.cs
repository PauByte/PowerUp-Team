using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f;
    public float fallMultiplier = 2.2f; // para la caída

    private Rigidbody rb;
    private bool isGrounded = true;

    // Para animacion
    private Animator animator;
    private AudioSource gallopAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        gallopAudio = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            Jump();
        }

        // Aumentar velocidad de caída
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        // Animación usando grounded real
        animator.SetBool("isGrounded", isGrounded);

        // Sonido de galope
        if (isGrounded)
        {
            if (!gallopAudio.isPlaying)
            {
                gallopAudio.Play();
            }
        }
        else
        {
            if (gallopAudio.isPlaying)
            {
                gallopAudio.Stop();
            }
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, 0);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // AÑADIDO para saber si ya esta en el suelo
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}