using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MarioForOSC
{
    public class PlayerItem : BaseGameObject
    {
        private PlayerData data;
        private Image bg;
        private Image icon;
        private string iconPath;
        private Toggle playerToggle;
        public override void Init()
        {
            base.Init();
            bg = GetComponent<Image>();
            icon = GetGameObjectByPath<Image>("icon");
            playerToggle = GetComponent<Toggle>();
            iconPath = "UI/PlayerIcon/";

        }
        public override void RegistEvent()
        {
            base.RegistEvent();
            playerToggle.onValueChanged.AddListener(delegate (bool isOn) { OnBtnClock(isOn); });
        }

        private void OnBtnClock(bool isOn)
        {
            if(isOn)
            {
                SetRayTar(false);
                SelectPlayerPanel.instance.SetSelectPlayerId(data.playerid);
                UITool.instance.ChangeImage(bg, iconPath + "PlayerIcon_select");
                QEventSystem.SendEvent(MyEventType.ChangePlayer, data);
            }
            else
            {
                SetRayTar(true);
                UITool.instance.ChangeImage(bg, iconPath + "PlayerIcon_bg");
            }
        }

        public void InitPlayerData(PlayerData db)
        {
            data = db;
            UITool.instance.ChangeImage(icon, iconPath + db.playericoname);
            if (SelectPlayerPanel.instance.isSelectId == db.playerid)
            {
                playerToggle.isOn = true;
                QEventSystem.SendEvent(MyEventType.ChangePlayer, db);
            }
        }
        public void SetRayTar(bool b)
        {
            bg.raycastTarget = b;
            icon.raycastTarget = b;
        }
    }
}
