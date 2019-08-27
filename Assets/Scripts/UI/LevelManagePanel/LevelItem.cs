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
        /// ��ʼ��item�����ݲ���ʼ����ʾ
        /// </summary>
        /// <param name="mleveldata"></param>
	    public void OnInitData(LevelData mleveldata)
	    {
	        mLevelData = mleveldata;
	        LevelText.text = mleveldata.level.ToString();

            //ע�����ؿ���ť���¼�
            GetComponent<Button>().onClick.AddListener(() =>
            {
                //Debug.LogError("�л�����");
                UIMgr.CloseAllPanel();
                SceneManager.LoadSceneAsync("Game");
            });
        }
	}
}