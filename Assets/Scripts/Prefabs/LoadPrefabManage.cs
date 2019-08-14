using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QF.Res;

namespace MarioForOSC
{
    public class LoadPrefabManage
    {
        private ResLoader loader = ResLoader.Allocate();
        public LoadPrefabManage()
        {
            ResMgr.Init();
        }
        public T LoadPrefab<T>(string name) where T : Object
        {
            return loader.LoadSync<T>(name);
        }
        #region ����ģʽ
        private static LoadPrefabManage _instance = null;
        /// <summary>
        /// ��õ���
        /// </summary>
        /// <returns></returns>
        public static LoadPrefabManage instance
        {
            get { return _instance ?? (_instance = new LoadPrefabManage()); }
        }
        #endregion
    }
}
