using System.Collections;
using System.Collections.Generic;
using QF;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QFramework.MFO
{
    enum ScenceType
    {
        Main,
        Game,
    }
    public class AppScenceManage : Singleton<AppScenceManage>
    {
        public void InitData()
        {
            MyEventSystem.GetEvent(MyEventType.ChangeScence)
                .Subscribe(ChangeScence);
        }
        private void ChangeScence(object[] param)
        {
            switch ((ScenceType)param[0])
            {
                case ScenceType.Main:
                {
                    SceneManager.LoadSceneAsync("Main");
                } break;
                case ScenceType.Game:
                {
                    SceneManager.LoadSceneAsync("Game");
                } break;
            }
        }
        private AppScenceManage()
        {
            
        }

    }
}
