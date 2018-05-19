using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour {

    [SerializeField] private static int haveCrates = 0;

    public int HaveCrates
    {
        get
        {
            return haveCrates;
        }
        set
        {
            if (haveCrates >= 0)
            {
                haveCrates = value;
            }
            else
            {
                return;
            }
        }
    }

    public static void AddCrates(int cratesToAdd)
    {
        haveCrates += cratesToAdd;
    }

    public static void UseCrate()
    {
        haveCrates -= 1;
    }
}
