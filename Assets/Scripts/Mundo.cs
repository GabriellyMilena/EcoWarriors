using UnityEngine;

public class Mundo : MonoBehaviour
{
    [Header("Configuração da Terra")]
    [Tooltip("Velocidade de rotação da Terra (graus por segundo)")]
    public float velocidadeRotacao = 5f;

    [Header("Configuração do Jogador")]
    [Tooltip("Tag do jogador (normalmente 'Player')")]
    public string tagDoJogador = "Player";

    private void Update()
    {
        // Faz a Terra girar no eixo Z
        transform.Rotate(0, 0, velocidadeRotacao * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // só reagir ao lixo espacial
        if (!other.CompareTag("LixoEspacial")) return;

        // obter dados do lixo (para pegar o dano e o prefab de impacto)
        LixoEspacial lixo = other.GetComponent<LixoEspacial>();
        int dano = (lixo != null) ? lixo.danoCausado : 1; // fallback = 1

        // encontrar o jogador pela tag e aplicar dano
        GameObject jogador = GameObject.FindGameObjectWithTag(tagDoJogador);
        if (jogador != null)
        {
            VidaDoJogador vida = jogador.GetComponent<VidaDoJogador>();
            if (vida != null)
            {
                vida.ReceberDano(dano);
                Debug.Log($"Terra: jogador recebeu {dano} de dano.");
            }
        }
        else
        {
            Debug.LogWarning("Terra: jogador não encontrado com a tag '" + tagDoJogador + "'.");
        }

        // instanciar efeito de impacto (opcional)
        if (lixo != null && lixo.impactoDoLixo != null)
        {
            Instantiate(lixo.impactoDoLixo, other.transform.position, Quaternion.identity);
        }

        // destruir o lixo que atingiu a Terra
        Destroy(other.gameObject);
    }
}


