using UnityEngine;

public class GeradorDeLixo : MonoBehaviour
{

    public GameObject[] LixoParaGerar;
    public Transform[] pontoDeGeracao;

    public float tempoMaximoEntreGeracoes;
    public float tempoAtualDeGeracao;
    void Start()
    {
        tempoAtualDeGeracao = tempoMaximoEntreGeracoes;
    }


    void Update()
    {
        tempoAtualDeGeracao -= Time.deltaTime;

        if (tempoAtualDeGeracao <= 0)
        {
            SpawnLixo();
        }
    }

    private void SpawnLixo()
    {
        int lixoAleatorio = Random.Range(0, LixoParaGerar.Length);
        int pontoAleatorio = Random.Range(0, pontoDeGeracao.Length);

        Instantiate(LixoParaGerar[lixoAleatorio], pontoDeGeracao[pontoAleatorio].position, Quaternion.Euler(0f, 0f, 0f));
        tempoAtualDeGeracao = tempoMaximoEntreGeracoes;
    }

}
