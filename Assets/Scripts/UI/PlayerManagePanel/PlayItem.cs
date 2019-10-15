/****************************************************************************
 * 2019.8 ZONGQUANLI
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using QF;
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
	    public Toggle mToggle;
        public ReactiveProperty<PlayerData> selectPlayer = new ReactiveProperty<PlayerData>();
        //��Ҫע��uitools
	    [Inject] public IUITools mUiTools { get; set; }
        private void Awake()
		{
		    mData = new PlayerData();
		    iconBg = GetComponent<Image>();
		    mToggle = GetComponent<Toggle>();
            
            

        }

		protected override void OnBeforeDestroy()
		{
		}
        /// <summary>
        /// ��ʼ��item�����ݲ��ҳ�ʼ����ʾ
        /// </summary>
        /// <param name="data"></param>
	    public void OnInitData(PlayerData data)
	    {
	        mData = data;
            //ע��UITools
            MarioAppManager.Container.Inject(this);

            mUiTools.ChanegeImage(icon,data.playericoname);
            //Ϊitemע��ѡ�м����¼�
	        GetComponent<Toggle>().onValueChanged.AddListener(on =>
            {
                if (on)
                {
                    selectPlayer.Value = data;
                    mUiTools.ChanegeImage(iconBg, "PlayerIcon_select");
                    iconBg.raycastTarget = false;
                    icon.raycastTarget = false;
                }
                else
                {
                    selectPlayer.Value = null;
                    mUiTools.ChanegeImage(iconBg,"PlayerIcon_bg");
                    iconBg.raycastTarget = true;
                    icon.raycastTarget = true;
                }
            });
        }
	}
}