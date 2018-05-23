using UnityEngine;

public class ResourceManager : MonoBehaviour {

    #region variables
    [Header("Super Cash properties")]
    [SerializeField] private int totalCash = 0;
    [SerializeField] private int incomeRate = 10;
    [SerializeField] private float incomePerSecond = 0.1f;
    private float lastIncomeValue = 0f;
    [Range(1, 3)]
    [SerializeField] private float incomeModifier = 1.5f;

    [Header("Crystal Properties")]
    [SerializeField] private int crystalTotal = 0;

    [Header("Crates Properties")]
    [SerializeField] private int cratesTotal = 0;

    float timer = 0.0f;
    int secondsSinceLastCollection = 0;

    public static ResourceManager instance;
    #endregion

    #region getters_and_setters
    #region superCashProperties
    public int TotalCash
    {
        get
        {
            return totalCash;
        }
        set
        {
            totalCash = value;
        }
    }

    public int IncomeRate
    {
        get
        {
            return incomeRate;
        }
        set
        {
            incomeRate = value;
        }
    }

    public float IncomeModifier { get; set; }
    #endregion

    #region crystalProperties
    public int CrystalTotal
    {
        get
        {
            return crystalTotal;
        }
        set
        {
            crystalTotal = value;
        }
    }
    #endregion

    #region cratesProperties
    public int CratesTotal
    {
        get
        {
            return cratesTotal;
        }
        set
        {
            cratesTotal = value;
        }
    }
    #endregion

    public float IncomePerSecond
    {
        get
        {
            return incomePerSecond;
        }
        set
        {
            incomePerSecond = value;
        }
    }
    #endregion

    /// <summary>
    /// When the game is closed the game data gets saved
    /// </summary>
    public void OnApplicationQuit()
    {
        SaveGameData.Save();
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    
    private void Start()
    {
        LoadGameData.LoadSaveGame(); // Loading game data
    }


    private void Update()
    {
        timer += Time.deltaTime;
        secondsSinceLastCollection = (int)timer % 60;
    }

    /// <summary>
    /// CAUTION! This method resets all PlayerPrefs and resets all values to defaults
    /// </summary>
    public void ResetSaveGame()
    {
        PlayerPrefs.DeleteAll();

        // TODO: make these values variables instead
        totalCash = 0;
        CrystalTotal = 50;
        cratesTotal = 0;
        incomePerSecond = 0.1f;
    }


    /// <summary>
    /// This method works out the Coin income per second
    /// </summary>
    void UpdateIncomePerSecond()
    {
        incomePerSecond = lastIncomeValue / secondsSinceLastCollection;

        timer = 0f;
        secondsSinceLastCollection = 0;
    }


    /// <summary>
    /// This method calculates how much idlecash was earned based on idleTime in seconds. Then this value gets added to the TotalCash held by the ResourceManager.
    /// </summary>
    /// <param name="idleTimeInSeconds"></param>
    public void AddIdleCash(float idleTimeInSeconds)
    {
        int IdleCash = (int)(IncomePerSecond * idleTimeInSeconds);
        totalCash += IdleCash;

        #if UNITY_EDITOR
            Debug.Log("Idle Cash added: " + IdleCash);
        #endif
    }

    /// <summary>
    /// Adds the specified amount to the amount of Cash resource held by the player.
    /// </summary>
    /// <param name="cashToAdd"></param>
    public void AddCash(int cashToAdd)
    {
        cashToAdd = (int)(cashToAdd * incomeModifier);
        lastIncomeValue = cashToAdd;
        totalCash += cashToAdd;
        UpdateIncomePerSecond();
    }

    /// <summary>
    /// Adds the specified amount to the amount of Crystal resource held by the player.
    /// </summary>
    /// <param name="crystalsToAdd"></param>
    public void AddCrystals(int crystalsToAdd)
    {
        crystalTotal += crystalsToAdd;
    }

    /// <summary>
    /// Adds the specified amount to the amount of Crate resource held by the player.
    /// </summary>
    /// <param name="cratesToAdd"></param>
    public void AddCrate(int cratesToAdd)
    {
        cratesTotal += cratesToAdd;
    }

    /// <summary>
    /// Removes the specified amount to the amount of Cash resource held by the player.
    /// </summary>
    /// <param name="cashToRemove"></param>
    public void RemoveCash(int cashToRemove)
    {
        totalCash -= cashToRemove;
    }

    /// <summary>
    /// Removes the specified amount to the amount of Crystal resource held by the player.
    /// </summary>
    /// <param name="crystalsToRemove"></param>
    public void RemoveCrystals(int crystalsToRemove)
    {
        crystalTotal -= crystalsToRemove;
    }

    /// <summary>
    /// Removes the specified amount to the amount of Crate resource held by the player.
    /// </summary>
    /// <param name="cratesToRemove"></param>
    public void RemoveCrates(int cratesToRemove)
    {
        cratesTotal -= cratesToRemove;
    }

}
