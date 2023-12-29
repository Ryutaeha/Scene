using System;
using System.Collections.Generic;
using UnityEngine;  
using Object = UnityEngine.Object;

namespace UI
{
    // UIBase Ŭ������ Binder Ŭ������ �̿��ؼ� �ڽ��� �ڽ� ������Ʈ���� �����ϴ� Ŭ�����Դϴ�.
    public class UIBase : MonoBehaviour
    {
        private Binder _binder;

        // Start �޼ҵ忡�� ServiceLocator�� ���� Binder �ν��Ͻ��� �����ɴϴ�.
        protected virtual void Start()
        {
            _binder = Main.Game.ServiceLocator.GetService<Binder>();
        }

        // SetUI �޼ҵ忡���� �ڽ��� �ڽ� ������Ʈ �� Ÿ���� T�� �͵��� Binder�� ����մϴ�.
        protected void SetUI<T>() where T : Object
        {
            _binder.Binding<T>(gameObject);
        }

        // GetUI �޼ҵ忡���� Binder�� ���� �־��� �̸��� ������Ʈ�� �����ɴϴ�.
        protected T GetUI<T>(string componentName) where T : Object
        {
            return _binder.Getter<T>(componentName);
        }
    }
}