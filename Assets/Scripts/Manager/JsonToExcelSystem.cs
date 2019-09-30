using org.in2bits.MyXls;
using QF.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.MFO
{
    public class JsonToExcelSystem
    {
        //保留当前创建的xls文档
        private XlsDocument newXls;
        //保留当前操作的对应的sheet中的单元格
        private Cells newCells;
        //当前sheet所添加的行
        private int nowRow;
        /// <summary>
        /// 创建新的Xls文件
        /// </summary>
        public void CreateExcelFile(string filePath,string fileName,
            string author = "LianBai",string subject = "Test")
        {  
            XlsDocument xls = new XlsDocument();    //创建一个新的xls文档
            xls.FileName = filePath+fileName;                //设置文件名字(路径+名字)
            xls.SummaryInformation.Author = author; //设置xls文件作者信息
            xls.SummaryInformation.Subject = subject;   //设置xls文件主题信息

            newXls = xls;
            //Worksheet sheet = xls.Workbook.Worksheets.AddNamed(sheetName);  //添加一个sheet页面
        }
        /// <summary>
        /// 添加一个新的sheet,并赋予开头
        /// </summary>
        public void AddNewSheet(string sheetName, params string[] param)
        {
            if (newXls == null)
            {
                Debug.LogError("LianBai:Please create new xls");
            }
            else
            {
                Worksheet sheet = newXls.Workbook.Worksheets.AddNamed(sheetName);   //添加一个新的sheet
                newCells = sheet.Cells; //修改当前操作的单元格
                int index = 1;      
                param.ForEach(tipName =>        //遍历添加标头
                {
                    newCells.Add(1, index, tipName);
                    index++;
                });
                nowRow = 2;     //初始化从第二行添加数据
            }

        }
        /// <summary>
        /// 往创建的sheet里添加数据
        /// </summary>
        public void AddData(params object[] param)
        {
            if (newXls == null || newCells == null)     //判断文件是否被创建
            {
                Debug.LogError("LianBai:Please create new xls or sheet");
            }
            else
            {
                int index = 1;
                param.ForEach(data =>           //遍历添加数据
                {
                    newCells.Add(nowRow, index, data);
                    index++;
                });
                nowRow++;                   //添加一行后往下添加
            }
        }
        /// <summary>
        /// 保存成文件
        /// </summary>
        public void SaveXls()
        {
            newXls.Save();
        }
        
    }
}
