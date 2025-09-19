using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

    public Text textoDePontuacao;


    public int PontuacaoAtual;


    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        PontuacaoAtual = 0;
        textoDePontuacao.text = "PONTUAÇÃO: " + PontuacaoAtual;
    }


    void Update()
    {

    }

    public void AumentarPontuacao(int pontosParaGanhar)
    {
        PontuacaoAtual += pontosParaGanhar;
        textoDePontuacao.text = "PONTUAÇÃO: " + PontuacaoAtual;
    }
    
        
    

}
