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
        public int passLevel { get; private set; }
        private Image levelPanel;
        private Transform levelItemPanent;
        private GameObject levelItem;
        public int isSelectId { get; private set; }
        private List<LevelData> levelItemDate = new List<LevelData>();
        #endregion

        public override void Init()
        {
            base.Init();

            instance = this;
            levelPanel = GetGameObjectByPath<Image>("bg");

            levelItem = GetGameObjectByPath("bg/Scroll View/Viewport/Content/LevelIcon");
            levelItemPanent = GetGameObjectByPath<Transform>("bg/Scroll View/Viewport/Content");
            levelItemDate = JsonManage.instance.LoadJson<LevelData>(JsonFilesPath.GmaeSceneItem);
        }
        public override void LateInit()
        {
            base.LateInit();
            if(!PlayerPrefs.HasKey(CacheData.passLevel))
            {
                PlayerPrefs.SetInt(CacheData.passLevel, 1);
            }
            passLevel = PlayerPrefs.GetInt(CacheData.passLevel);

            LoadLevelItem();
        }

        public void LoadLevelItem()
        {
            foreach(var v in levelItemDate)
            {
                CreatGoAndSetPanet(levelItem, levelItemPanent)
                .GetComponent<LevelItem>().InitLevelData(v);
            }
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
