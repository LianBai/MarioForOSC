using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarioForOSC
{
    public class PlayerItem : BaseGameObject
    {
        private PlayerData data;
        private Image icon;
        private string iconPath;
        public override void Init()
        {
            base.Init();
            icon = GetGameObjectByPath<Image>("icon");
            iconPath = "UI/PlayerIcon/";
        }
        public void InitPlayerData(PlayerData db)
        {
            data = db;
            UITool.instance.ChangeImage(icon, iconPath + db.playericoname);
        }
    }
}
