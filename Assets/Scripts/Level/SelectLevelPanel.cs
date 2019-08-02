using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

namespace MarioForOSC
{
    public class SelectLevelPanel : BaseGameObject, IPointerExitHandler, IPointerEnterHandler
    {
        #region 成员变量
        public static SelectLevelPanel instance;
        private float slideTime = 0.5f;
        private Image levelPanel;
        private Transform LevelItemPanent;
        public int isSelectId { get; private set; }
        #endregion

        public override void Init()
        {
            base.Init();

            instance = this;
            levelPanel = GetGameObjectByPath<Image>("bg");

            LevelItemPanent = GetGameObjectByPath<Transform>("bg/Scroll View/Viewport/Content");
        }

        #region 面板滑动
        public void OnPointerEnter(PointerEventData eventData)
        {
            levelPanel.rectTransform.DOLocalMoveX(0, slideTime);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            levelPanel.rectTransform.DOLocalMoveX(400, slideTime);
        }
        #endregion
    }
}
