using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class GameObjectManager
    {
        public GameObjectManager()
        {
        }
        public GameObject InstanceGameObject(string path)
        {
            GameObject go;
            go = LoadPrefabManage.instance.LoadPrefab<GameObject>(path);
            return GameObject.Instantiate(go);
        }

        #region µ¥ÀýÄ£Ê½
        private static GameObjectManager _instance = null;
        public static GameObjectManager instance
        {
            get { return _instance ?? (_instance = new GameObjectManager()); }
        }
        #endregion
    }
}
