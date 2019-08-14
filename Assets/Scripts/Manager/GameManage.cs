using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class GameManage :  BaseGameObject
    {

        public override void Init()
        {
            base.Init();
            instance = this;
        }
        public void LoadGround(string name)
        {
            GameObject go = CreatGoAndSetPanet(LoadPrefabManage.instance.LoadPrefab<GameObject>(name), transform);
            go.transform.localScale = new Vector3(25f, 0.2f, 25f);
            go.transform.localPosition = new Vector3((transform.childCount - 1) * 25, 0, 0);
        }
        public override void OnShow()
        {
            base.OnShow();
            //LoadGameSceneManage.instance.LoadGameScene();
        }
        public override void LateInit()
        {
            base.LateInit();
            LoadGameSceneManage.instance.LoadGameScene();
        }

        public static GameManage instance;
    }
}
