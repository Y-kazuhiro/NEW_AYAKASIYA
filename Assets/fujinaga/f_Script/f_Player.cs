using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public class Player : MovingObject
//{
//    public SpriteRenderer Spr; // �\���X�v���C�g
//    public Animator anm; // �A�j���[�V�����R���|�[�l���g
//    public GameObject GameManager;
//    public GameState PlayerState;
//    public GameObject HitEffect;
//    public GameObject DeathEffect;

//    //��������X�e�[�^�X
//    [System.NonSerialized] public int Hp = 100; //HP
//    [System.NonSerialized] public int Atk = 30; //�U����
//    [System.NonSerialized] public int Def = 25; //�h���

//    //�����܂ŃX�e�[�^�X

//    void Update()
//    {
//        int horizontal = 0; //��������
//        int vertical = 0; //��������
//        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
//        vertical = (int)(Input.GetAxisRaw("Vertical"));

//        if (horizontal != 0 || vertical != 0)
//        {
//            AttemptMove(horizontal, vertical);
//        }

//    }

//    //�p���N���XMovingObject�̃v���C���[�ړ����������s
//    protected override void AttemptMove(int Xdir, int Ydir)
//    {
//        GameManager = GameObject.FindGameObjectWithTag("GameManager");
//        PlayerState = GameManager.GetComponent<GameManager>().CurrentGameState;

//        if (PlayerState == GameState.KeyInput)
//        {
//            base.AttemptMove(Xdir, Ydir);
//            GameManager.GetComponent<GameManager>().SetCurrentState(GameState.PlayerTurn);
//        }
//    }

//    //�G�l�~�[�ɗ^����_���[�W���v�Z���ė^����
//    protected override void OnCantMove(GameObject hitComponent)
//    {
//        //�Փ˔���̂������I�u�W�F�N�g�̊֐����擾���A�ϐ������\�ɂ���
//        Enemy Script = hitComponent.GetComponent<Enemy>();
//        //�_���[�W�v�Z
//        int Damage = Atk * Atk / (Atk + Script.Def);
//        //�I�u�W�F�N�g��HP�ϐ��Ƀ_���[�W��^����
//        Script.Hp -= Damage;
//        Instantiate(HitEffect, new Vector3(hitComponent.transform.position.x, hitComponent.transform.position.y), Quaternion.identity);
//        //HP��0�ȉ��ɂȂ�����G��Destroy���Ď��S�G�t�F�N�g���o������
//        if (Script.Hp <= 0)
//        {
//            Destroy(hitComponent);
//            Instantiate(DeathEffect, new Vector3(hitComponent.transform.position.x, hitComponent.transform.position.y), Quaternion.identity);
//        }
//        Debug.Log("���Ȃ���" + Damage + "�̃_���[�W��^����");
//        Debug.Log("�G�̎c��HP��" + Script.Hp);
//    }

//}