using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MovingObject
{
    public SpriteRenderer Spr; // �\���X�v���C�g
    public Animator anm; // �A�j���[�V�����R���|�[�l���g
    private GameObject Player; //�v���C���[�̍��W�擾�p
    private Vector2 TargetPos; //�v���C���[�̈ʒu���
    public GameObject HitEffect;
    public GameObject DeathEffect;

    //��������X�e�[�^�X
    [System.NonSerialized] public int Hp = 40; //HP
    [System.NonSerialized] public int Atk = 20; //�U����
    [System.NonSerialized] public int Def = 20; //�h���

    //�����܂ŃX�e�[�^�X

    public void MoveEnemy()
    {
        // PLAYER�^�O�̕t�����I�u�W�F�N�g���擾����
        Player = GameObject.FindGameObjectWithTag("Player");
        TargetPos = Player.transform.position;
        int Xdir = 0;
        int Ydir = 0;
        Xdir = (int)TargetPos.x - (int)this.transform.position.x;
        Ydir = (int)TargetPos.y - (int)this.transform.position.y;
        int AbsXdir = System.Math.Abs(Xdir); //��Βl���v�Z
        int AbsYdir = System.Math.Abs(Ydir); //��Βl���v�Z

        //�T�}�X�ȏ㗣�ꂢ�Ă��鎞�̓G�l�~�[�͈ړ���~
        if (AbsXdir > 5 || AbsYdir > 5)
        {
            return;
        }
        //�v���C���[�Ƃ̍��W����X���̕����傫���Ƃ�
        else if (AbsXdir > AbsYdir)
        {
            Xdir = Xdir / AbsXdir;
            AttemptMove(Xdir, 0);
        }
        //�v���C���[�Ƃ̍��W����Y���̕����傫���Ƃ�
        else if (AbsXdir < AbsYdir)
        {
            Ydir = Ydir / AbsYdir;
            AttemptMove(0, Ydir);
        }
        ////�v���C���[�Ƃ̍��W����X���EY���œ��������΂�45���Ƀv���C���[������
        //else if (AbsXdir == AbsYdir)
        //{
        //    Xdir = Xdir / AbsXdir;
        //    Ydir = Ydir / AbsYdir;
        //    AttemptMove(Xdir, Ydir);
        //}
    }

    //�p���N���XMovingObject�̃v���C���[�ړ����������s
    protected override void AttemptMove(int Xdir, int Ydir)
    {
        base.AttemptMove(Xdir, Ydir);
    }

    protected override void OnCantMove(GameObject hitComponent)
    {
        //�Փ˔���̂������I�u�W�F�N�g�̊֐����擾���A�ϐ������\�ɂ���
        Player Script = hitComponent.GetComponent<Player>();
        //�_���[�W�v�Z
        int Damage = Atk * Atk / (Atk + Script.Def);
        //�I�u�W�F�N�g��HP�ϐ��Ƀ_���[�W��^����
        Script.Hp -= Damage;
        Instantiate(HitEffect, new Vector3(hitComponent.transform.position.x, hitComponent.transform.position.y), Quaternion.identity);
        //HP��0�ȉ��ɂȂ�����G��Destroy���Ď��S�G�t�F�N�g���o������
        if (Script.Hp <= 0)
        {
            Destroy(hitComponent);
            Instantiate(DeathEffect, new Vector3(hitComponent.transform.position.x, hitComponent.transform.position.y), Quaternion.identity);
        }
        Debug.Log("�G�͂��Ȃ���" + Damage + "�̃_���[�W��^����");
        Debug.Log("���Ȃ��̎c��HP��" + Script.Hp);
    }

}