using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.MFO
{
    public class MyJsonToExcelExample : MonoBehaviour
    {
        private JsonToExcelSystem myJsonToExcelSystem = new JsonToExcelSystem();
        private string path;
        private string fileName = "LianBai";                      //�ļ�����
        private List<PlayerData> posData = new List<PlayerData>(); //��������json����
        // Start is called before the first frame update
        void Start()
        {
            path = Application.dataPath + "/Prints/";    //�ļ�����·��
            var jsonText = ResLoadManage.Instance.mResLoader.LoadSync<TextAsset>("playeritem").text;    //��ȡ���ص�json�ļ�
            posData = jsonText.FromJson<List<PlayerData>>();    //����json����
            myJsonToExcelSystem.CreateExcelFile(path,fileName); //�����ļ�
            myJsonToExcelSystem.AddNewSheet("lianbai","ID","IocName","PrefabName"); //����sheet���Ҹ�ֵ��ͷ
            posData.ForEach(data =>         //��������
            {
                myJsonToExcelSystem.AddData(data.playerid,data.playericoname,data.playerprefabname);    //������д�뵽�����
            });
            myJsonToExcelSystem.SaveXls();  //�����ļ�
        }

    }
}
