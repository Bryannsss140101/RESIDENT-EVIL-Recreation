using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour
{
    [Header("Sound Settings")]
    [SerializeField] private AudioClip[] footsteps;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayFootSteps()
    {
        if (footsteps.Length == 0) return;

        AudioClip footstep = footsteps[Random.Range(0, footsteps.Length)];
        source.PlayOneShot(footstep, 0.7f);
    }
}