using org.in2bits.MyXls;
using QF.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace QFramework.MFO
{
    public class JsonToExcelSystem
    {
        //������ǰ������xls�ĵ�
        private XlsDocument newXls;
        //������ǰ�����Ķ�Ӧ��sheet�еĵ�Ԫ��
        private Cells newCells;
        //��ǰsheet����ӵ���
        private int nowRow;
        /// <summary>
        /// �����µ�Xls�ļ�
        /// </summary>
        public void CreateExcelFile(string filePath,string fileName,
            string author = "LianBai",string subject = "Test")
        {  
            XlsDocument xls = new XlsDocument();    //����һ���µ�xls�ĵ�
            xls.FileName = filePath+fileName;                //�����ļ�����(·��+����)
            xls.SummaryInformation.Author = author; //����xls�ļ�������Ϣ
            xls.SummaryInformation.Subject = subject;   //����xls�ļ�������Ϣ

            newXls = xls;
            //Worksheet sheet = xls.Workbook.Worksheets.AddNamed(sheetName);  //���һ��sheetҳ��
        }
        /// <summary>
        /// ���һ���µ�sheet,�����迪ͷ
        /// </summary>
        public void AddNewSheet(string sheetName, params string[] param)
        {
            if (newXls == null)
            {
                Debug.LogError("LianBai:Please create new xls");
            }
            else
            {
                Worksheet sheet = newXls.Workbook.Worksheets.AddNamed(sheetName);   //���һ���µ�sheet
                newCells = sheet.Cells; //�޸ĵ�ǰ�����ĵ�Ԫ��
                int index = 1;      
                param.ForEach(tipName =>        //������ӱ�ͷ
                {
                    newCells.Add(1, index, tipName);
                    index++;
                });
                nowRow = 2;     //��ʼ���ӵڶ����������
            }

        }
        /// <summary>
        /// ��������sheet���������
        /// </summary>
        public void AddData(params object[] param)
        {
            if (newXls == null || newCells == null)     //�ж��ļ��Ƿ񱻴���
            {
                Debug.LogError("LianBai:Please create new xls or sheet");
            }
            else
            {
                int index = 1;
                param.ForEach(data =>           //�����������
                {
                    newCells.Add(nowRow, index, data);
                    index++;
                });
                nowRow++;                   //���һ�к��������
            }
        }
        /// <summary>
        /// ������ļ�
        /// </summary>
        public void SaveXls()
        {
            newXls.Save();
        }
        
    }
}
