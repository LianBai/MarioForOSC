/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using QF.Extensions;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UniRx;

namespace QFramework.MFO
{
	public partial class PlayerListView : UIElement
	{
	    private string playerName;
        //通过data数据和playitem物体绑定
        public Dictionary<PlayerData,PlayItem> mPlayItemsView = new Dictionary<PlayerData, PlayItem>();
		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
        /// <summary>
        /// 初始化playeritem显示的数据
        /// </summary>
        /// <param name="mPlayItem"></param>
        /// <param name="mModel"></param>
        public void InitPlayerItem(PlayItem mPlayItem, PlayerDataList mModel)
        {
            this.DestroyAllChild();
            mPlayItemsView.Clear();
            playerName = CacheDataManage.Instance.GetStringData(DataType.playerName);
            mModel.mPlayerDataList.ForEach(item =>
            {
                AddPlayItemView(mPlayItem, item);
            });

        }

	    public void OnShow()
	    {
	        mPlayItemsView.ForEach(data =>
	        {
	            if (data.Key.playerprefabname == playerName)
	            {
	                data.Value.mToggle.isOn = true;
	                SelectPlayer(data.Key);
	            }
	        });

	    }

	    /// <summary>
	    /// 增加一条显示的playeritem
	    /// </summary>
	    /// <param name="mPlayItem"></param>
	    /// <param name="mData"></param>
	    public void AddPlayItemView(PlayItem mPlayItem, PlayerData mData) => mPlayItem.Instantiate() //实例一个对象
	        .Parent(this) //设置父物体
	        .LocalIdentity() //初始化坐标旋转等
	        .ApplySelfTo(self =>
	        {
	            //将数据添加到储存的字典里
	            mPlayItemsView.Add(mData, self);
	            //一种调用方法的委托
	            self.selectPlayer.Skip(1).Subscribe(SelectPlayer);
	            //初始化数据
	            self.OnInitData(mData);
	        })
	        .Show();

        //选中的item发生的改变的时候触发的事件
        public void SelectPlayer(PlayerData date)
	    {
	        if (date != null)
	        {
	            playerName = date.playerprefabname;
	            CacheDataManage.Instance.SetStringData(DataType.playerName, playerName);
                //Debug.LogError(date.playericoname);
                //发送改变了选择的角色的事件
                QEventSystem.SendEvent(MyEventType.SelectNewPlayer, date);
	        }

	    }
	}
}