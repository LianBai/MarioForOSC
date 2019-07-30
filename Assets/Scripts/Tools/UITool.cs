using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MarioForOSC
{
    public class UITool
    {
        public void ChangeImage(Image image,string imagepath)
        {
            image.sprite = Resources.Load<Sprite>(imagepath);
        }

        #region 单例模式
        private static UITool _instance;
        /// <summary>
        /// 获得单例
        /// </summary>
        /// <returns></returns>
        public static UITool instance
        {
            get { return _instance ?? (_instance = new UITool()); }
        }
        #endregion
    }
}
