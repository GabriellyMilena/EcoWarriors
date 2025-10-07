using UnityEngine;

public class LaserDoJogador : MonoBehaviour
{
    [Header("Propriedades de Movimento")]
    public float velocidadeDoLaser = 10f;

    [Header("Propriedades de Combate")]
    public int danoCausado = 1;
    public GameObject impactoDoLaser;

    [Header("Componentes Internos")]
    private SpriteRenderer rend; // melhor para jogos 2D

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        if (rend == null)
        {
            Debug.LogWarning("⚠️ Nenhum SpriteRenderer encontrado no laser — ele pode ficar invisível.");
        }
    }

    void Update()
    {
        // Movimento contínuo do laser
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);

        // Destruição automática fora da tela (boa prática)
        if (transform.position.y > Camera.main.orthographicSize * 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // ✅ versão 2D correta
    {
        if (other.gameObject.CompareTag("LixoEspacial"))
        {
            var lixo = other.GetComponent<LixoEspacial>();
            if (lixo != null)
            {
                lixo.MachucarLixo(danoCausado);
            }

            if (impactoDoLaser != null)
            {
                Instantiate(impactoDoLaser, transform.position, transform.rotation);
            }

            if (EfeitosSonoros.instancia?.somDeImpacto != null)
            {
                EfeitosSonoros.instancia.somDeImpacto.Play();
            }

            Destroy(gameObject);
        }
    }

    // Permite mudar a cor do laser dinamicamente (para o script DisparoDoJogador)
    public void DefinirCor(Color cor)
    {
        if (rend != null && rend.material != null)
        {
            rend.material.color = cor;
        }
    }
}
