using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingObject : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float MoveTime = 0.1f;
    private float InverseMoveTime;

    protected virtual void AttemptMove(int Xdir, int Ydir)
    {
        Vector2 StartPosition = transform.position;
        Vector2 EndPosition = StartPosition + new Vector2(Xdir, Ydir);
        //�ړ�����p�@�Փ˂��郌�C���[�͂��ׂē����
        int LayerObj = LayerMask.GetMask(new string[] { "Chara", "Object" });
        //�U������p�@HP�̂���I�u�W�F�N�g��u�����C���[�͑S�ē����
        int LayerCha = LayerMask.GetMask(new string[] { "Chara" });

        this.rb = GetComponent<Rigidbody2D>();
        this.boxCollider = GetComponent<BoxCollider2D>();

        //���g�̏Փ˔���𖳂�����Physics2D�̌�m�F�𖳂���
        boxCollider.enabled = false;
        //�ړ���ɏ�Q�������邩���肷��
        RaycastHit2D HitObj = Physics2D.Linecast(StartPosition, EndPosition, LayerObj);
        RaycastHit2D HitCha = Physics2D.Linecast(StartPosition, EndPosition, LayerCha);
        //�Փ˔����߂�
        boxCollider.enabled = true;

        //RaycastHit2D�ňړ���ɏ�Q�����������Movement�����s
        if (HitObj.transform == null)
        {
            StartCoroutine(Movement(EndPosition));
        }
        //RaycastHit2D�ňړ���Ƀv���C���[���G�l�~�[�������HitComponent�ɓ����OnCantMove�����s
        else if (HitCha.transform != null)
        {
            GameObject HitComponent = HitCha.transform.gameObject;
            OnCantMove(HitComponent);
        }


    }

    protected IEnumerator Movement(Vector3 EndPosition)
    {
        float sqrRemainingDistance = (transform.position - EndPosition).sqrMagnitude;
        InverseMoveTime = 1f / MoveTime;
        //EndPosition�܂ŃX���[�Y�Ɉړ�����炵���@UNITY�����R�[�h�ۃp�N��
        while (sqrRemainingDistance > float.Epsilon)
        {
            Vector3 NewPosition = Vector3.MoveTowards(rb.position, EndPosition, InverseMoveTime * Time.deltaTime);
            rb.MovePosition(NewPosition);
            sqrRemainingDistance = (transform.position - EndPosition).sqrMagnitude;
            yield return null;
        }
    }

    protected abstract void OnCantMove(GameObject hitComponent);
}