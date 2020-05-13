using System;
using System.Collections;
using System.Collections.Generic;
using QF;
using UnityEngine;

namespace QFramework.MFO
{
    public enum DataType
    {
        //���ѡ��Ľ�ɫ
        playerName,
        //���ͨ������ߵȼ�
        levelMax,
        //���������Ĺؿ�
        playLevel
    }
    /// <summary>
    /// ����ļ���������
    /// </summary>
    public class CacheDataManage : Singleton<CacheDataManage>
    {
        public void RescoveyCacheData()
        {
            PlayerPrefs.DeleteAll();
            if (!PlayerPrefs.HasKey(DataType.playerName.ToString()))
            {
                PlayerPrefs.SetString(DataType.playerName.ToString(), "Player_2");
                PlayerPrefs.SetInt(DataType.levelMax.ToString(), 1);
            }
        }

        public void SetIntData(DataType type,int data)
        {
            PlayerPrefs.SetInt(type.ToString(), data);
        }
        public int GetIntData(DataType type)
        {
            if (!PlayerPrefs.HasKey(type.ToString()))
            {
                Debug.LogError("LB:Don't have this Data"+type);
            }
            return PlayerPrefs.GetInt(type.ToString());
        }
        public void SetStringData(DataType type, string data)
        {
            PlayerPrefs.SetString(type.ToString(), data);
        }
        public string GetStringData(DataType type)
        {
            if (!PlayerPrefs.HasKey(type.ToString()))
            {
                Debug.LogError("LB:Don't have this Data" + type);
            }
            return PlayerPrefs.GetString(type.ToString());
        }
        private CacheDataManage()
        {

        }

    }
}
