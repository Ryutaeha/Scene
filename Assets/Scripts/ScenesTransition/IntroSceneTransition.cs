using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IntroSceneTransition : MonoBehaviour
{
    [SerializeField]
    private Image transitionMaterialImage;

    [SerializeField]
    private float transitionTime = 1f;

    [SerializeField]
    private string propertyName = "_Progress";

    [SerializeField]
    private float maxValue;

    private void Start()
    {
        transitionMaterialImage.material.SetFloat(propertyName, maxValue);
        transitionMaterialImage.raycastTarget = false;
    }

    public void StartSceneLord()
    {
        StartCoroutine(TransitionCoroutine());
        transitionMaterialImage.raycastTarget = true;
    }

    private IEnumerator TransitionCoroutine()
    {
        float currentTime = maxValue;
        while (currentTime > 0 )
        {
            currentTime -= Time.deltaTime;
            transitionMaterialImage.material.SetFloat(propertyName, Mathf.Clamp((currentTime/transitionTime) * maxValue,0,2));
            yield return null;
        }
        LordScenes();
    }

    public void LordScenes()
    {
        LodingSceneController.LoadScene("MainScene");
    }
}

