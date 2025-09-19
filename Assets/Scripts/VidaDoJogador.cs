using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{

    public Slider barraDeVida;


    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;

    public bool temEscudo;


    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        temEscudo = false;

        barraDeVida.maxValue = vidaMaximaDoJogador;
        barraDeVida.value = vidaAtualDoJogador;
    }


    void Update()
    {

    }

    public void ReceberDano(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            barraDeVida.value = vidaAtualDoJogador;

            if (vidaAtualDoJogador <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
