using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace QFramework.MFO
{
    /// <summary>
    /// LevelItem����
    /// </summary>
    public class LevelData
    {
        [SerializeField] public int itemid;
        [SerializeField] public int level;
        //[SerializeField] public string scenename;
    }
    /// <summary>
    /// �������е�levelitem���ݵ�������
    /// </summary>
    public class LevelDataList
    {
        public ReactiveCollection<LevelData> mLevelDatas = new ReactiveCollection<LevelData>();
        /// <summary>
        /// ��json��ʼ�����ݵ�������
        /// </summary>
        public void InitLoadJson()
        {
            var jsonText = ResLoadManage.Instance.mResLoader.LoadSync<TextAsset>("levelitem").text;
            mLevelDatas = jsonText.FromJson<ReactiveCollection<LevelData>>();
        }

    }
}
