using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 8f;
    public GameManager gameManager;

    [Header("Animation Speed")]
    public float animSpeed = 1f;
    public float speedIncrease = 0.0015f;
    public float maxAnimSpeed = 1.5f;

    [Header("Jump Sound")]
    public AudioClip jumpClip;

    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource audioSource;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        animSpeed = 1f;
        anim.speed = animSpeed;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            Jump();
        }

        IncreaseAnimationSpeed();
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false;

        PlayJumpSound();
    }

    void PlayJumpSound()
    {
        if (jumpClip != null)
        {
            audioSource.PlayOneShot(jumpClip);
        }
    }

    void IncreaseAnimationSpeed()
    {
        if (animSpeed < maxAnimSpeed)
        {
            animSpeed += speedIncrease;
            anim.speed = animSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
            StopAnimation();
        }
    }

    // 🧊 Game Over 停止動畫
    public void StopAnimation()
    {
        anim.speed = 0f;
    }

    // 🔄 重開遊戲恢復動畫
    public void ResetAnimation()
    {
        animSpeed = 1f;
        anim.speed = animSpeed;
    }
}