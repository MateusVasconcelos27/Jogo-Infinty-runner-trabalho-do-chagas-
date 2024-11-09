using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    private AudioSource audioSource;

    public GameObject GameOver;
    private Button restartButton;
    private Rigidbody2D rb;
    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        GameOver.SetActive(false);

        restartButton = GameOver.GetComponentInChildren<Button>();
        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(false);
            restartButton.onClick.AddListener(RestartGame);
        }

        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            PlayJumpSound();
        }
    }

    private void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            PlayDeathSound();

            // Verifica se é um novo recorde antes de exibir a tela de Game Over
            if (scoreManager != null)
            {
                scoreManager.ResetScore();
            }

            GameOver.SetActive(true);
            restartButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
