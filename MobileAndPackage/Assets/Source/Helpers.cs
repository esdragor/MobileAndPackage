using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Codice.Client.Commands;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Color;
using Object = UnityEngine.Object;

public class Helpers
{
    #region SetPos

    public static void SetPosX(Transform transform, float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void SetPosY(Transform t, float y)
    {
        t.position = new Vector3(t.position.x, y, t.position.z);
    }

    public void SetPosZ(Transform t, float z)
    {
        t.position = new Vector3(t.position.x, t.position.y, z);
    }

    #endregion

    #region SetScale

    public static void SetScaleX(Transform transform, float x)
    {
        transform.localScale = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void SetScaleY(Transform t, float y)
    {
        t.localScale = new Vector3(t.position.x, y, t.position.z);
    }

    public void SetScaleZ(Transform t, float z)
    {
        t.localScale = new Vector3(t.position.x, t.position.y, z);
    }

    #endregion

    public static void RotateinDeg(GameObject obj, Vector3 axis, float angle)
    {
        obj.transform.Rotate(axis, angle, Space.Self);
    }

    public static string PrintWithColor(string msg, Color c)
    {
        Color d = c;
        if (d == black)
            return "<color=black>" + msg + "</color>";
        if (d == red)
            return "<color=red>" + msg + "</color>";
        if (d == blue)
            return "<color=blue>" + msg + "</color>";
        return "<color=white>" + msg + "</color>";
    }

    public class Singleton<T> : MonoBehaviour where T : class
    {
        public static T Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }

    public class Pool<T> where T : Object
    {
        public readonly Queue<T> pool = new Queue<T>();
        public readonly T defaultItem;
        
        public Pool(T defaultItem)
        {
            this.defaultItem = defaultItem;
        }
        
        public void AddToPool(T ItemToAdd)
        {
            if (ItemToAdd is GameObject t)
                t.SetActive(false);
            pool.Enqueue(ItemToAdd);
        }
        
        public T GetFromPool()
        {
            return (pool.Count == 0) ? pool.Dequeue() : Object.Instantiate(defaultItem);
        }
        
        public IEnumerator AddToPoolAfterTime(T ItemToAdd, float time)
        {
            yield return new WaitForSeconds(time);
            AddToPool(ItemToAdd);
        }
    }
}