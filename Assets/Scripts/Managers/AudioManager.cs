using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Audio;

    public AudioClip playLoseClip;

    private Vector3 cameraPos;

    void Awake()
    {
        Audio = this;
        cameraPos = Camera.main.transform.position;
    }

    public void PlaySoud(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, cameraPos);
    }

    public void PlayLoseClip()
    {
        PlaySoud(playLoseClip);
    }
}
