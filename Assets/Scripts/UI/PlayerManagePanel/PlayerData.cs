using System.Collections;
using System.Collections.Generic;
using QF.Res;
using UniRx;
using UnityEngine;

namespace QFramework.MFO
{
    /// <summary>
    /// playerItem����
    /// </summary>
    public class PlayerData
    {
        [SerializeField] public int playerid;
        [SerializeField] public string playericoname;
        [SerializeField] public string playerprefabname;
    }
    /// <summary>
    /// ��json��ȡ���е�playerItem��������
    /// </summary>
    public class PlayerDataList
    {
        public ReactiveCollection<PlayerData> mPlayerDataList = new ReactiveCollection<PlayerData>();

        /// <summary>
        /// ��json�ļ���ȡ��������
        /// </summary>
        public void InitLoadJson()
        {
            ResLoader resLoader = ResLoader.Allocate();
            var jsonTest = resLoader.LoadSync<TextAsset>("playeritem").text;
            mPlayerDataList = jsonTest.FromJson<ReactiveCollection<PlayerData>>();
        }
    }
}
