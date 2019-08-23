/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MFO
{
	public partial class PlayItem
	{
		[SerializeField] public UnityEngine.UI.Image icon;

		public void Clear()
		{
			icon = null;
		}

		public override string ComponentName
		{
			get { return "PlayItem";}
		}
	}
}
