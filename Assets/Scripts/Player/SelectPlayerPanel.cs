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
        private float slideTime = 0.5f;
        private Image selectPanel;
        private Transform playerItemPanent;
        private GameObject playerItem;
        private List<PlayerData> playItemData;
        public override void Init()
        {
            base.Init();
            selectPanel = GetGameObjectByPath<Image>("bg");

            playerItem = GetGameObjectByPath("bg/Scroll View/Viewport/Content/playerIcon");
            playerItemPanent = GetGameObjectByPath<Transform>("bg/Scroll View/Viewport/Content");
            playItemData = JsonManage.instance.LoadJson<PlayerData>("PlayerItem");

            LoadPlayerItem();
        }
        public void LoadPlayerItem()
        {
            foreach(var v in playItemData)
            {
                CreatGoAndSetPanet(playerItem, playerItemPanent)
                .GetComponent<PlayerItem>().InitPlayerData(v);
            }
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            selectPanel.rectTransform.DOLocalMoveX(0, slideTime);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            selectPanel.rectTransform.DOLocalMoveX(-400, slideTime);
        }

    }
}
