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
        #region 成员变量
        public static SelectPlayerPanel instance;
        private float slideTime = 0.5f;
        private Image selectPanel;
        private Transform playerItemPanent;
        private GameObject playerItem;
        private List<PlayerData> playItemData;
        public int isSelectId { get; private set; }
        #endregion

        public override void Init()
        {
            base.Init();
            instance = this;

            selectPanel = GetGameObjectByPath<Image>("bg");

            playerItem = GetGameObjectByPath("bg/Scroll View/Viewport/Content/playerIcon");
            playerItemPanent = GetGameObjectByPath<Transform>("bg/Scroll View/Viewport/Content");
            playItemData = JsonManage.instance.LoadJson<PlayerData>("PlayerItem");

            if (!UnityEngine.PlayerPrefs.HasKey(CacheData.playerId))
            {
                UnityEngine.PlayerPrefs.SetInt(CacheData.playerId, 2);
            }
            isSelectId = UnityEngine.PlayerPrefs.GetInt(CacheData.playerId);

            LoadPlayerItem();
        }
        public override void RegistEvent()
        {
            base.RegistEvent();
        }
        public void SetSelectPlayerId(int id)
        {
            isSelectId = id;
            UnityEngine.PlayerPrefs.SetInt(CacheData.playerId,id);
        }
        public void LoadPlayerItem()
        {
            foreach(var v in playItemData)
            {
                CreatGoAndSetPanet(playerItem, playerItemPanent)
                .GetComponent<PlayerItem>().InitPlayerData(v);
            }
            
        }

        #region 面板滑动
        public void OnPointerEnter(PointerEventData eventData)
        {
            selectPanel.rectTransform.DOLocalMoveX(0, slideTime);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            selectPanel.rectTransform.DOLocalMoveX(-400, slideTime);
        }
        #endregion
    }
}
