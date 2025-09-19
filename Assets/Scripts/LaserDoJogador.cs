using UnityEngine;

public class LaserDoJogador : MonoBehaviour
{
    public float velocidadeDoLaser;
    public int danoCausado;

    void Update()
    {
        Movimentarlaser();
    }

    private void Movimentarlaser()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("LixoEspacial"))
        {
            other.gameObject.GetComponent<LixoEspacial>().MachucarLixo(danoCausado);
            Destroy(this.gameObject);
        }

    }
}

