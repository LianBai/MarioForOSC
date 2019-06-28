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
        //��ʼ��������
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
