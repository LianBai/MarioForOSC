using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class BaseGameObject : MonoBehaviour
    {
        //初始化是数据
        public virtual void Init()
        {
        }
        public virtual void RegistEvent()
        {

        }
        public virtual void RemoveEvent()
        {

        }
        public virtual void OnShow()
        {

        }
        public virtual void OnHide()
        {

        }
        private void Awake()
        {
            Init();
            RegistEvent();
        }
        private void OnEnable()
        {
            OnShow();
        }
        private void OnDisable()
        {
            OnHide();
        }
        private void OnDestroy()
        {
            RemoveEvent();
        }
        public GameObject GetGameObjectByPath(string path)
        {
            GameObject t = null;
            if (gameObject != null)
            {
                Transform tf = gameObject.transform.Find(path);
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
            if (gameObject != null)
            {
                Transform tf = gameObject.transform.Find(path);
                if (tf != null)
                {
                    t = tf.GetComponent<T>();
                }
            }
            return t;
        }
        public GameObject CreatGoAndSetPanet(GameObject go ,Transform paren)
        {
            GameObject newgo = GameObject.Instantiate(go);
            newgo.transform.parent = paren;
            newgo.SetActive(true);
            newgo.transform.localScale = Vector3.one;
            return newgo;
        }
    }
}
