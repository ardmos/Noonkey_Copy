using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 효과음 관리하는 컨트롤러 입니다~
/// </summary>

public class SFX_Controller : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public enum Sounds
    {
        levelup,
        skill,
        hearflower,
        create,
        extra,
        tear
    }
    public void PlaySFX(Sounds sounds)
    {
        switch (sounds)
        {
            case Sounds.levelup:
                audioSource.PlayOneShot(audioClips[0]);
                break;
            case Sounds.skill:
                audioSource.PlayOneShot(audioClips[1]);
                break;
            case Sounds.hearflower:
                audioSource.PlayOneShot(audioClips[2]);
                break;
            case Sounds.create:
                audioSource.PlayOneShot(audioClips[3]);
                break;
            case Sounds.extra:
                audioSource.PlayOneShot(audioClips[4]);
                break;
            case Sounds.tear:
                audioSource.PlayOneShot(audioClips[5]);
                break;
            default:
                break;
        }
    }
}
