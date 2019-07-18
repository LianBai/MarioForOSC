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
        public void InstanceGameObject(EnumPrefabId id)
        {
            GameObject go = new GameObject();
            go = EnumPrefabManager.instance.GetPrefab(id);
            GameObject.Instantiate(go);
        }
        /*public void ShowPrefab(EnumPrefabId id)
        {
            BaseGameObject go = new BaseGameObject();
            goDic.TryGetValue(id, out go);
            //go.Init();
        }*/

        /// <summary>
        /// µ¥ÀýÄ£Ê½
        /// </summary>
        private static GameObjectManager _instance = null;
        public static GameObjectManager instance
        {
            get { return _instance ?? (_instance = new GameObjectManager()); }
        }
    }
}
