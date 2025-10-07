using UnityEngine;

public class TrocaSpriteComTecla : MonoBehaviour
{
    public GameObject[] navesColoridas;  
    private int indiceAtual = 0;

    void Start()
    {
        if (navesColoridas.Length > 0)
            AtivarNave(indiceAtual);
        else
            Debug.LogError("Nenhuma nave atribuída no Inspector!");
    }

    void Update()
    {
        // Detecta RB do Xbox (Right Bumper)
        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            TrocarNave();
        }
    }

    void TrocarNave()
    {
        indiceAtual = (indiceAtual + 1) % navesColoridas.Length;
        AtivarNave(indiceAtual);
    }

    void AtivarNave(int indice)
    {
        for (int i = 0; i < navesColoridas.Length; i++)
            navesColoridas[i].SetActive(i == indice);
    }
}
