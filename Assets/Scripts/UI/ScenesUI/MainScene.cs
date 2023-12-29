using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : UIBase
{
    #region enum
    enum BTNNAME
    {
        Button
    }
    enum SCENENAME
    {
        IntroScene
    }
    #endregion

    protected override void Start()
    {
        base.Start(); // UIBase의 Start 메소드를 호출합니다.

        SetUI<Button>();
        SetUI<FadeOut>();

        SetBtnEvent();
    }

    void SetBtnEvent()
    {
        GetUI<Button>(((BTNNAME)0).ToString()).onClick.AddListener(() => NextScene(((SCENENAME)0).ToString()));
    }
    private void NextScene(string sceneName)
    {
        GetUI<FadeOut>("FadeOut").FadeOutScene(sceneName);
    }
}
