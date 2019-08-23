/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using QF.Extensions;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UniRx;

namespace QFramework.MFO
{
	public partial class PlayerListView : UIElement
	{
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

            mModel.mPlayerDataList.ForEach(item =>
            {
                AddPlayItemView(mPlayItem, item);

            });

        }
        /// <summary>
        /// ����һ����ʾ��playeritem
        /// </summary>
        /// <param name="mPlayItem"></param>
        /// <param name="mData"></param>
	    public void AddPlayItemView(PlayItem mPlayItem, PlayerData mData)
	    {
	        mPlayItem.Instantiate()     //ʵ��һ������
	            .Parent(this)           //���ø�����
	            .LocalIdentity()        //��ʼ��������ת��
	            .ApplySelfTo(self => mPlayItemsView.Add(mData, self))   //һ�ֵ��÷�����ί��
                .ApplySelfTo(self => self.selectPlayer.Skip(1).Subscribe(SelectPlayer))
	            .ApplySelfTo(self => self.OnInitData(mData))
                .Show();
	    }

        //ѡ�е�item�����ĸı��ʱ�򴥷����¼�
	    public void SelectPlayer(PlayerData date)
	    {
            if(date!=null)
	            Debug.LogError(date.playericoname);
	    }
	}
}