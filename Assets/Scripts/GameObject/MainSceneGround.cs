using System;
using System.Collections.Generic;
using QF.Extensions;
using UnityEngine;
using QFramework;
using UniRx;

namespace QFramework.MFO
{
	public partial class MainSceneGround : ViewController
	{
	    public GameObject mOldSelectGameObject;
        public ReactiveProperty<PlayerData> mSelectPlayer = new ReactiveProperty<PlayerData>();
        private List<GameObject> hasPrefab = new List<GameObject>();
		void Awake()
		{
            // Code Here
		    hasPrefab.Clear();
		    this.selectplayer.DestroyAllChild();
            //初始化主场景的位置
            transform.localPosition = new Vector3(-2.5f, 7f, 28f);
            //注册当角色选择发生改变的时候的事件
		    //QEventSystem.RegisterEvent(MyEventType.SelectNewPlayer, ChangePlayerShow);
		    MyEventSystem.GetEvent(MyEventType.SelectNewPlayer)
                .Subscribe(ChangePlayerShow)
                .AddTo(this);
		}

        //void Start()
        //{
        //    MyEventSystem.GetEvent(MyEventType.Test).Subscribe(ReciveTest).AddTo(this);
        //       MyEventSystem.Send(MyEventType.Test, "test01", "Test02");
        //       MyEventSystem.Send(MyEventType.Test, "test03", "Test04");
        //   }

        //void ReciveTest(object[] param)
        //{
        //    Debug.LogError(param[0]);
        //    Debug.LogError(param[1]);
        //   }


        private void ChangePlayerShow(object[] param)
	    {
	        mSelectPlayer.Value = (PlayerData) param[0];
            if (mOldSelectGameObject != null)   //切换物体时，先把上一个显示的隐藏掉
                mOldSelectGameObject.SetActive(false);
            //Debug.LogError(mSelectPlayer.Value.playericoname);
            GameObject selectShowGo = hasPrefab
                .Find(str => str.name == mSelectPlayer.Value.playerprefabname); //从记录的数据中查找即将显示的物体
	        if (selectShowGo == null)
	        {
                ResLoadManage.Instance.mResLoader
                    .LoadSync<GameObject>(mSelectPlayer.Value.playerprefabname)
                    .Instantiate()
                    .ApplySelfTo(self =>
                    {
                        self.transform.parent = this.selectplayer;  //设置父物体
                        self.transform.localPosition = Vector3.zero;    //初始化位置
                        self.name = mSelectPlayer.Value.playerprefabname;   //更改物体名字，否则会带clone
                        hasPrefab.Add(self);                        //记录已经显示的物体
                        mOldSelectGameObject = self;                //标记正在显示的物体，方便切换人物使用
                        self.transform.localEulerAngles = Vector3.zero; //初始化旋转
                    })
                    .Show();
            }
	        else
	        {
	            mOldSelectGameObject = selectShowGo;    //标记正在显示的物体，方便切换人物使用
                selectShowGo.SetActive(true);
	        }
	    }
	}
}
