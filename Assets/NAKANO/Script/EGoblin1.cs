using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGoblin1 : MonoBehaviour
{
    //ìGèÓïÒ
    public float EnemyHPGob1 = 6;
    public float EnemyHPGob1MAX = 6;
    public static float HP = 6;
    public static float HPMAX = 6;
    public float EnemyPOWERGob1 = 2;
    public float EnemyEXPGob1 = 10;
    public float EnemyPointGob1 = 1;
    public float EnemyYouki = 1;

    public static bool Event = false;

    public bool isDamage = false;
    public SpriteRenderer sp;

    Animator anim;

    AudioSource audioSource;
    public AudioClip sound1;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HP = EnemyHPGob1;
        HPMAX = EnemyHPGob1MAX;

        if (isDamage == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 18));
            sp.color = new Color(1f, 1f, 1f, level);
            StartCoroutine(OnDamage());
        }

        if (EnemyHPGob1 < 0)
        {
            EnemyHPGob1 -= EnemyHPGob1;
        }

        if (EnemyHPGob1 <= 0 && Event == false)//ëÃóÕÇ™ÇOà»â∫Ç…Ç»ÇÈÇ∆è¡Ç¶ÇÈ
        {
            Event = true;

            audioSource.PlayOneShot(sound1);

            GetComponent<BoxCollider2D>().enabled = false;

            anim.SetTrigger("Die");
            Player1naka.PlayerEXP += EnemyEXPGob1;
            Player1naka.NEXTPoint += EnemyPointGob1;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("-----------------------------------------------------");
            Invoke("Die", 1);
        }
    }

    void Die()
    {
        Event = false;
        Destroy(this.gameObject);//ÇPïbå„Ç…è¡Ç¶ÇÈ
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= EnemyPOWERGob1;//PlayerÇ…çUåÇ

            if (Player1naka.PlayerHP < 0)
            {
                Player1naka.PlayerHP -= Player1naka.PlayerHP;
            }

            Debug.Log("<color=red>Åö</color>" + EnemyPOWERGob1 + "ÇÃÉ_ÉÅÅ[ÉWÇéÛÇØÇΩ");
            Debug.Log("<color=blue>Åö</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
            isDamage = true;
        }


    }

    IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.35f);//0.35ïbì_ñ≈Ç∑ÇÈ
                                               // í èÌèÛë‘Ç…ñﬂÇ∑
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }
}