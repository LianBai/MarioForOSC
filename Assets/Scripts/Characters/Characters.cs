using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;

namespace MarioForOSC
{
    public class Characters : BasePrefab
    {

        private Transform player;
        private Transform camera;
        private Vector3 offerPos;
        private CapsuleCollider playerCollider;
        public override void Init()
        {
            base.OnInit(EnumPrefabId.Characters);

            offerPos = new Vector3();

            camera = GetGameObjectByPath<Transform>("seeCamera");
            player = GetGameObjectByPath<Transform>("mario");
            
            playerCollider = GetGameObjectByPath<CapsuleCollider>("mario");

            offerPos = camera.localPosition - player.localPosition;
            m_Prefab.transform.localPosition = new Vector3(-3, 6, -30);

            RegistEvent();
        }
        public override void RegistEvent()
        {
            QEventSystem.RegisterEvent(MyEventType.LateUpdateEvent, OnLateUpdate);
        }

        private void OnLateUpdate(int key, object[] param)
        {
            camera.localPosition = player.localPosition + offerPos;
        }
        public override void OnHide()
        {
            base.OnHide();
            QEventSystem.UnRegisterEvent(MyEventType.LateUpdateEvent, OnLateUpdate);
        }
        /// <summary>
        /// µ¥ÀýÄ£Ê½
        /// </summary>
        private static Characters _instance = null;
        public static Characters instance
        {
            get { return _instance ?? (_instance = new Characters()); }
        }
    }
}

