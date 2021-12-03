using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //３つのPanelを格納する変数
    //インスペクターウィンドウからゲームオブジェクトを設定する
    [SerializeField] GameObject CommandPanel;
    [SerializeField] GameObject CutPanel;
    [SerializeField] GameObject SkillPanel;

    // Start is called before the first frame update
    void Start()
    {
        //BackToMenuメソッドを呼び出す
        BackToMenu();
    }

    //MenuPanelでXR-HubButtonが押されたときの処理
    //XR-HubPanelをアクティブにする
    public void SelectXrHubDescription()
    {
        CommandPanel.SetActive(true);
        CutPanel.SetActive(true);
        SkillPanel.SetActive(false);
    }


    //MenuPanelでUnityButtonが押されたときの処理
    //UnityPanelをアクティブにする
    public void SelectUnityDescription()
    {
        CommandPanel.SetActive(true);
        CutPanel.SetActive(false);
        SkillPanel.SetActive(true);
    }

    //2つのDescriptionPanelでBackButtonが押されたときの処理
    //MenuPanelをアクティブにする
    public void BackToMenu()
    {
        CommandPanel.SetActive(true);
        CutPanel.SetActive(false);
        SkillPanel.SetActive(false);
    }

}