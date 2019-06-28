using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

namespace MarioForOSC
{
    public class BasePrefab
    {
        //该物体的Prefab
        protected GameObject m_Prefab = null;

        //初始化Prefabl
        public virtual void OnInit(EnumPrefabId id)
        {
            m_Prefab =  EnumPrefabManager.instance.GetPrefab(id);
            GameObject.Instantiate(m_Prefab);
        }


        public virtual void Init()
        {

        }
        public virtual void RegistEvent()
        {

        }
        public virtual void OnHide()
        {
            m_Prefab.SetActive(false);
        }
        public GameObject GetGameObjectByPath(string path)
        {
            GameObject t = null;
            if (m_Prefab != null)
            {
                Transform tf = m_Prefab.transform.Find(path);
                if (tf != null)
                {
                    t = tf.gameObject;
                }
            }
            return t;
        }
        public T GetGameObjectByPath<T>(string path) where T : Component
        {
            T t = null;
            if (m_Prefab != null)
            {
                Transform tf = m_Prefab.transform.Find(path);
                if (tf != null)
                {
                    t = tf.GetComponent<T>();
                }
            }
            return t;
        }

    }
}
