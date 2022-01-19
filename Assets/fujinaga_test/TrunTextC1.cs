using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrunTextC1 : MonoBehaviour
{

    public GameObject Trun_object = null;
    

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //ステージ別のポイント表示分岐
        //↓↓↓↓↓↓↓↓↓
        
        //第1ステージ
        //if ()
        //{
            Text Trun_text = Trun_object.GetComponent<Text>();

　　　　　　//次のステージへ行くポイント条件表示
            //溜まると次のステージに行けるようになる(第2ステージへ)
            Trun_text.text = "<color=red>次のステージまで</color> "
            + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT1;//赤色
        //}

        //第2ステージ
        //if()
        //{
        //    Text Trun_text = Trun_object.GetComponent<Text>();

        //    //次のステージへ行くポイント条件表示
        //    //溜まると次のステージに行けるようになる(第3ステージへ)
        //    Trun_text.text = "<color=red>次のステージまで</color> "
        //    + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT2;//赤色
        //}

        //第3ステージ
        //if()
        //{
        //    Text Trun_text = Trun_object.GetComponent<Text>();

        //    //次のステージへ行くポイント条件表示
        //    //溜まると次のステージに行けるようになる(第4ステージへ)
        //    Trun_text.text = "<color=red>次のステージまで</color> "
        //    + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT3;//赤色
        //}

        //第4ステージ
        //if()
        //{
        //    Text Trun_text = Trun_object.GetComponent<Text>();

        //    //次のステージへ行くポイント条件表示
        //    //溜まると次のステージに行けるようになる(ラストステージへ)
        //    Trun_text.text = "<color=red>次のステージまで</color> "
        //    + Player1naka.NEXTPoint + "/" + Player1naka.NEXTCOUNT4;//赤色
        //}
    }
}