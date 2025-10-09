using UnityEngine;

public class LixoEspacial : MonoBehaviour
{
    [Header("Configurações do Lixo")]
    public float velocidadeDoLixo;
    public int vidaMaximaDoLixo;
    public int vidaAtualDoLixo;
    public int pontosPorLixo;
    public int danoCausado;

    [Header("Sistema Cromático")]
    public Color corDoLixo = Color.white; // 🔹 Adicionado

    [Header("Itens e Efeitos")]
    public GameObject impactoDoLixo;
    public GameObject itemDropado;
    public int chanceDeDroparItem;

    void Start()
    {
        vidaAtualDoLixo = vidaMaximaDoLixo;

        // Aplica a cor no sprite do inimigo
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.color = corDoLixo;
    }

    void Update()
    {
        MovimentarLixo();
    }

    private void MovimentarLixo()
    {
        transform.Translate(Vector3.left * velocidadeDoLixo * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<VidaDoJogador>().ReceberDano(danoCausado);
            CriarExplosao();
            EfeitosSonoros.instancia.somExplosao.Play();
            Destroy(this.gameObject);
        }
    }

    public void MachucarLixo(int danoParaCausar)
    {
        vidaAtualDoLixo -= danoParaCausar;
        if (vidaAtualDoLixo <= 0)
        {
            GameManager.instancia.AumentarPontuacao(pontosPorLixo);
            CriarExplosao();
            EfeitosSonoros.instancia.somExplosao.Play();

            if (Random.Range(0, 100) <= chanceDeDroparItem)
            {
                Instantiate(itemDropado, transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }

    private void CriarExplosao()
    {
        if (impactoDoLixo == null) return;

        GameObject explosao = Instantiate(impactoDoLixo, transform.position, transform.rotation);
        SpriteRenderer sr = explosao.GetComponent<SpriteRenderer>();
        if (sr != null) sr.sortingOrder = 1;
    }
}
