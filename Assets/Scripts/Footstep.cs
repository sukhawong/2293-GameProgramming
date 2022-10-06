using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    [SerializeField] AudioSource walkSoundEffect;
    [SerializeField] AudioSource walk2SoundEffect;
    [SerializeField] AudioSource fallSoundEffect;
    private void WalkSound()
    {
        walkSoundEffect.Play();
    }

    private void WalkSound2()
    {
        walk2SoundEffect.Play();
    }

    private void fallSound()
    {
        fallSoundEffect.Play();
    }
}
