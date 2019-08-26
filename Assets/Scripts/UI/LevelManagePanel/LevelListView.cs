/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QF.Extensions;

namespace QFramework.MFO
{
	public partial class LevelListView : UIElement
	{
	    //ͨ��data���ݺ�levelitem�����
        public Dictionary<LevelData,LevelItem> mLevelItems = new Dictionary<LevelData, LevelItem>();
		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}

        /// <summary>
        /// ��ʼ��levelitem��ʾ��������
        /// </summary>
        /// <param name="mLevelItem"></param>
        /// <param name="mPlayerDataList"></param>
	    public void InitLevelItem(LevelItem mLevelItem, LevelDataList mLevelDataList)
	    {
            this.DestroyAllChild();
	        mLevelItems.Clear();

	        mLevelDataList.mLevelDatas.ForEach(item =>
	        {
	            AddLevelItem(mLevelItem, item);

	        });
	    }

	    public void AddLevelItem(LevelItem mLevelItem,LevelData mLevelData)
	    {
	        mLevelItem.Instantiate()
	            .Parent(this)
	            .LocalIdentity()
                .ApplySelfTo(self => mLevelItems.Add(mLevelData,self))
                .ApplySelfTo(self => self.OnInitData(mLevelData))
	            .Show();

	    }
	}
}