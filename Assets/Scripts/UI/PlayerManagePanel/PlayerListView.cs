/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using QF.Extensions;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MFO
{
	public partial class PlayerListView : UIElement
	{
        //定义item数据与对象的绑定
        public Dictionary<playerItemData,playerItem> playItemDic { get; private set; }
		private void Awake()
		{
            //初始化字典数据，防止为NULL
		    playItemDic = new Dictionary<playerItemData, playerItem>();

        }

		protected override void OnBeforeDestroy()
		{
		}
        /// <summary>
        /// 刷新或者初始化面板显示数据
        /// </summary>
        /// <param name="playerItem"></param>
        /// <param name="mModel"></param>
	    public void RefshListData(playerItem playerItem,playerItemDataList mModel)
        {
            this.DestroyAllChild();
            playItemDic.Clear();
            mModel.playerItemList.ForEach(item =>
            {
                
            });
        }
        /// <summary>
        /// 增加一个item
        /// </summary>
        /// <param name="playerItem"></param>
        /// <param name="data"></param>
	    public void AddPlayerItem(playerItem playerItem, playerItemData data)
        {
            playerItem.Instantiate()
                .Parent(this);

        }

	}
}