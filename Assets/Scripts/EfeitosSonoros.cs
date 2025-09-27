using UnityEngine;

public class EfeitosSonoros : MonoBehaviour
{
    public AudioSource somExplosao, somDoLaser, somDeImpacto;

    public static EfeitosSonoros instancia; // corrigido para ficar consistente com LixoEspacial

    void Awake()
    {
        instancia = this;
    }
    
    void Start()
    {
        // Mantido do seu código original
    }

    void Update()
    {
        // Mantido do seu código original
    }
}
