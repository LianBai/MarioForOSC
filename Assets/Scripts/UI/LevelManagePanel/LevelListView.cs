/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using QF;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QF.Extensions;

namespace QFramework.MFO
{
	public partial class LevelListView : UIElement
	{
	    private int maxLevel;
 	    //通过data数据和levelitem物体绑定
        public Dictionary<LevelData,LevelItem> mLevelItems = new Dictionary<LevelData, LevelItem>();

        //需要注入uitools
        [Inject] public IUITools mUiTools { get; set; }
        private void Awake()
		{
            //注入UITools
            MarioAppManager.Container.Inject(this);
        }

		protected override void OnBeforeDestroy()
		{
		}

        /// <summary>
        /// 初始化levelitem显示所有数据
        /// </summary>
        /// <param name="mLevelItem"></param>
        /// <param name="mPlayerDataList"></param>
	    public void InitLevelItem(LevelItem mLevelItem, LevelDataList mLevelDataList)
	    {
            this.DestroyAllChild();
	        mLevelItems.Clear();
	        maxLevel = CacheDataManage.Instance.GetIntData(DataType.levelMax);

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
                .ApplySelfTo(self =>
	            {
	                mLevelItems.Add(mLevelData, self);
	                self.OnInitData(mLevelData);
	                if (mLevelData.level <= maxLevel)
	                {
	                    mUiTools.ChanegeImage(self.GetComponent<Image>(), "PlayerIcon_select");
	                }
	            })
	            .Show();

	    }
	}
}