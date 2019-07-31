using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class JsonManage : MonoBehaviour
    {
        private string jsonPath = Application.dataPath + "/Resources/JsonFile/";
        public List<T> LoadJson<T>(string jsonName)
        {
            List<T> list = new List<T>();
            list = SerializeHelper.LoadJson<List<T>>(jsonPath + jsonName + ".json");
            return list;
        }

        #region 单例模式
        private static JsonManage _instance;
        /// <summary>
        /// 获得单例
        /// </summary>
        /// <returns></returns>
        public static JsonManage instance
        {
            get { return _instance ?? (_instance = new JsonManage()); }
        }
        #endregion
    }
}
