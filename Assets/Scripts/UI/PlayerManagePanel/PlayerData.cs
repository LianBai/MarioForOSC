using System.Collections;
using System.Collections.Generic;
using QF.Res;
using UniRx;
using UnityEngine;

namespace QFramework.MFO
{
    /// <summary>
    /// playerItem数据
    /// </summary>
    public class PlayerData
    {
        [SerializeField] public int playerid;
        [SerializeField] public string playericoname;
        [SerializeField] public string playerprefabname;
    }
    /// <summary>
    /// 从json读取所有的playerItem到链表里
    /// </summary>
    public class PlayerDataList
    {
        public ReactiveCollection<PlayerData> mPlayerDataList = new ReactiveCollection<PlayerData>();

        /// <summary>
        /// 从json文件读取到链表里
        /// </summary>
        public void InitLoadJson()
        {
            ResLoader resLoader = ResLoader.Allocate();
            var jsonTest = resLoader.LoadSync<TextAsset>("playeritem").text;
            mPlayerDataList = jsonTest.FromJson<ReactiveCollection<PlayerData>>();
        }
    }
}
