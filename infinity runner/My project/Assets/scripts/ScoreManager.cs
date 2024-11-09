using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Referência ao Text de pontuação
    public Text highScoreText; // Referência ao Text de high score
    private int score = 0; // Pontuação do jogador
    private int highScore = 0; // Recorde do jogador

    // Chamado no início do jogo
    void Start()
    {
        // Carrega o high score salvo do PlayerPrefs. Se não existir, o valor padrão será 0.
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    // Função chamada para adicionar pontos
    public void AddScore(int points)
    {
        score += points; // Adiciona pontos à pontuação
        UpdateScoreText(); // Atualiza o texto da pontuação

        // Verifica se a pontuação atual é maior que o recorde e atualiza
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save(); // Salva imediatamente
            UpdateHighScoreText();
        }
    }

    // Atualiza o texto da pontuação na UI
    private void UpdateScoreText()
    {
        scoreText.text = "Pontuação: " + score.ToString();
    }

    // Atualiza o texto do high score na UI
    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    // Função para resetar a pontuação (caso necessário)
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
