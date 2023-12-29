using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{


    public void FadeOutScene(string sceneName)
    {
        Image image = gameObject.GetComponent<Image>();
        image.raycastTarget = true;
        image.DOFade(1, 1).SetEase(Ease.InOutQuad)
            .OnComplete(() =>
            {
                LodingSceneController.LoadScene(sceneName);
            });
    }

}
