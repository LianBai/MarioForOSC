using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace MarioForOSC
{
    public class SelectPlayerPanel : BaseGameObject, IPointerExitHandler,IPointerEnterHandler
    {
        private Image selectPanel;
        public override void Init()
        {
            base.Init();
            selectPanel = GetGameObjectByPath<Image>("bg");
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            selectPanel.rectTransform.DOLocalMoveX(0, 1f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            selectPanel.rectTransform.DOLocalMoveX(400, 1f);
        }

    }
}
