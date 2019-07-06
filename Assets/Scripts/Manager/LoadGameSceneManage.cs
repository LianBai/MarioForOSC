using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class LoadGameSceneManage
    {
        private static LoadGameSceneManage _instance;
        private void LoadGameScene()
        {

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
