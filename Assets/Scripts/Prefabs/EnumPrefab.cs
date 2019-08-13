using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QF.Res;

namespace MarioForOSC
{
    public enum EnumPrefabId
    {
        Characters = 1,//"Resources/Prefab/Characters",
        PickCoinPrefab,
    }
    public class EnumPrefabManager
    {
        private ResLoader loader = new ResLoader();
        private static EnumPrefabManager _instance = null;
        private Dictionary<EnumPrefabId, string> PrefabPath = new Dictionary<EnumPrefabId, string>();
        public EnumPrefabManager()
        {
            ResMgr.Init();
        }
        /// <summary>
        /// ע��һ�����
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prefabPath"></param>
        public void RegistPrefab(EnumPrefabId id,string prefabPath)
        {
            if (PrefabPath.ContainsKey(id))
                Debug.LogError("������Ѿ�ע����ˣ�" + id);
            PrefabPath.Add(id, prefabPath);
        }
        public GameObject GetPrefab(EnumPrefabId id)
        {
            string path;
            PrefabPath.TryGetValue(id, out path);
            return loader.LoadSync<GameObject>(path);
        }
        public GameObject GetPrefabByPath(string path)
        {
            return loader.LoadSync<GameObject>(path);
        }
        /// <summary>
        /// ��õ���
        /// </summary>
        /// <returns></returns>
        public static EnumPrefabManager instance
        {
            get { return _instance ?? (_instance = new EnumPrefabManager()); }
        }
    }
}
