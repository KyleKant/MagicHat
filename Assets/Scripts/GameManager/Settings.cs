using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle muteToggle;
    [SerializeField] private Toggle backgroundMusicToggle;
    [SerializeField] private Toggle buttonSoundToggle;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource buttonSound;

    private SettingsData setSettingsData;
    private SettingsData getSettingsData;
    private SettingsDataManager settingsDataManager;
    private void Start()
    {
        settingsDataManager = FindObjectOfType<SettingsDataManager>();
        setSettingsData = new();
        if (volumeSlider != null)
            volumeSlider.onValueChanged.AddListener(delegate { ChangeVolumeSound(); });
        if (muteToggle != null)
            muteToggle.onValueChanged.AddListener(delegate { MuteAllSound(); });
        if (backgroundMusicToggle != null)
            backgroundMusicToggle.onValueChanged.AddListener(delegate { MuteBackgroundMusic(); });
        if (buttonSoundToggle != null)
            buttonSoundToggle.onValueChanged.AddListener(delegate { MuteButtonSound(); });
        if (!settingsDataManager.CheckFileIsExist("SettingsData.json"))
        {
            setSettingsData.soundVolume = AudioListener.volume;
            setSettingsData.muteAllSounds = AudioListener.pause;
            setSettingsData.muteBackgroundMusic = backgroundMusic.mute;
            setSettingsData.muteButtonSound = buttonSound.mute;
            settingsDataManager.WriteSettingsData("SettingsData.json", setSettingsData);
        }
    }
    private void Update()
    {
        ReadSettingsData("SettingsData.json");
    }
    private void MuteButtonSound()
    {
        //buttonSound.mute = !buttonSound.mute;
        setSettingsData.muteButtonSound = buttonSoundToggle.isOn;
    }

    private void MuteAllSound()
    {
        //AudioListener.pause = !AudioListener.pause;
        setSettingsData.muteAllSounds = muteToggle.isOn;
    }

    private void MuteBackgroundMusic()
    {
        //backgroundMusic.mute = !backgroundMusic.mute;
        setSettingsData.muteBackgroundMusic = backgroundMusicToggle.isOn;
    }

    private void ChangeVolumeSound()
    {
        //AudioListener.volume = volumeSlider.value;
        setSettingsData.soundVolume = volumeSlider.value;
    }
    public void WriteSettingsFile(string fileName)
    {
        settingsDataManager.WriteSettingsData(fileName, setSettingsData);
    }
    private void ReadSettingsData(string fileName)
    {
        getSettingsData = settingsDataManager.ReadSettingsData(fileName);

        buttonSound.mute = getSettingsData.muteButtonSound;
        AudioListener.pause = getSettingsData.muteAllSounds;
        backgroundMusic.mute = getSettingsData.muteBackgroundMusic;
        AudioListener.volume = getSettingsData.soundVolume;
    }
    public void SetSettingsDataForOptionPanel()
    {
        buttonSoundToggle.isOn = buttonSound.mute;
        muteToggle.isOn = AudioListener.pause;
        backgroundMusicToggle.isOn = backgroundMusic.mute;
        volumeSlider.value = AudioListener.volume;
    }
}
