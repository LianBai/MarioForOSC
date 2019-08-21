using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class BaseGameSceneManage : MonoBehaviour
    {

        private void Awake()
        {
            OnInit();
        }
        private void Start()
        {
            OnShow();
        }
        // Update is called once per frame
        void Update()
        {

        }
        public virtual void OnInit()
        {
            
        }
        public virtual void OnShow()
        {

        }
        public void ReshUpdate()
        {

        }
        public void ReshFixUpdate()
        {

        }
        public void ReshLateUpdate()
        {

        }
    }
}