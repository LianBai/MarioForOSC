using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class GameManage :  BaseGameSceneManage
    {
        public override void OnInit()
        {
            base.OnInit();
        }
        public override void OnShow()
        {
            base.OnShow();
            LoadGameSceneManage.instance.LoadGameScene();
        }

    }
}
