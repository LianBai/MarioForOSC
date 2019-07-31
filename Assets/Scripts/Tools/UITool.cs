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

        #region ����ģʽ
        private static UITool _instance;
        /// <summary>
        /// ��õ���
        /// </summary>
        /// <returns></returns>
        public static UITool instance
        {
            get { return _instance ?? (_instance = new UITool()); }
        }
        #endregion
    }
}
