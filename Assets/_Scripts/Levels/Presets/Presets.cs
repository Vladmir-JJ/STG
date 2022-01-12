using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace JJ.STG.Enemy
{
    public static class Presets
    {
        //allowed spawnpoints on x axis of foes
        public static List<int> ListOfX8 = new List<int>()
        {
            { -7 }, { -5 }, { -3 }, { -1 }, { 1 }, { 3 }, { 5 }, { 7 }
        };
        public static List<int> ListOfX7 = new List<int>()
        {
            { -6 }, { -4 }, { -2 }, { 0 }, { 2 }, { 4 }, { 6 }
        };
        public static List<int> ListOfX6 = new List<int>()
        {
            { -5 }, { -3 }, { -1 }, { 1 }, { 3 }, { 5 }
        };
        public static List<int> ListOfX5 = new List<int>()
        {
            { -4 }, { -2 }, { 0 }, { 2 }, { 4 }
        };
        public static List<int> ListOfX4 = new List<int>()
        {
            { -3 }, { -1 }, { 1 }, { 3 }
        };
        public static List<int> ListOfX3 = new List<int>()
        {
            { -2 }, { 0 }, { 2 }
        };
        public static List<int> ListOfX2 = new List<int>()
        {
            { -1 }, { 1 }
        };
        public static List<int> ListOfX1 = new List<int>()
        {
            { 0 }
        };
        //where first line of enemies starts - level ID is used as index to call list position
        public static List<int> StartPosY = new List<int>()
        {
            { 10 }, { 8 }, { 6 }, { 6 }, { 5 }
        };
        public static List<List<int>> poolOfSpawns = new List<List<int>>()
        {
            { ListOfX1 }, { ListOfX2 }, { ListOfX3 }, { ListOfX4 }, { ListOfX5 }, { ListOfX6 }, { ListOfX7 }, { ListOfX8 }
        };
        //uses Start posy as key to determine number of lines
        public static Dictionary<int, int> NumberOfLinesDic = new Dictionary<int, int>()
        {
            { 10, 3 },
            { 8, 4 },
            { 6, 5 },
            { 5, 6 }
        };        
    }
}

