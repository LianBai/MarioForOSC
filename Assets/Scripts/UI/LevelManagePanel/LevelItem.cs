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
        /// 初始化item的数据并初始化显示
        /// </summary>
        /// <param name="mleveldata"></param>
	    public void OnInitData(LevelData mleveldata)
	    {
	        mLevelData = mleveldata;
	        LevelText.text = mleveldata.level.ToString();

            //注册点击关卡按钮的事件
            GetComponent<Button>().onClick.AddListener(() =>
            {
                //Debug.LogError("切换场景");
                UIMgr.CloseAllPanel();
                SceneManager.LoadSceneAsync("Game");
            });
        }
	}
}