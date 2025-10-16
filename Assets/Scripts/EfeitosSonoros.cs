using UnityEngine;

public class EfeitosSonoros : MonoBehaviour
{
    public AudioSource somExplosao, somDoLaser, somDeImpacto;

    public static EfeitosSonoros instancia;
    void Awake()
    {
        instancia = this;
    }
    
    void Start()
    {
    }

    void Update()
    {
    }
}
