using System.Collections;
using System.Collections.Generic;
using QF.Extensions;
using UnityEngine;

namespace QFramework.MFO
{
    public class GameGroundData
    {
        [SerializeField]
        public int id;
        [SerializeField]
        public string prefabname;
    }
    public class GameSceneManage : MonoBehaviour
    {
        private long hasGroundCount = 0;
        private List<GameGroundData> groundDateList = new List<GameGroundData>();
        // Start is called before the first frame update
        void Start()
        {
            ResLoadManage.Instance.OpenInitPanel(PanelType.GamePanel);
            LoadSceneGround(1);
        }
        /// <summary>
        /// 初始化加载局内场景的地面
        /// </summary>
        /// <param name="level"></param>
        public void LoadSceneGround(int level)
        {
            //清空数据，方便数据初始化
            groundDateList.Clear();
            hasGroundCount = 0;
            //读取需要加载的场景的记录数据json
            var jsonText = ResLoadManage.Instance.mResLoader
                .LoadSync<TextAsset>("gamescene_" + level).text;
            groundDateList = jsonText.FromJson<List<GameGroundData>>();
            //遍历初始化加载读取出来的数据场景
            groundDateList.ForEach(item =>
            {
                ResLoadManage.Instance.mResLoader
                    .LoadSync<GameObject>(item.prefabname)
                    .Instantiate()
                    .ApplySelfTo(self =>
                    {
                        self.transform.localPosition = new Vector3(25f * hasGroundCount, 0f, 0f);
                        hasGroundCount++;
                        self.transform.parent = transform;
                    })
                    .Show();
            });
        }
    }
}
