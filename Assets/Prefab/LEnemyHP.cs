using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEnemyHP : MonoBehaviour
{
    public GameObject Trun_object = null;

    // Update is called once per frame
    void Update()
    {
        Text Trun_text = Trun_object.GetComponent<Text>();
        Trun_text.text = LEnemy.HP + "/" + LEnemy.HPMAX;
    }
}