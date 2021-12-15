using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVo : MonoBehaviour
{
    public static bool active = false;//çsìÆäJén

    AudioSource audioSource;
    public AudioClip sound1;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Boss.Voice == true && active == false)
        {
            active = true;
            audioSource.PlayOneShot(sound1);
        }
    }
}
