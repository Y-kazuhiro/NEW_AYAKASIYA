using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBGM : MonoBehaviour
{
    public static bool active = false;//行動開始

    AudioSource audioSource;
    public AudioClip sound1;

    private GameObject[] EGhostObjects;  //GameObjectにPlayerObjectsを格納します

    void Start()
    {
        active = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        EGhostObjects = GameObject.FindGameObjectsWithTag("EGhost");

        if (EGhostObjects.Length == 0 && active == false)//EGhostが消えると動き出す
        {
            active = true;
            Invoke("BGM", 1);
        }
    }

    void BGM()
    {
        audioSource.PlayOneShot(sound1);
    }

}
