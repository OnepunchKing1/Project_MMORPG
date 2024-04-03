using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager
{
    public T Load<T>(string path) where T : Object
    {
        string name = path;
        int index = name.LastIndexOf('/');
        if (index >= 0)
            name = name.Substring(index + 1);

        GameObject go = Managers.Pool.GetOriginal(name);
        if (go != null)
            return go as T;

        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        // original 이미 들고 있으면 바로 사용
        GameObject original = Load<GameObject>($"Prefabs/{path}");
        if (original == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }
        // 혹시 풀링된 애가 있을까?

        if (original.GetComponent<Poolable>() != null) // 풀링 대상
            return Managers.Pool.Pop(original, parent).gameObject;

        GameObject go = Object.Instantiate(original, parent); // 풀링 비대상
        go.name = original.name;

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;
        // 만약 풀링이 필요한 아이라면 -> 풀링 매니저 위탁
        Poolable poolable = go.GetComponent<Poolable>();
        if(poolable != null)
        {
            Managers.Pool.Push(poolable);
            return;
        }

        Object.Destroy(go);
    }

}
