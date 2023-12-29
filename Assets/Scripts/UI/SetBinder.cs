using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

// UI ���ӽ����̽�
namespace UI
{
    // Binder Ŭ������ UI ������Ʈ�� �����ϴ� Ŭ�����Դϴ�.
    // �� Ŭ������ UI ������Ʈ�� ã�Ƽ� �����ϰ�, �ʿ��� �ش� ������Ʈ�� ��ȯ�ϴ� ������ �մϴ�.
    public class Binder
    {
        // _objects ��ųʸ��� UI ������Ʈ�� �����մϴ�.
        // �� ��ųʸ��� Ű�� ������Ʈ�� Ÿ���̰�, ���� �� �ٸ� ��ųʸ��Դϴ�.
        // �̶� ���� ��ųʸ��� Ű�� ������Ʈ�� �̸��̰�, ���� �ش� �̸��� ������Ʈ �ν��Ͻ��Դϴ�.
        private readonly Dictionary<Type, Dictionary<string, Object>> _objects = new();

        // Binding �޼ҵ�� �־��� GameObject�� �ڽ� ������Ʈ �� Ÿ���� T�� �͵��� ã�Ƽ� _objects ��ųʸ��� �����մϴ�.
        // T�� ������Ʈ�� Ÿ���̸�, parentObject�� ������Ʈ�� ã�� �θ� GameObject�Դϴ�.
        // �� �޼ҵ�� parentObject�� ��� �ڽ� �߿��� Ÿ���� T�� ������Ʈ�� ã�Ƽ� _objects ��ųʸ��� �����ϰ�, �̸� AssignmentComponent �޼ҵ忡 �����մϴ�.
        public void Binding<T>(GameObject parentObject) where T : Object
        {
            T[] objects = parentObject.GetComponentsInChildren<T>(true);
            Dictionary<string, Object> objectDict = objects.ToDictionary(comp => comp.name, comp => comp as Object);
            _objects[typeof(T)] = objectDict;
            AssignmentComponent<T>(parentObject, objectDict);
        }

        // AssignmentComponent �޼ҵ�� _objects ��ųʸ��� ����� ������Ʈ���� ���� ���� ������Ʈ�� �Ҵ��մϴ�.
        // �� �޼ҵ�� Binding �޼ҵ忡�� ã�� ������Ʈ���� ������ �ش� ���� ������Ʈ�� �Ҵ��ϴ� ������ �մϴ�.
        private void AssignmentComponent<T>(GameObject parentObject, Dictionary<string, Object> objects) where T : Object
        {
            foreach (var key in objects.Keys.ToList())
            {
                if (objects[key] != null) continue;
                Object component = typeof(T) == typeof(GameObject)
                ? FindComponentDirectChild<GameObject>(parentObject, key)
                : FindComponentDirectChild<T>(parentObject, key);

                if (component != null) objects[key] = component;
                else Debug.Log($"Binding failed for Object : {key}");
            }
        }

        // FindComponentDirectChild �޼ҵ�� �־��� GameObject�� �������� �ڽ� �� �̸��� ��ġ�ϴ� ������Ʈ�� ã�� ��ȯ�մϴ�.
        // �� �޼ҵ�� parentObject�� �������� �ڽĵ� �߿��� �̸��� name�� ��ġ�ϴ� ������Ʈ�� ã�Ƽ� ��ȯ�մϴ�.
        private T FindComponentDirectChild<T>(GameObject parentObject, string name) where T : Object
        {
            return (from Transform child in parentObject.transform
                    where child.name == name
                    select child.GetComponent<T>()).FirstOrDefault();
        }

        // Getter �޼ҵ�� _objects ��ųʸ����� �־��� �̸��� ������Ʈ�� ��ȯ�մϴ�.
        // �� �޼ҵ�� _objects ��ųʸ��� ����� ������Ʈ �߿��� �̸��� componentName�� ��ġ�ϴ� ������Ʈ�� ��ȯ�մϴ�.
        // ���� �ش��ϴ� ������Ʈ�� ������ null�� ��ȯ�մϴ�.
        public T Getter<T>(string componentName) where T : Object
        {
            if (!_objects.TryGetValue(typeof(T), out Dictionary<string, Object> components)) return null;
            if (components.TryGetValue(componentName, out var component)) return component as T;
            return null;
        }
    }
}

