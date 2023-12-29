using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class GameManager
{

    private ServiceLocator _serviceLocator;
    public ServiceLocator ServiceLocator 
    {
        get
        {
            if (_serviceLocator == null)
            {
                // ServiceLocator 인스턴스 생성
                _serviceLocator = new ServiceLocator();

                SetServiceLocator();
            }

            return _serviceLocator;
        }
    }

    private void SetServiceLocator()
    {
        // Binder 인스턴스 생성 및 등록
        Binder binder = new();
        _serviceLocator.RegisterService(binder);
    }
}