using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map; //レベルデザイン用の配列
    GameObject[,] field; // ゲーム完了用の配列

    // Start is called before the first frame update
    void Start()
    {
        map = new int[,] {
           {1,0,2,0,3 },
           {0,0,2,0,3 },
           {0,0,2,0,3 },
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
                    new Vector3(x, map.GetLength(0) - y, 0),
                    Quaternion.identity

                  );
                }
                if (map[y,x] == 2)
                {
                    field[y, x] = Instantiate(
                    boxPrefab,
                    new Vector3(x,map.GetLength(0) - y,0),
                    Quaternion.identity
                  );
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.RightArrow))
       {
           Vector2Int playerIndex = GetPlayerIndex();
           MoveNumber(
               playerIndex, 
               playerIndex + new Vector2Int(1,0));
            //PrintArray();
            if (IsCleard())
            {
                Debug.Log("Clear");
                //3-2 end
            }
       }
   


        //上下左移動も
    }
    //void PrintArray()
    //{
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //        Debug.Log(debugText);
    // }
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
    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; }

         if (field[moveTo.y,moveTo.x] != null && field[moveTo.y,moveTo.x].tag == "Box")
         {
                Vector2Int velocity = moveTo - moveFrom;
                bool success = MoveNumber(moveTo, moveTo + velocity);
                if (!success) { return false; }
         }

         field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
         field[moveFrom.y, moveFrom.x].transform.position =
             new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
         field[moveFrom.y, moveFrom.x] = null;
        return true;
    }
    bool IsCleard() {
        List<Vector2Int> goals = new List<Vector2Int>();
        for(int y = 0;y < map.GetLength(0); y++)
        {
            for(int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y,x] == 3)
                {
                    goals.Add(new Vector2Int(x, y));
                }
            }
        }

        for(int i = 0;i < goals.Count; i++)
        {
            GameObject f = field[goals[i].y, goals[i].x];
            if(f == null || f.tag != "Box")
            {
                return false;
            }
        }
        return true;
    }
    //文末にreturn true;
}
