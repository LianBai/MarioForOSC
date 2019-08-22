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
        //����item���������İ�
        public Dictionary<playerItemData,playerItem> playItemDic { get; private set; }
		private void Awake()
		{
            //��ʼ���ֵ����ݣ���ֹΪNULL
		    playItemDic = new Dictionary<playerItemData, playerItem>();

        }

		protected override void OnBeforeDestroy()
		{
		}
        /// <summary>
        /// ˢ�»��߳�ʼ�������ʾ����
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
        /// ����һ��item
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