using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework.Json;
using QFramework;

namespace MarioForOSC
{
    public class LoadGamePickUp
    {
        public int isLoadCound = 0;
        private string jsonPath = Application.dataPath + "/Resources/JsonFile/PickUp_Game_{0}.json";
        private List<Vector3> pickUpList = new List<Vector3>();
        public void InitPickUp(int id)
        {
            PickPoolManage.instance.InitCoin();
            isLoadCound = 0;
            pickUpList = SerializeHelper.LoadJson<List<Vector3>>(string.Format(jsonPath, id));
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



        #region ����ģʽ
        private static LoadGamePickUp _instance;
        /// <summary>
        /// ��õ���
        /// </summary>
        /// <returns></returns>
        public static LoadGamePickUp instance
        {
            get { return _instance ?? (_instance = new LoadGamePickUp()); }
        }
        #endregion
    }
}