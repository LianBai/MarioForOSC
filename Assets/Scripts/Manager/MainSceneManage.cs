using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using System;
using QF.Extensions;

namespace MarioForOSC
{
    public class MainSceneManage : BaseGameObject
    {
        private Transform selectplayer;
        private GameObject isSelectGo;
        public override void Init()
        {
            base.Init();
            selectplayer = GetGameObjectByPath<Transform>("selectplayer");
        }
        public override void RegistEvent()
        {
            base.RegistEvent();
            QEventSystem.RegisterEvent(MyEventType.ChangePlayer, OnChangePlayer);
        }
        public override void RemoveEvent()
        {
            base.RemoveEvent();
            QEventSystem.UnRegisterEvent(MyEventType.ChangePlayer, OnChangePlayer);
        }
        private void OnChangePlayer(int key, object[] param)
        {
            PlayerData data = (PlayerData)param[0];
            Transform isgo = selectplayer.Find(data.playerprefabname);
            if (isSelectGo != null)
                isSelectGo.SetActive(false);
            if (isgo != null) 
            {
                isSelectGo = isgo.gameObject;
                isSelectGo.SetActive(true);
            }
            else
            {
                GameObject go;
                go = GameObjectManager.instance.
                    InstanceGameObjectByPath("Resources/Prefab/Player/" + data.playerprefabname);
                go.name = data.playerprefabname;
                go.transform.parent = selectplayer;
                go.transform.LocalPosition(Vector3.one);
                go.transform.localEulerAngles = Vector3.one;
                isSelectGo = go;
            }
        }
    }
}
