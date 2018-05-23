using System;
using UnityEngine;

public static class LoadGameData {

    static DateTime currentDate;
    static DateTime oldDate;


    //load the game automatically when the player open the game
    public static void LoadSaveGame()
    {
        if (IsGameSaved())
        {
            float idleTimeInSeconds = GetIdleTime();

            LoadResourceBalances();
            ResourceManager.instance.AddIdleCash(idleTimeInSeconds);
        }
    }


    /// <summary>
    /// This method checks the value of 'SaveGame' in PlayerPrefs. Returns true if the value found is 1
    /// </summary>
    /// <returns></returns>
    private static bool IsGameSaved()
    {
        if (PlayerPrefs.GetInt("SaveGame") == 1)
        {
            return true;
        }
        else {
            return false;
        }
    }


    /// <summary>
    /// This method gets the idle time between the game save and game load.
    /// </summary>
    /// <returns></returns>
    private static float GetIdleTime()
    {
        float idleTime = 0f;

        long temp = Convert.ToInt64(PlayerPrefs.GetString("SaveDateTime"));
        DateTime oldDate = DateTime.FromBinary(temp);

        currentDate = DateTime.Now;
        TimeSpan timeDifference = currentDate.Subtract(oldDate);

        //Get the idle time in seconds
        idleTime = (float)timeDifference.TotalSeconds;

        return idleTime;
    }


    /// <summary>
    /// This method loads the values sotred for TotalCash, TotalCrystal, and CratesTotal and adds sets them to ResourceManager
    /// </summary>
    private static void LoadResourceBalances()
    {
        ResourceManager.instance.TotalCash          = PlayerPrefs.GetInt("CashResource");
        ResourceManager.instance.CrystalTotal       = PlayerPrefs.GetInt("CrystalResource");
        ResourceManager.instance.CratesTotal        = PlayerPrefs.GetInt("CrateResource");
        ResourceManager.instance.IncomePerSecond    = PlayerPrefs.GetInt("IncomePerSecond");
    }
}
