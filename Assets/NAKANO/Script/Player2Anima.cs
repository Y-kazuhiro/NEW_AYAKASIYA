using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Anima : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�U���A�j���[�V����
        if (Input.GetKeyDown(KeyCode.Space))//�X�y�[�X�ōU��
        {
            if (Player1naka.PlayerMUKI == 1)
                anim.SetTrigger("AttackUE");

            if (Player1naka.PlayerMUKI == 2)
                anim.SetTrigger("AttackSITA");

            if (Player1naka.PlayerMUKI == 3)
                anim.SetTrigger("AttackMIGI");

            if (Player1naka.PlayerMUKI == 4)
                anim.SetTrigger("AttackHIDARI");
        }



        //SP�͈͍U���A�j���[�V����
        if (Player1naka.PlayerSPLock == true && Player1naka.PlayerSPAttack >= 1 && Input.GetKeyDown(KeyCode.Q))//�X�y�[�X�ōU��
        {
            anim.SetTrigger("SPAttack");
        }

        //SP�����U���A�j���[�V����
        if (Player1naka.PlayerSPLock == true && Player1naka.PlayerSPAttack >= 1 && Input.GetKeyDown(KeyCode.E))//�X�y�[�X�ōU��
        {
            if (Player1naka.PlayerMUKI == 1)
                anim.SetTrigger("SPAttackUE");

            if (Player1naka.PlayerMUKI == 2)
                anim.SetTrigger("SPAttackSITA");

            if (Player1naka.PlayerMUKI == 3)
                anim.SetTrigger("SPAttackMIGI");

            if (Player1naka.PlayerMUKI == 4)
                anim.SetTrigger("SPAttackHIDARI");
        }
    }
}