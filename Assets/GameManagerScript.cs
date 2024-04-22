using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerPrefab;
    int[,] map; //���x���f�U�C���p�̔z��
    GameObject[,] field; // �Q�[�������p�̔z��

    // Start is called before the first frame update
    void Start()
    {
        map = new int[,] {
           {0,0,0,0,0 },
           {0,0,1,0,0 },
           {0,0,0,0,0 },
        };
        field = new GameObject
            [
             map.GetLength(0),
             map.GetLength(1)
            ];
        for(int y = 0; y < map.GetLength(0); y++)
        {
            for(int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y,x] == 1)
                {
                    field[y,x] = Instantiate(
                    playerPrefab,
                    new Vector3(x, map.GetLength(0) - 1 - y, 0),
                    Quaternion.identity
                  );
                }
            }
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //   if (Input.GetKeyDown(KeyCode.RightArrow))
    //   {
    //       //int playerIndex = GetPlayerIndex();
            //MoveNumber(1, playerIndex, playerIndex + 1);
            //PrintArray();
    //   }
    //}
     void PrintArray()
    {
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //        Debug.Log(debugText);
     }
    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null) { continue; }
                if (field[y, x].tag == "Player") { return new Vector2Int(x, y); }
            }
        }
            return new Vector2Int(-1,-1);
     }
     bool MoveNumber(int number,int moveFrom,int moveTo)
        {
        //�ړ��\�����f  
        if (moveTo < 0 || moveTo >= map.Length){return false;}
        //�ړ���ɔ�����������
        //if (map[moveTo] == 2)
        //{
            //�ړ������Z�o
            int velocity = moveTo - moveFrom;
            //player�̈ړ������֔����ړ�������
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //���̈ړ������s������player�̈ړ������s
            if (success�@== false) { return false; }
       // }
        //�ړ�
       // map[moveTo] = number;
       // map[moveFrom] = 0;
        return true;
    }
    
}
