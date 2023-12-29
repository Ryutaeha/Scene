using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;

public class IntroScene : UIBase
{
    #region enum
    enum BTNNAME
    {
        StartBtn,
        ExitBtn,
        Button
    }
    enum SCENENAME
    {
        MainScene
    }
    #endregion
    protected override void Start()
    {
        base.Start(); // UIBase의 Start 메소드를 호출합니다.

        SetUI<Button>();
        SetUI<IntroSceneTransition>();

        SetBtnEvent();
    }

    void SetBtnEvent()
    {
        
        GetUI<Button>(((BTNNAME)2).ToString()).onClick.AddListener(() => StartScene());
    }
    private void StartScene()
    {
        GetUI<IntroSceneTransition>("Lord").StartSceneLord();
    }
}
