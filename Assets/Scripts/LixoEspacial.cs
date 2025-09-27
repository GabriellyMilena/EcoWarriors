using UnityEngine;

public class LixoEspacial : MonoBehaviour
{
    //public GameObject colisaoDoLixo;

    public GameObject impactoDoLixo;
    public float velocidadeDoLixo;

    public GameObject itemDropado;
    public int chanceDeDroparItem; // Porcentagem de chance de dropar o item (0-100)

    public int vidaMaximaDoLixo;
    public int vidaAtualDoLixo;

    public int pontosPorLixo;

    public int danoCausado;

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
            Instantiate(impactoDoLixo, transform.position, transform.rotation);

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

            //Instantiate(impactoDoLixo, transform.position, transform.rotation);

            EfeitosSonoros.instancia.somExplosao.Play();

            int numeroAleatorio = Random.Range(0, 100);

            if (numeroAleatorio <= chanceDeDroparItem) //30% de chance de dropar o item
            {
                Instantiate(itemDropado, transform.position, Quaternion.Euler(0, 0, 0));
            }

            Destroy(this.gameObject);
        }
    }
}

