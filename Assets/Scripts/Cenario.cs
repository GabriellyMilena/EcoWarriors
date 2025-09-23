using UnityEngine;

public class Cenario : MonoBehaviour
{
    public float velocidadeDoCenario;

    void Update()
    {
        MovimentarCenario();
    }

    private void MovimentarCenario()
    {
        // desloca no eixo X (se quiser no Y, troca para Vector2(0, Time.time * velocidadeDoCenario))
        Vector2 deslocamento = new Vector2(Time.time * velocidadeDoCenario, 0);

        GetComponent<Renderer>().material.mainTextureOffset = deslocamento;
    }
}
