using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class GameObjectManager
    {
        private static GameObjectManager _instance = null;
        public static GameObjectManager instance
        {
            get { return _instance ?? (_instance = new GameObjectManager()); }
        }
        Dictionary<EnumPrefabId, BasePrefab> goDic= new Dictionary<EnumPrefabId, BasePrefab>();
        public GameObjectManager()
        {
            goDic.Clear();
            AddGameobjectPrefab(EnumPrefabId.Characters, Characters.instance, "Resources/Prefab/Characters");
        }
        private void AddGameobjectPrefab(EnumPrefabId id, BasePrefab go , string path)
        {
            goDic.Add(id, go);
            EnumPrefabManager.instance.RegistPrefab(id, path);
        }
        public void ShowPrefab(EnumPrefabId id)
        {
            BasePrefab go = new BasePrefab();
            goDic.TryGetValue(id, out go);
            go.Init();
        }
    }
}
