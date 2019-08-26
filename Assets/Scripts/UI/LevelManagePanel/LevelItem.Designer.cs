/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace QFramework.MFO
{
	public partial class LevelItem
	{
		[SerializeField] public TMPro.TextMeshProUGUI LevelText;

		public void Clear()
		{
			LevelText = null;
		}

		public override string ComponentName
		{
			get { return "LevelItem";}
		}
	}
}
