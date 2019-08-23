/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using QF.Res;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MFO
{
	public partial class PlayItem : UIElement
	{
	    public PlayerData mData;
		private void Awake()
		{
		    mData = new PlayerData();

        }

		protected override void OnBeforeDestroy()
		{
		}

	    public void OnInitData(PlayerData data)
	    {
	        mData = data;
            Sprite msprite = ResLoadManage.Instance.mResLoader.LoadSprite(data.playericoname);
            icon.sprite = msprite;
	    }
	}
}