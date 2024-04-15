using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    int[] map;

    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0, };
        PrintArray();
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

     // Update is called once per frame
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = GetPlayerIndex();

            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();
        }
     }
     void PrintArray()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ",";
        }
            Debug.Log(debugText);
     }
     int GetPlayerIndex()
    {
        for(int i = 0;i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
            return -1;
     }
     bool MoveNumber(int number,int moveFrom,int moveTo)
        {
        //�ړ��\�����f  
        if (moveTo < 0 || moveTo >= map.Length){return false;}
        //�ړ���ɔ�����������
        if (map[moveTo] == 2)
        {
            //�ړ������Z�o
            int velocity = moveTo - moveFrom;
            //player�̈ړ������֔����ړ�������
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //���̈ړ������s������player�̈ړ������s
            if (success�@== false) { return false; }
        }
        //�ړ�
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
    
}
