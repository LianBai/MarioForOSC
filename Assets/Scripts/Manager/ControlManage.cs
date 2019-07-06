using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MarioForOSC
{
    public class ControlManage : MonoBehaviour
    {

        public void Move(Vector2 v)
        {
            QEventSystem.SendEvent(MyEventType.CharacterMove, v.x, v.y);
        }
        public void StopMove()
        {
            QEventSystem.SendEvent(MyEventType.CharacterStop);
        }
    }
}
