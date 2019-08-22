/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MFO
{
	public partial class playerItem : UIElement
	{
		private void Awake()
		{
		}

		protected override void OnBeforeDestroy()
		{
		}

	    public void Init(playerItemData data)
	    {
	        Debug.Log(data.playericoname); 
	    }
	}
}