using UnityEngine;

public class LixoEspacial : MonoBehaviour
{
    public GameObject impactoDoLixo;
    public float velocidadeDoLixo;

    public int vidaMaximaDoLixo;
    public int vidaAtualDoLixo;

    public int danoCausado;

    void Start()
    {

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
            Destroy(this.gameObject);
        }
    }

    public void MachucarLixo(int danoParaCausar)
    {
        vidaAtualDoLixo -= danoParaCausar;
        if (vidaAtualDoLixo <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
