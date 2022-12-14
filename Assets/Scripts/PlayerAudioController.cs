using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioPlayer audioPlayer;

    [Header("Particles")]
    [SerializeField] private ParticleSystem walk;
    [SerializeField] private ParticleSystem fall;
    [SerializeField] private ParticleSystem death;
    
    [Header("Audio Clips")]
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips deathAudioClips;

    public void PlayJump()
    {
        audioPlayer.PlaySound(jumpAudioClips, 0.5f);
    }

    public void PlayWalk()
    {
        walk.Play();
        audioPlayer.PlaySound(walkAudioClips, 0.3f);
    }

    public void PlayFallImpact()
    {
        fall.Play();
        audioPlayer.PlaySound(walkAudioClips, 0.6f);
    }

    public void PlayDeath()
    {
        death.Play();
        audioPlayer.PlaySound(deathAudioClips);
    }
    
    public void MuteAudioSource()
    {
        audioPlayer.MuteAudioSource();
    }

}
