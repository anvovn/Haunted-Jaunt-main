using UnityEngine;

public class PlayerFearParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem headParticles;

    public void PlayFearEffect()
    {
        if (headParticles != null)
        {
            headParticles.Play();
        }
    }
}