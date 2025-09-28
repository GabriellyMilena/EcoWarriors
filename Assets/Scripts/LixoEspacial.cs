using UnityEngine;

public class LixoEspacial : MonoBehaviour
{
    //public GameObject colisaoDoLixo;

    [Header("Configurações do Lixo")]
    public float velocidadeDoLixo;
    public int vidaMaximaDoLixo;
    public int vidaAtualDoLixo;
    public int pontosPorLixo;
    public int danoCausado;

    [Header("Itens e Efeitos")]
    public GameObject impactoDoLixo;
    public GameObject itemDropado;
    public int chanceDeDroparItem; // Porcentagem de chance de dropar o item (0-100)

    void Start()
    {
        vidaAtualDoLixo = vidaMaximaDoLixo;
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

            // Explosão na frente do lixo
            GameObject explosao = Instantiate(impactoDoLixo, transform.position, transform.rotation);
            SpriteRenderer sr = explosao.GetComponent<SpriteRenderer>();
            if (sr != null) sr.sortingOrder = 1;

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

            // Explosão na frente do lixo
            GameObject explosao = Instantiate(impactoDoLixo, transform.position, transform.rotation);
            SpriteRenderer sr = explosao.GetComponent<SpriteRenderer>();
            if (sr != null) sr.sortingOrder = 1;

            EfeitosSonoros.instancia.somExplosao.Play();

            // Chance de dropar item
            int numeroAleatorio = Random.Range(0, 100);
            if (numeroAleatorio <= chanceDeDroparItem)
            {
                Instantiate(itemDropado, transform.position, Quaternion.identity);
            }

            Destroy(this.gameObject);
        }
    }
}
