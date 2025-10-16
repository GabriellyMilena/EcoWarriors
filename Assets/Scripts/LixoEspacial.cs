using UnityEngine;

public class LixoEspacial : MonoBehaviour
{
    public float velocidadeDoLixo;
    public int vidaMaximaDoLixo;
    public int vidaAtualDoLixo;
    public int pontosPorLixo;
    public int danoCausado;
    public Color corDoLixo = Color.white; 
    public GameObject impactoDoLixo;
    public GameObject itemDropado;
    public int chanceDeDroparItem;

    void Start()
    {
        vidaAtualDoLixo = vidaMaximaDoLixo;

        Color[] coresDisponiveis = { Color.red, Color.green, Color.yellow };
        corDoLixo = coresDisponiveis[Random.Range(0, coresDisponiveis.Length)];

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
