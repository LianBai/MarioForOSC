using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace QFramework.MFO
{
    public class playerItemData
    {
        [SerializeField] public int playerid;
        [SerializeField] public string playericoname;
        [SerializeField] public string playerprefabname;
    }

    public class playerItemDataList
    {
        public ReactiveCollection<playerItemData> playerItemList { get; private set; }

        public void InitDataForJson()
        {
            playerItemList = new ReactiveCollection<playerItemData>();
        }
        public void AddPlayer(playerItemData data)
        {
            playerItemList.Add(data);
        }
    }
}
