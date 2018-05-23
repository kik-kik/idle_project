using UnityEngine;

public static class SaveGameData{

    //save the game automatically when the player quits
    public static void Save()
    {
        SaveCurrentSystemTime();
        SaveResourceBalances();
        
        PlayerPrefs.SetInt("SaveGame", 1); //This can be used to check if save game exists
    }


    private static void SaveCurrentSystemTime()
    {
        //save the current system time as string in player prefs class.
        PlayerPrefs.SetString("SaveDateTime", System.DateTime.Now.ToBinary().ToString());
    }

    
    /// <summary>
    /// This method saves the current values of TotalCash, TotalCrystal, and CratesTotal held by ResouceManager
    /// </summary>
    private static void SaveResourceBalances()
    {
        PlayerPrefs.SetInt("CashResource",      ResourceManager.instance.TotalCash);
        PlayerPrefs.SetInt("CrystalResource",   ResourceManager.instance.CrystalTotal);
        PlayerPrefs.SetInt("CrateResource",     ResourceManager.instance.CratesTotal);
        PlayerPrefs.SetFloat("IncomePerSecond",   ResourceManager.instance.IncomePerSecond);
    }

}
