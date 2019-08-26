using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace QFramework.MFO
{
    /// <summary>
    /// LevelItem数据
    /// </summary>
    public class LevelData
    {
        [SerializeField] public int itemid;
        [SerializeField] public int level;
        //[SerializeField] public string scenename;
    }
    /// <summary>
    /// 保存所有的levelitem数据到链表中
    /// </summary>
    public class LevelDataList
    {
        public ReactiveCollection<LevelData> mLevelDatas = new ReactiveCollection<LevelData>();
        /// <summary>
        /// 从json初始化数据到变量中
        /// </summary>
        public void InitLoadJson()
        {
            var jsonText = ResLoadManage.Instance.mResLoader.LoadSync<TextAsset>("levelitem").text;
            mLevelDatas = jsonText.FromJson<ReactiveCollection<LevelData>>();
        }

    }
}
