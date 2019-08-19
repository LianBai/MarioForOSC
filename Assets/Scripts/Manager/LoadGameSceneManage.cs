using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class LoadGameSceneManage
    {
        private static LoadGameSceneManage _instance;
        public void LoadGameScene()
        {
            GameObjectManager.instance.InstanceGameObject("Characters");
            LoadGameGround.instance.InitGround(1);
            LoadGamePickUp.instance.InitPickUp(1);
            
        }
        /// <summary>
        /// »ñµÃµ¥Àý
        /// </summary>
        /// <returns></returns>
        public static LoadGameSceneManage instance
        {
            get { return _instance ?? (_instance = new LoadGameSceneManage()); }
        }
    }
}
