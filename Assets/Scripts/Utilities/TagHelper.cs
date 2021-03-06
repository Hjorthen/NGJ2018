﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public enum Tags
    {
        Tile_1,
        Tile_2,
        Tile_3,
        Wall_1,
        Stove,
        DeathScreen
    }
    public static class TagHelper
    {
        static private Dictionary<Tags, string> sTagsCache;

        static TagHelper()
        {
            sTagsCache = new Dictionary<Tags, string>();
            string[] names = Enum.GetNames(typeof(Tags));
            for (int i = 0; i < names.Length; i++)
            {
                string formatted = names[i].Replace('_', ' ');
                sTagsCache.Add((Tags)i, formatted);
            }
        }
        
        public static string ConvertToString(Tags t)
        {
            return sTagsCache[t];
        }

        
        public static T GetFirstComponent<T>(Tags t) where T : Behaviour
        {
            GameObject obj = GetFirst(t);
            if (obj == null)
                return null;

            return obj.GetComponent<T>();
        }

        public static GameObject GetFirst(Tags tag)
        {
            return GameObject.FindGameObjectWithTag(ConvertToString(tag));
        }

        public static bool HasTag(GameObject a, Tags t)
        {
            string s;
            if(sTagsCache.TryGetValue(t, out s))
            {
                return a.CompareTag(s);
            }
            return false;
        }
    }
}
