using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip bgm;
    public AudioClip hit;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = bgm;
        source.loop = true;
        source.Play();
    }

    public void Dead()
    {
        source.clip = hit;
        source.loop = false;
        source.Play();
    }
}
