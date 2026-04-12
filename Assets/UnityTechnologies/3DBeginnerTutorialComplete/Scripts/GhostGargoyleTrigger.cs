using UnityEngine;

public class FearTrigger : MonoBehaviour
{
    [SerializeField] private bool playOnlyOnce = false;
    [SerializeField] private float repeatDelay = 1.0f;

    private bool hasPlayed;
    private float lastPlayTime = -999f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (playOnlyOnce && hasPlayed)
            return;

        if (Time.time < lastPlayTime + repeatDelay)
            return;

        PlayerFearParticles fearParticles = other.GetComponent<PlayerFearParticles>();

        if (fearParticles != null)
        {
            fearParticles.PlayFearEffect();
            hasPlayed = true;
            lastPlayTime = Time.time;
        }
    }
}