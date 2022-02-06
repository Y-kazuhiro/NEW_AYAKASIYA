using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETree : MonoBehaviour
{
    //“Gî•ñ
    public float EnemyHPT = 35;
    public float EnemyHPTMAX = 35;
    public static float HP = 35;
    public static float HPMAX = 35;
    public float EnemyPOWERT = 2;
    public float EnemyEXPT = 40;
    public float EnemyPointT = 5;
    public float EnemyYouki = 5;

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
        HP = EnemyHPT;
        HPMAX = EnemyHPTMAX;

        if (isDamage == true)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 18));
            sp.color = new Color(1f, 1f, 1f, level);
            StartCoroutine(OnDamage());
        }

        if (EnemyHPT <= 0 && Event == false)//‘Ì—Í‚ª‚OˆÈ‰º‚É‚È‚é‚ÆÁ‚¦‚é
        {
            Event = true;

            if (EnemyHPT < 0)
            {
                EnemyHPT -= EnemyHPT;
            }

            audioSource.PlayOneShot(sound1);

            GetComponent<BoxCollider2D>().enabled = false;

            anim.SetTrigger("Die");
            Player1naka.PlayerEXP += EnemyEXPT;
            Player1naka.NEXTPoint += EnemyPointT;
            Player1naka.Youki += EnemyYouki;
            Debug.Log("<color=blue>š</color>" + "ŒoŒ±’l" + EnemyEXPT + "ƒQƒbƒg");
            Debug.Log("<color=blue>š</color>" + "ƒŒƒxƒ‹ƒAƒbƒv‚Ü‚Å" + Player1naka.PlayerEXP + "/ 100");
            Debug.Log("<color=blue>š</color>" + "—d‹C‚ğ" + EnemyYouki + "ŒÂæ“¾");
            Debug.Log("<color=blue>š</color>" + "Œ»İ‚Ì—d‹C”‚Í" + Player1naka.Youki + "ŒÂ");

            //if(Player1naka.Youki < 15)
            //{
            //Debug.Log("<color=blue>š</color>" + "—d‹C‚ğ" + EnemyYouki + "ŒÂæ“¾");
            //Debug.Log("<color=blue>š</color>" + "Œ»İ‚Ì—d‹C”‚Í" + Player1naka.Youki + "ŒÂ");
            //}
            //if (Player1naka.Youki >= 15)
            //{
            //    Debug.Log("<color=blue>š</color>" + "—d‹C‚ğ" + EnemyYouki + "ŒÂæ“¾");
            //    Debug.Log("<color=blue>š</color>" + "Œ»İ‚Ì—d‹C”‚Í" + Player1naka.Youki + "ŒÂ");
            //    Debug.Log("<color=blue>š</color>" + "•KE‹Z‚ªg‚¦‚é‚æ‚¤‚É‚È‚Á‚½");
            //}
            Debug.Log("-----------------------------------------------------");
            Invoke("Die", 1);
        }
    }

    void Die()
    {
        Event = false;
        Destroy(this.gameObject);//‚P•bŒã‚ÉÁ‚¦‚é
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player1naka.PlayerHP -= EnemyPOWERT;//Player‚ÉUŒ‚

            if(Player1naka.PlayerHP < 0)
            {
                Player1naka.PlayerHP -= Player1naka.PlayerHP;
            }

            Debug.Log("<color=red>š</color>" + EnemyPOWERT + "‚Ìƒ_ƒ[ƒW‚ğó‚¯‚½");
            Debug.Log("<color=blue>š</color>" + "HP" + Player1naka.PlayerHP);
            Debug.Log("-----------------------------------------------------");
            isDamage = true;
        }
        //animator.SetTrigger("Death");   //“|‚ê‚éƒAƒjƒ‚ÉˆÚs

    }
    IEnumerator OnDamage()
    {
        yield return new WaitForSeconds(0.35f);//0.35•b“_–Å‚·‚é
                                               // ’Êíó‘Ô‚É–ß‚·
        isDamage = false;
        sp.color = new Color(1f, 1f, 1f, 1f);
    }
}