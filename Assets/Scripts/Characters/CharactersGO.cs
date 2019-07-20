using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MarioForOSC
{
    public class CharactersGO : BaseGameObject
    {
        private Transform seeCameraTF;
        private Transform marioTF;
        private Animator moveAnim;

        private Vector3 offPos;
        public override void Init()
        {
            base.Init();
            seeCameraTF = GetGameObjectByPath<Transform>("../seeCamera");
            marioTF = GetGameObjectByPath<Transform>("../mario");
            moveAnim = GetGameObjectByPath<Animator>("../mario");

            transform.localPosition = Vector3.zero;
            offPos = seeCameraTF.position - marioTF.position;
        }
        private void LateUpdate()
        {
            seeCameraTF.position = marioTF.position + offPos;
            transform.position = marioTF.position;
        }
        public override void RegistEvent()
        {
            base.RegistEvent();
            QEventSystem.RegisterEvent(MyEventType.CharacterMove, OnMove);
            QEventSystem.RegisterEvent(MyEventType.CharacterStop, OnStop);
        }
        private void OnMove(int key, object[] param)
        {
            //根据动画测测试出来这样运算旋转方向是对的，只适用于本项目的动画
            moveAnim.SetBool("Run", true);
            marioTF.LookAt(new Vector3(marioTF.position.x + (float)param[1], marioTF.position.y, marioTF.position.z - (float)param[0]));

        }
        private void OnStop(int key, object[] param)
        {
            moveAnim.SetBool("Run", false);
        }
        public override void RemoveEvent()
        {
            QEventSystem.UnRegisterEvent(MyEventType.CharacterMove, OnMove);
            base.RemoveEvent();
        }
        /// <summary>
        /// 碰撞检测
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerStay(Collider other)
        {
            if (other.tag == "PickCoin")
            {
                other.gameObject.SetActive(false);
            }
            if(other.tag == "Obstacle")
            {
                Debug.LogError("Your Death");
            }
        }
    }
}
