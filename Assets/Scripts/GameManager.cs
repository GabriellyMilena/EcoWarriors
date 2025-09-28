using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    [Header("Áudio")]
    public AudioSource musicaDeFundo;
    public AudioSource musicaDeGameOver;

    [Header("Pontuação")]
    public Text textoDePontuacao;      
    public int PontuacaoAtual;

    [Header("Game Over")]
    public GameObject painelDeGameOver;
    public Text textoDeGameOver;      
    public Text textoDePontuacaoFinal;
    public Text textoDeHighScore;

    [Header("Player")]
    public GameObject jogador;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        Time.timeScale = 1;
        musicaDeFundo.Play();

        AtualizarTextoPontuacao();
    }

    public void AumentarPontuacao(int pontosParaGanhar)
    {
        PontuacaoAtual += pontosParaGanhar;
        AtualizarTextoPontuacao();
    }

    private void AtualizarTextoPontuacao()
    {
        if (textoDePontuacao != null)
            textoDePontuacao.text = "PONTUAÇÃO: " + PontuacaoAtual;
    }

    public void GameOver()
    {
        Time.timeScale = 0;

        if (musicaDeFundo != null) musicaDeFundo.Stop();
        if (musicaDeGameOver != null) musicaDeGameOver.Play();

        if (jogador != null) jogador.SetActive(false);

        if (textoDeGameOver != null) textoDeGameOver.text = "GAME OVER";
        if (textoDePontuacaoFinal != null) textoDePontuacaoFinal.text = "PONTUAÇÃO: " + PontuacaoAtual;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (PontuacaoAtual > highScore)
        {
            highScore = PontuacaoAtual;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        if (textoDeHighScore != null) textoDeHighScore.text = "MELHOR PONTUAÇÃO: " + highScore;
        if (painelDeGameOver != null) painelDeGameOver.SetActive(true);
    }
}
