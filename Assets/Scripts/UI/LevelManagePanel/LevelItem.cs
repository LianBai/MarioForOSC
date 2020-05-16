/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using QF;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace QFramework.MFO
{
	public partial class LevelItem : UIElement
	{
	    private LevelData mLevelData;
		private void Awake()
		{
		    mLevelData = new LevelData();
        }

		protected override void OnBeforeDestroy()
		{
		}
        /// <summary>
        /// ?????item???????????????
        /// </summary>
        /// <param name="mleveldata"></param> 
	    public void OnInitData(LevelData mleveldata)
	    {
	        mLevelData = mleveldata;
	        LevelText.text = mleveldata.level.ToString();
            
            //????????????????
            GetComponent<Button>().onClick.AddListener(() =>
            {
	            //Debug.LogError("?§Ý?????");
                UIMgr.CloseAllPanel();
                CacheDataManage.Instance.SetIntData(DataType.playLevel,mleveldata.level);
                MyEventSystem.Send(MyEventType.ChangeScence,ScenceType.Game);
            });
        }
	}
}
