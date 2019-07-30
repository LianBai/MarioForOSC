using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

            RegistEvent();
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
                SelectPlayerPanel.instance.SetSelectPlayerId(data.playerid);
                UITool.instance.ChangeImage(bg, iconPath + "PlayerIcon_select");
            }
            else
            {
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
            }
        }
    }
}
