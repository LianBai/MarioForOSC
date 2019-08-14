using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class LoadGamePickUp
    {
        public int isLoadCound = 0;
        private List<Vector3> pickUpList = new List<Vector3>();
        public void InitPickUp(int id)
        {
            PickPoolManage.instance.InitCoin();
            isLoadCound = 0;
            pickUpList = JsonManage.instance.LoadJson<Vector3>(JsonFilesPath.GamePickUp+id.ToString());
            for(; isLoadCound < pickUpList.Count; isLoadCound++)
            {
                PickPoolManage.instance.LoadCoin(pickUpList[isLoadCound]);
                if (isLoadCound == 50)
                {
                    isLoadCound++;
                    return;
                }
                    
            }
        }
        public void LoadPickUp(int count)
        {
            while(isLoadCound < pickUpList.Count && count >0)
            {
                PickPoolManage.instance.LoadCoin(pickUpList[isLoadCound]);
                isLoadCound++;
                count--;
            }
        }



        #region 单例模式
        private static LoadGamePickUp _instance;
        /// <summary>
        /// 获得单例
        /// </summary>
        /// <returns></returns>
        public static LoadGamePickUp instance
        {
            get { return _instance ?? (_instance = new LoadGamePickUp()); }
        }
        #endregion
    }
}