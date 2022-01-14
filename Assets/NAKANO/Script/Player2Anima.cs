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
                        if (Player1naka.Spell == 0)
                        {
                            Invoke("Stop", 3f);
                        }
                        else
                        {
                            Invoke("Stop", 0.3f);
                        }
                    }
                    else
                    {
                        Invoke("Stop", 0.3f);
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
                            Invoke("Stop", 0.3f);
                        }
                        else
                        {
                            Invoke("Stop", 3f);
                        }
                    }
                    else
                    {
                        Invoke("Stop", 0.3f);
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
                            Invoke("Stop", 0.3f);
                        }
                        else
                        {
                            Invoke("Stop", 3f);
                        }
                    }
                    else
                    {
                        Invoke("Stop", 0.3f);
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
                            Invoke("Stop", 0.3f);
                        }
                        else
                        {
                            Invoke("Stop", 3f);
                        }
                    }
                    else
                    {
                        Invoke("Stop", 0.3f);
                    }
                }
            }



            //SP範囲攻撃アニメーション
            if (Player1naka.PlayerSPLock == true && Player1naka.PlayerSPAttack >= 1 && Input.GetKeyDown(KeyCode.Q))//スペースで攻撃
            {
                anim.SetTrigger("SPAttack");
            }

            //SP直線攻撃アニメーション
            if (Player1naka.PlayerSPLock == true && Player1naka.PlayerSPAttack >= 1 && Input.GetKeyDown(KeyCode.E))//スペースで攻撃
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

    void Stop()
    {
        stop = false;
    }
}