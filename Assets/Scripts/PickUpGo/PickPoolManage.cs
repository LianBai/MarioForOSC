using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace MarioForOSC
{
    public class PickPoolManage : BaseGameObject
    {
        static SimpleObjectPool<GameObject> coinPool;
        public PickPoolManage()
        {
            coinPool = new SimpleObjectPool<GameObject>(factoryMethod: () => EnumPrefabManager.instance.GetPrefab(EnumPrefabId.PickCoinPrefab), initCount: 50);
            //GameObject go = coinPool.Allocate();
        }
        public void LoadCoin(Vector3 v)
        {
            GameObject go = coinPool.Allocate();
            GameObject.Instantiate(go);
            go.transform.localPosition = v;
            //go.transform.parent = transform;
        }
        public void RecyCoin(GameObject go)
        {
            coinPool.Recycle(go);
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
