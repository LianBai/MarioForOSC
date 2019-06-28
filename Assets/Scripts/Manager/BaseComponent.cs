using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class BaseComponent : MonoBehaviour
    {
        private void Awake()
        {
            Init();
            RegistEvent();
        }
        private void OnDisable()
        {
            OnHide();
        }
        private void OnDestroy()
        {
            RemoveEvent();
        }
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
    }
}
