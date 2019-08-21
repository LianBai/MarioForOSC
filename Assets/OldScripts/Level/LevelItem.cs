using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace MarioForOSC
{
    public class LevelItem : BaseGameObject
    {
        private LevelData data;
        private Image bg;
        private Text level;
        private string itemPath;
        private Toggle levelToggle;
        public override void Init()
        {
            base.Init();
            bg = GetComponent<Image>();
            level = GetGameObjectByPath<Text>("num");
            levelToggle = GetComponent<Toggle>();
            itemPath = "UI/PlayerIcon/";
        }
        public override void RegistEvent()
        {
            base.RegistEvent();
            levelToggle.onValueChanged.AddListener(delegate (bool isOn) { OnBtnClock(isOn); });
        }
        private void OnBtnClock(bool isOn)
        {
            //if (isOn)
            //{
            //    //SelectPlayerPanel.instance.SetSelectPlayerId(data.playerid);
            //    UITool.instance.ChangeImage(bg, itemPath + "PlayerIcon_lock");
            //    QEventSystem.SendEvent(MyEventType.ChangePlayer, data);
            //}
            //else
            //{
            //    UITool.instance.ChangeImage(bg, itemPath + "PlayerIcon_bg");
            //}
        }
        public void InitLevelData(LevelData db)
        {
            this.data = db;
            this.level.text = db.level;
            if(int.Parse(db.level)<=SelectLevelPanel.instance.passLevel)
            {
                SetRayTar(true);
                UITool.instance.ChangeImage(bg, itemPath + "PlayerIcon_select");
            }
            else
            {
                SetRayTar(false);
                UITool.instance.ChangeImage(bg, itemPath + "PlayerIcon_lock");
            }
        }
        public void SetRayTar(bool b)
        {
            bg.raycastTarget = b;
            level.raycastTarget = b;
        }
    }
}
