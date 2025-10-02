using UnityEngine;

public class TrocaSpriteComTecla : MonoBehaviour
{
    public GameObject[] navesColoridas; // TEM que ser GameObject
    private int indiceAtual = 0;

    void Start()
    {
        if (navesColoridas.Length > 0)
        {
            AtivarNave(indiceAtual);
        }
        else
        {
            Debug.LogError("Nenhuma nave atribuída no Inspector!");
        }
    }

    void Update()
    {
        // Teclado (C) ou controle (Botão O no PS / B no Xbox)
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            indiceAtual = (indiceAtual + 1) % navesColoridas.Length;
            AtivarNave(indiceAtual);
        }
    }

    void AtivarNave(int indice)
    {
        for (int i = 0; i < navesColoridas.Length; i++)
        {
            navesColoridas[i].SetActive(i == indice);
        }
    }
}
