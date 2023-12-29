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
                // ServiceLocator �ν��Ͻ� ����
                _serviceLocator = new ServiceLocator();

                SetServiceLocator();
            }

            return _serviceLocator;
        }
    }

    private void SetServiceLocator()
    {
        // Binder �ν��Ͻ� ���� �� ���
        Binder binder = new();
        _serviceLocator.RegisterService(binder);
    }
}