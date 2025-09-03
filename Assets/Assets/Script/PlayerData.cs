using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.GraphView;

public class PlayerData : MonoBehaviour
{
    public CardStore cardStore;
    public int playerCoins;
    public int[] playerCards;

    public TextAsset playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardStore.LoadCardData();
        LoadPlayerData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayerData()
    {
        playerCards = new int[cardStore.cardList.Count];

        string[] dataRow = playerData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if(rowArray[0] == "coins")
            {
                playerCoins = int.Parse(rowArray[1]);
            }
            else if (rowArray[0] == "card")
            {
                int id = int.Parse(rowArray[1]);
                int num = int.Parse(rowArray[2]);
                //载入玩家数据
            }
        }

    }
    public void SavePlayerData() 
    {
        string path = Application.dataPath + "/Datas/playerdata.csv";


        List<string> datas = new List<string>();
        datas.Add("coins, " + playerCoins.ToString());
        for (int i = 0; i < playerCards.Length; i++)
        {
            if (playerCards[i] != 0)
            {
             datas.Add("card," + i.ToString() + ","  + playerCards[i].ToString());
            }
            //保存卡组

            //保存数据
            File.WriteAllLines(path, datas);
            Debug.Log(datas);
        }
    }
}
