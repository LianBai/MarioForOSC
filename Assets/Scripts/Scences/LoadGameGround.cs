using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MarioForOSC
{
    public class GameSceneGroundData
    {
        public int id;
        public string name;
    }
    public class LoadGameGround
    {
        private int maxCount = 5;
        private List<GameSceneGroundData> groundData = new List<GameSceneGroundData>();
        public void InitGround(int id)
        {
            groundData = JsonManage.instance.LoadJson<GameSceneGroundData>(JsonFilesPath.GameGrount + id.ToString());
            foreach(var v in groundData)
            {
                //Debug.LogError(v.name);
                GameManage.instance.LoadGround(v.name);
            }
        }

        #region ����ģʽ
        private static LoadGameGround _instance;
        /// <summary>
        /// ��õ���
        /// </summary>
        /// <returns></returns>
        public static LoadGameGround instance
        {
            get { return _instance ?? (_instance = new LoadGameGround()); }
        }
        #endregion
    }
}
