using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerPrefab;
    int[,] map; //レベルデザイン用の配列
    GameObject[,] field; // ゲーム完了用の配列

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
        //移動可能か判断  
        if (moveTo < 0 || moveTo >= map.Length){return false;}
        //移動先に箱があったら
        //if (map[moveTo] == 2)
        //{
            //移動方向算出
            int velocity = moveTo - moveFrom;
            //playerの移動方向へ箱を移動させる
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //箱の移動が失敗したらplayerの移動も失敗
            if (success　== false) { return false; }
       // }
        //移動
       // map[moveTo] = number;
       // map[moveFrom] = 0;
        return true;
    }
    
}
