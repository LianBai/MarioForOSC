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
        //需要初始化的主场景面板的名字
        public List<string> mainInitPanel = new List<string>();
        //需要初始化的游戏场景面板的名字
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
        /// 初始化主场景需要打开的面板名字
        /// </summary>
        private void InitMainPanelName()
        {
            mainInitPanel.Add("LevelManagePanel");
            mainInitPanel.Add("PlayerManagePanel");
            
        }
        /// <summary>
        /// 初始化游戏场景需要打开的面板名字
        /// </summary>
        private void InitGamePanelName()
        {
            
        }
        /// <summary>
        /// 初始化场景中的面板，方便切换场景用
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
