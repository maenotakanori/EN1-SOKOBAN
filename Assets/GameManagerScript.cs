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
        //ˆÚ“®‰Â”\‚©”»’f  
        if (moveTo < 0 || moveTo >= map.Length){return false;}
        //ˆÚ“®æ‚É” ‚ª‚ ‚Á‚½‚ç
        if (map[moveTo] == 2)
        {
            //ˆÚ“®•ûŒüZo
            int velocity = moveTo - moveFrom;
            //player‚ÌˆÚ“®•ûŒü‚Ö” ‚ğˆÚ“®‚³‚¹‚é
            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            //” ‚ÌˆÚ“®‚ª¸”s‚µ‚½‚çplayer‚ÌˆÚ“®‚à¸”s
            if (success@== false) { return false; }
        }
        //ˆÚ“®
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
    
}
