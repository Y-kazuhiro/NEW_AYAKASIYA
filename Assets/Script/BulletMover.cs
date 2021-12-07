using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private Transform playerTrans; //’Ç‚¢‚©‚¯‚é‘ÎÛ‚ÌTransform
    [SerializeField] private float bulletSpeed;  @ //’e‚Ì‘¬“x
    [SerializeField] private float limitSpeed;      //’e‚Ì§ŒÀ‘¬“x
    private Rigidbody2D rb;                         //’e‚ÌRigidbody2D
    private Transform bulletTrans;                  //’e‚ÌTransform

    private void Awake()
    {
        if (playerTrans != null)
        {
            rb = GetComponent<Rigidbody2D>();
            bulletTrans = GetComponent<Transform>();
        }
    }

    private void FixedUpdate()
    {
        if (playerTrans != null)
        {
            Vector3 vector3 = playerTrans.position - bulletTrans.position;  //’e‚©‚ç’Ç‚¢‚©‚¯‚é‘ÎÛ‚Ö‚Ì•ûŒü‚ğŒvZ
            rb.AddForce(vector3.normalized * bulletSpeed);                  //•ûŒü‚Ì’·‚³‚ğ1‚É³‹K‰»A”CˆÓ‚Ì—Í‚ğAddForce‚Å‰Á‚¦‚é

            float speedXTemp = Mathf.Clamp(rb.velocity.x, -limitSpeed, limitSpeed); //X•ûŒü‚Ì‘¬“x‚ğ§ŒÀ
            float speedYTemp = Mathf.Clamp(rb.velocity.y, -limitSpeed, limitSpeed);  //Y•ûŒü‚Ì‘¬“x‚ğ§ŒÀ
            rb.velocity = new Vector3(speedXTemp, speedYTemp);           //ÀÛ‚É§ŒÀ‚µ‚½’l‚ğ‘ã“ü
        }
    }
}