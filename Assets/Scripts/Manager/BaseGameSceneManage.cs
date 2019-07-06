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

        // Update is called once per frame
        void Update()
        {

        }
        public virtual void OnInit()
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