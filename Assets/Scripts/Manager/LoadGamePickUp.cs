using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework.Json;

namespace MarioForOSC
{
    public class LoadGamePickUp
    {
        private JSONNode pickUpList;
        public void LoadPickUp()
        {
            pickUpList = JSONClass.LoadFromFile("PickUp_Game_1");
            Debug.LogError(pickUpList);
        }



        #region ����ģʽ
        private static LoadGamePickUp _instance;
        private void LoadGameScene()
        {

        }
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