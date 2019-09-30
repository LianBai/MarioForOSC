using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QFramework.MFO
{
    public class MyJsonToExcelExample : MonoBehaviour
    {
        private JsonToExcelSystem myJsonToExcelSystem = new JsonToExcelSystem();
        private string path;
        private string fileName = "LianBai";                      //文件名字
        private List<PlayerData> posData = new List<PlayerData>(); //用来保存json数据
        // Start is called before the first frame update
        void Start()
        {
            path = Application.dataPath + "/Prints/";    //文件保存路径
            var jsonText = ResLoadManage.Instance.mResLoader.LoadSync<TextAsset>("playeritem").text;    //读取本地的json文件
            posData = jsonText.FromJson<List<PlayerData>>();    //保存json数据
            myJsonToExcelSystem.CreateExcelFile(path,fileName); //创建文件
            myJsonToExcelSystem.AddNewSheet("lianbai","ID","IocName","PrefabName"); //创建sheet并且赋值表头
            posData.ForEach(data =>         //遍历数据
            {
                myJsonToExcelSystem.AddData(data.playerid,data.playericoname,data.playerprefabname);    //把数据写入到表格中
            });
            myJsonToExcelSystem.SaveXls();  //保存文件
        }

    }
}
