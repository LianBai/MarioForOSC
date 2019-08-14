using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MarioForOSC
{
    public class PickPoolManage
    {
        private GameObject coinPoolGo;
        private Queue<Transform> coinPool = new Queue<Transform>();
        public void InitCoin()
        {
            coinPoolGo = GameObject.Find("PickCoinPool");
            foreach(Transform child in coinPoolGo.transform)
            {
                coinPool.Enqueue(child);
            }
        }
        public void LoadCoin(Vector3 v)
        {
            if (coinPool.Count > 0)
            {
                Transform t = coinPool.Dequeue();
                t.gameObject.SetActive(true);
                t.transform.localPosition = v;
            }
            else
            {
                GameObject go;
                go = LoadPrefabManage.instance.LoadPrefab<GameObject>("PickCoinPrefab");
                go = GameObject.Instantiate(go);

                go.transform.parent = coinPoolGo.transform;
                go.transform.localPosition = v;
                go.SetActive(true);
            }
        }
        public void RecyCoin(Transform t)
        {
            coinPool.Enqueue(t);
            if (coinPool.Count > 10)
                LoadGamePickUp.instance.LoadPickUp(10);
        }

        #region 单例模式
        private static PickPoolManage _instance;
        /// <summary>
        /// 获得单例
        /// </summary>
        /// <returns></returns>
        public static PickPoolManage instance
        {
            get { return _instance ?? (_instance = new PickPoolManage()); }
        }
        #endregion
    }
}
