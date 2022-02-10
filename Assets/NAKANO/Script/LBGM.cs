using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBGM : MonoBehaviour
{
    public static bool active = false;//�s���J�n

    AudioSource audioSource;
    public AudioClip sound1;

    private GameObject[] EGhostObjects;  //GameObject��PlayerObjects���i�[���܂�

    void Start()
    {
        active = false;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        EGhostObjects = GameObject.FindGameObjectsWithTag("EGhost");

        if (EGhostObjects.Length == 0 && active == false)//EGhost��������Ɠ����o��
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
