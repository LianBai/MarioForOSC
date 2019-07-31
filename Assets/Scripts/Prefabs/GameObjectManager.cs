using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class GameObjectManager
    {
        Dictionary<EnumPrefabId, BaseGameObject> goDic= new Dictionary<EnumPrefabId, BaseGameObject>();

        public GameObjectManager()
        {
            goDic.Clear();
            AddGameobjectPrefab(EnumPrefabId.Characters, "Resources/Prefab/Characters");
            AddGameobjectPrefab(EnumPrefabId.PickCoinPrefab, "Resources/Prefab/PickPool/PickCoinPrefab");
        }
        private void AddGameobjectPrefab(EnumPrefabId id, string path)
        {
            EnumPrefabManager.instance.RegistPrefab(id, path);
        }
        public GameObject InstanceGameObject(EnumPrefabId id)
        {
            GameObject go;
            go = EnumPrefabManager.instance.GetPrefab(id);
            return GameObject.Instantiate(go);
        }
        public GameObject InstanceGameObjectByPath(string path)
        {
            GameObject go;
            go = EnumPrefabManager.instance.GetPrefabByPath(path);
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
