using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MarioForOSC
{
    public class marioAnimation : BaseComponent
    {

        private Animation moveAnim;
        public override void Init()
        {
            base.Init();
            moveAnim = GetComponent<Animation>();
        }
        public override void RegistEvent()
        {
            base.RegistEvent();
            QEventSystem.RegisterEvent(MyEventType.CharacterMove, OnMove);
        }
        private void OnMove(int key, object[] param)
        {
            transform.LookAt(new Vector3(transform.position.x + (float)param[0], transform.position.y, transform.position.z + (float)param[1]));
        }
        public override void RemoveEvent()
        {
            QEventSystem.UnRegisterEvent(MyEventType.CharacterMove, OnMove);
            base.RemoveEvent();
        }
    }
}
