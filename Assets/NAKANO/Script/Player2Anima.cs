using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Anima : MonoBehaviour
{
    public static bool stop = false;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1naka.PlayerHP >= 1 && stop == false)
        {
            //攻撃アニメーション
            if (Input.GetKeyDown(KeyCode.Space))//スペースで攻撃
            {
                if (Player1naka.PlayerMUKI == 1)
                {
                    anim.SetTrigger("AttackUE");
                    stop = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (Player1naka.Spell == 0)//
                        {
                            Invoke("Stop", 3f);
                        }
                        else
                        {
                            Invoke("Stop", 1.0f);
                        }
                    }
                    else
                    {
                        Invoke("Stop", 1.0f);
                    }

                }

                if (Player1naka.PlayerMUKI == 2)
                {
                    anim.SetTrigger("AttackSITA");
                    stop = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (Player1naka.Spell == 2)
                        {
                            Invoke("Stop", 1.0f);
                        }
                        else
                        {
                            Invoke("Stop", 3f);
                        }
                    }
                    else
                    {
                        Invoke("Stop", 1.0f);
                    }
                }

                if (Player1naka.PlayerMUKI == 3)
                {
                    anim.SetTrigger("AttackMIGI");
                    stop = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (Player1naka.Spell == 2)
                        {
                            Invoke("Stop", 1.0f);
                        }
                        else
                        {
                            Invoke("Stop", 3f);
                        }
                    }
                    else
                    {
                        Invoke("Stop", 1.0f);
                    }
                }

                if (Player1naka.PlayerMUKI == 4)
                {
                    anim.SetTrigger("AttackHIDARI");
                    stop = true;
                    if (SceneManager.GetActiveScene().name == "Last")
                    {
                        if (Player1naka.Spell == 2)
                        {
                            Invoke("Stop", 1.30f);
                        }
                        else
                        {
                            Invoke("Stop", 3f);
                        }
                    }
                    else
                    {
                        Invoke("Stop", 1.0f);
                    }
                }
            }



            //SP範囲攻撃アニメーション
            if (Player1naka.PlayerSPLock == true && Player1naka.PlayerSPAttack >= 1 && Input.GetKeyDown(KeyCode.Q))//スペースで攻撃
            {
                stop = true;
                anim.SetTrigger("SPAttack");
                Invoke("Stop", 1.0f);//連発できないようにちょっと待つ
            }

            //SP直線攻撃アニメーション
            if (Player1naka.PlayerSPLock == true && Player1naka.PlayerSPAttack >= 1 && Input.GetKeyDown(KeyCode.E))//スペースで攻撃
            {
                if (Player1naka.PlayerMUKI == 1)
                {
                    stop = true;
                    anim.SetTrigger("SPAttackUE");
                    Invoke("Stop", 1.0f);
                }

                if (Player1naka.PlayerMUKI == 2)
                {
                    stop = true;
                    anim.SetTrigger("SPAttackSITA");
                    Invoke("Stop", 1.0f);
                }

                if (Player1naka.PlayerMUKI == 3)
                {
                    stop = true;
                    anim.SetTrigger("SPAttackMIGI");
                    Invoke("Stop", 1.0f);
                }

                if (Player1naka.PlayerMUKI == 4)
                {
                    stop = true;
                    anim.SetTrigger("SPAttackHIDARI");
                    Invoke("Stop", 1.0f);
                }                
            }
        }

        if (Player1naka.Playerlevelflag == true)//レベルアップアニメーション
        {
            anim.SetTrigger("レベルup");
            Player1naka.Playerlevelflag = false;
        }


        if (Player1naka.PlayerKAIHUKUflag == true)//回復アニメーション
        {
            anim.SetTrigger("回復");
            Player1naka.PlayerKAIHUKUflag = false;
        }

        if(Player1naka.YOUKILock==true)
        {
            anim.SetTrigger("YOUKI");
            Player1naka.YOUKILock = false;
            Player1naka.Youki++;
        }
    }

    void Stop()
    {
        stop = false;
    }
}