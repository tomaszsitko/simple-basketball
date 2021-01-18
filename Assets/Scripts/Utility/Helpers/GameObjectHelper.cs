using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SimpleBasketball.Helpers
{
    public static class GameObjectHelper
    {
        public static List<T> InstatiateChildren<T>(this Transform parentTransform, T prefab, int count) where T : Component
        {
            var childs = parentTransform.GetComponentsInChildren<T>(true).ToList();

            int diff = count - childs.Count;

            if (diff > 0)
            {
                for (int i = 0; i < diff; i++)
                {
                    T newGameObj = GameObject.Instantiate(prefab, parentTransform);
                    newGameObj.transform.SetSiblingIndex(childs.Count + i);
                    childs.Add(newGameObj);
                }
            }
            else if (diff < 0)
            {
                for (int i = diff; i < 0; i++)
                {
                    GameObject.DestroyImmediate(childs[childs.Count - 1]);
                    childs.RemoveAt(childs.Count - 1);
                }
            }

            return childs;
        }
    }
}