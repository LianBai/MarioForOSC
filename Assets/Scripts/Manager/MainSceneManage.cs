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
        private Transform _selectplayer;
        private GameObject _isSelectGo;
        public override void Init()
        {
            base.Init();
            _selectplayer = GetGameObjectByPath<Transform>("selectplayer");
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
            var data = (PlayerData)param[0];
            var isgo = _selectplayer.Find(data.playerprefabname);
            if (_isSelectGo != null)
                _isSelectGo.SetActive(false);
            if (isgo != null) 
            {
                _isSelectGo = isgo.gameObject;
                _isSelectGo.SetActive(true);
            }
            else
            {
                GameObject go;
                go = GameObjectManager.instance.
                    InstanceGameObject(data.playerprefabname);
                go.name = data.playerprefabname;
                go.transform.parent = _selectplayer;
                go.transform.LocalPosition(Vector3.one);
                go.transform.localEulerAngles = Vector3.one;
                _isSelectGo = go;
            }
        }
    }
}
