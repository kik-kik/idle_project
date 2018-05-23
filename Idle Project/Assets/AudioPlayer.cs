using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {

    #region variables
    [Header("Volume")]
    [Range(0, 0.5f)] public float defaultVolume = 0.03f;
    [SerializeField] private float maxVolume = 0.03f;
    [SerializeField] private float minVolume = 0f;
    private float lastVolumeLevel = 0f;

    private bool muteOn = false;

    public static AudioPlayer _instance = null;

    private AudioSource audioSource;
    #endregion

    #region getters_and_setters
    public static AudioPlayer _Instance
    {
        get
        {
            _instance = FindObjectOfType<AudioPlayer>();
            if (_instance == null)
            {
                GameObject go = new GameObject
                {
                    name = "Sound Manager"
                };

                _instance = go.AddComponent<AudioPlayer>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public bool MuteOn
    {
        get
        {
            return muteOn;
        }
    }
    #endregion


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = defaultVolume;
        audioSource.Play();
    }

    /// <summary>
    /// This method checks if the newVolume is within the allowed range, if yes then the volume gets changed
    /// </summary>
    /// <param name="newVolume"></param>
    void ChangeVolume(float newVolume)
    {
        if (newVolume <= maxVolume && newVolume >= minVolume)
        {
            audioSource.volume = newVolume;
        }
    }
    

    /// <summary>
    /// This method mutes and unmutes the music.
    /// </summary>
    public void MuteSound()
    {
        if (muteOn)
        {
            audioSource.volume = lastVolumeLevel;
        }
        else {
            lastVolumeLevel = audioSource.volume;
            audioSource.volume = 0f;
        }
        muteOn = !muteOn;
    }
}
