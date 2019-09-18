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
        //ͨ��data���ݺ�playitem�����
        public Dictionary<PlayerData,PlayItem> mPlayItemsView = new Dictionary<PlayerData, PlayItem>();
		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}
        /// <summary>
        /// ��ʼ��playeritem��ʾ������
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
	    /// ����һ����ʾ��playeritem
	    /// </summary>
	    /// <param name="mPlayItem"></param>
	    /// <param name="mData"></param>
	    public void AddPlayItemView(PlayItem mPlayItem, PlayerData mData) => mPlayItem.Instantiate() //ʵ��һ������
	        .Parent(this) //���ø�����
	        .LocalIdentity() //��ʼ��������ת��
	        .ApplySelfTo(self =>
	        {
	            //��������ӵ�������ֵ���
	            mPlayItemsView.Add(mData, self);
	            //һ�ֵ��÷�����ί��
	            self.selectPlayer.Skip(1).Subscribe(SelectPlayer);
	            //��ʼ������
	            self.OnInitData(mData);
	        })
	        .Show();

        //ѡ�е�item�����ĸı��ʱ�򴥷����¼�
        public void SelectPlayer(PlayerData date)
	    {
	        if (date != null)
	        {
	            playerName = date.playerprefabname;
	            CacheDataManage.Instance.SetStringData(DataType.playerName, playerName);
                //Debug.LogError(date.playericoname);
                //���͸ı���ѡ��Ľ�ɫ���¼�
                QEventSystem.SendEvent(MyEventType.SelectNewPlayer, date);
	        }

	    }
	}
}