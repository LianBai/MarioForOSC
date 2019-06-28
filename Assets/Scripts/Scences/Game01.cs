using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
/// <summary>
/// ��ʼ������һЩ��Դ
/// </summary>
namespace MarioForOSC
{
    public class Game01 : MonoBehaviour
    {
        [SerializeField()]
        public GameObject CharactersGo;
        private void Awake()
        {
            GameObjectManager.instance.ShowPrefab(EnumPrefabId.Characters);
            //QEventSystem.RegisterEvent<MyEventType>(MyEventType.LateUpdateEvent, OnLateUpdate);
        }

        private void Update()
        {
            QEventSystem.SendEvent(MyEventType.OnUpdateEvent);
        }
        private void FixedUpdate()
        {
            QEventSystem.SendEvent(MyEventType.FixUpdateEvent);
        }
        private void LateUpdate()
        {
            QEventSystem.SendEvent(MyEventType.LateUpdateEvent);
        }

    }
}
