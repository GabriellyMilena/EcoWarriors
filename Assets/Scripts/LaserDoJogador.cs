using UnityEngine;
using VolumetricLines;

public class LaserDoJogador : MonoBehaviour
{

    public float velocidadeDoLaser = 10f;
    public int danoCausado = 1;
    public GameObject impactoDoLaser;
    private SpriteRenderer rend; 
    private VolumetricLineBehavior volumetricLine;

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        volumetricLine = GetComponent<VolumetricLineBehavior>();

        if (rend == null && volumetricLine == null)
        {
            Debug.LogWarning("⚠️ Nenhum componente visual encontrado (nem SpriteRenderer nem VolumetricLineBehavior).");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);

        if (transform.position.y > Camera.main.orthographicSize * 1.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LixoEspacial"))
        {
            var lixo = other.GetComponent<LixoEspacial>();
            if (lixo != null)
            {
                Color corDoLaser = Color.white;

                if (rend != null && rend.material != null)
                    corDoLaser = rend.material.color;
                else if (volumetricLine != null)
                    corDoLaser = volumetricLine.LineColor;
                if (corDoLaser == lixo.corDoLixo)
                {
                    lixo.MachucarLixo(danoCausado);

                    if (impactoDoLaser != null)
                        Instantiate(impactoDoLaser, transform.position, transform.rotation);

                    if (EfeitosSonoros.instancia?.somDeImpacto != null)
                        EfeitosSonoros.instancia.somDeImpacto.Play();
                }
                else
                {
                    Debug.Log("Laser não corresponde à cor do lixo. Sem dano.");
                }
            }

            Destroy(gameObject);
        }
    }
    public void DefinirCor(Color cor)
    {
        if (rend != null && rend.material != null)
        {
            rend.material.color = cor;
        }

        if (volumetricLine != null)
        {
            volumetricLine.LineColor = cor;
        }

        Debug.Log("Cor do laser aplicada visualmente: " + cor);
    }
}
