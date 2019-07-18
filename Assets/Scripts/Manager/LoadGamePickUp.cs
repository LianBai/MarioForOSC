using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework.Json;
using QFramework;

namespace MarioForOSC
{
    public class LoadGamePickUp
    {
        private string jsonPath = Application.dataPath + "/Resources/JsonFile/PickUp_Game_{0}.json";
        private List<Vector3> pickUpList = new List<Vector3>();
        public void LoadPickUp(int id)
        {
            //string path = "Assets/TestJosn"; path += "/MyTest.json";
            //SerializeHelper.SaveJson(pickUpList,path);
            //Debug.LogError("����ɹ�");

            pickUpList = SerializeHelper.LoadJson<List<Vector3>>(string.Format(jsonPath,id));
            foreach(var v in pickUpList)
            {
                PickPoolManage.instance.LoadCoin(v);
            }
            //pickUpList = JSONClass.LoadFromFile("PickUp_Game_1");
            //Debug.LogError(pickUpList);

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