/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using QF.Res;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UniRx;

namespace QFramework.MFO
{
	public partial class PlayItem : UIElement
	{
	    private PlayerData mData;
	    private Image iconBg;
        public ReactiveProperty<PlayerData> selectPlayer = new ReactiveProperty<PlayerData>();
        private void Awake()
		{
		    mData = new PlayerData();
		    iconBg = GetComponent<Image>();
		}

		protected override void OnBeforeDestroy()
		{
		}
        /// <summary>
        /// 初始化item的数据并且初始化显示
        /// </summary>
        /// <param name="data"></param>
	    public void OnInitData(PlayerData data)
	    {
	        mData = data;
            UITools.Instance.ChanegeImage(icon,data.playericoname);
            //为item注册选中监听事件
            GetComponent<Toggle>().onValueChanged.AddListener(on =>
            {
                if (on)
                {
                    selectPlayer.Value = data;
                    UITools.Instance.ChanegeImage(iconBg, "PlayerIcon_select");
                    iconBg.raycastTarget = false;
                    icon.raycastTarget = false;
                }
                else
                {
                    selectPlayer.Value = null;
                    UITools.Instance.ChanegeImage(iconBg,"PlayerIcon_bg");
                    iconBg.raycastTarget = true;
                    icon.raycastTarget = true;
                }
            });
        }
	}
}