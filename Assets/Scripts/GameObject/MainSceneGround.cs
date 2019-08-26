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
		void Start()
		{
            // Code Here
		    hasPrefab.Clear();
		    this.selectplayer.DestroyAllChild();
            //��ʼ����������λ��
            transform.localPosition = new Vector3(-2.5f, 7f, 28f);
            //ע�ᵱ��ɫѡ�����ı��ʱ����¼�
		    QEventSystem.RegisterEvent(MyEventType.SelectNewPlayer, ChangePlayerShow);
		}

	    private void ChangePlayerShow(int key, object[] param)
	    {
	        mSelectPlayer.Value = (PlayerData) param[0];
            if (mOldSelectGameObject != null)   //�л�����ʱ���Ȱ���һ����ʾ�����ص�
                mOldSelectGameObject.SetActive(false);
            //Debug.LogError(mSelectPlayer.Value.playericoname);
            GameObject selectShowGo = hasPrefab
                .Find(str => str.name == mSelectPlayer.Value.playerprefabname); //�Ӽ�¼�������в��Ҽ�����ʾ������
	        if (selectShowGo == null)
	        {
                ResLoadManage.Instance.mResLoader
                    .LoadSync<GameObject>(mSelectPlayer.Value.playerprefabname)
                    .Instantiate()
                    .ApplySelfTo(self =>
                    {
                        self.transform.parent = this.selectplayer;  //���ø�����
                        self.transform.localPosition = Vector3.zero;    //��ʼ��λ��
                        self.name = mSelectPlayer.Value.playerprefabname;   //�����������֣�������clone
                        hasPrefab.Add(self);                        //��¼�Ѿ���ʾ������
                        mOldSelectGameObject = self;                //���������ʾ�����壬�����л�����ʹ��
                        self.transform.localEulerAngles = Vector3.zero; //��ʼ����ת
                    })
                    .Show();
            }
	        else
	        {
	            mOldSelectGameObject = selectShowGo;    //���������ʾ�����壬�����л�����ʹ��
                selectShowGo.SetActive(true);
	        }
	    }
	}
}
