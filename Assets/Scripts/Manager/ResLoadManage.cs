using System.Collections;
using System.Collections.Generic;
using QF;
using QF.Res;
using UnityEngine;

namespace QFramework.MFO
{
    public enum PanelType
    {
        MainPanel,
        GamePanel
    }
    public class ResLoadManage : Singleton<ResLoadManage>
    {
        public ResLoader mResLoader = ResLoader.Allocate();
        //��Ҫ��ʼ������������������
        public List<string> mainInitPanel = new List<string>();
        //��Ҫ��ʼ������Ϸ������������
        public List<string> gameInitPanel = new List<string>();
        private ResLoadManage()
        {
            ResMgr.Init();
            UIMgr.SetResolution(2048,1536,0.5f);
            InitMainPanelName();
            InitGamePanelName();
        }
        //public static ResLoadManage Instance
        //{
        //    get { return SingletonProperty<ResLoadManage>.Instance; }
        //}
        /// <summary>
        /// ��ʼ����������Ҫ�򿪵��������
        /// </summary>
        private void InitMainPanelName()
        {
            mainInitPanel.Add("LevelManagePanel");
            mainInitPanel.Add("PlayerManagePanel");
            
        }
        /// <summary>
        /// ��ʼ����Ϸ������Ҫ�򿪵��������
        /// </summary>
        private void InitGamePanelName()
        {
            
        }
        /// <summary>
        /// ��ʼ�������е���壬�����л�������
        /// </summary>
        /// <param name="mpaneltype"></param>
        public void OpenInitPanel(PanelType mpaneltype)
        {
            switch (mpaneltype)
            {
                case PanelType.MainPanel:
                {
                    mainInitPanel.ForEach(panelname =>
                    {
                        UIMgr.OpenPanel(panelname);
                    });
                }
                    break;
                case PanelType.GamePanel:
                {
                    gameInitPanel.ForEach(panelname =>
                    {
                        UIMgr.OpenPanel(panelname);
                    });
                }break;
            }
        }
    }
}
