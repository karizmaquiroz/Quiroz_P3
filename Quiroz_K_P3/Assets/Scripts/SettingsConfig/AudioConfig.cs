using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.VFX;


public class AudioConfig : MonoBehaviour
{
    public GameObject SettingsPane;
    public Button MonoButton;
    public Button StereoButton;
    public Button SurroundButton;
    public Button SurroundButton5;
    public Button SurroundButton7;

    private bool isSettingPane = false;

    private void Start()
    {
        SettingsPane.SetActive(false);
        SetDefaults();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isSettingPane = (isSettingPane) ? false : true;
            OpenSettings();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        MonoButton.onClick.AddListener(MonoButtonClick);
        StereoButton.onClick.AddListener(StereoButtonClick);
        SurroundButton.onClick.AddListener(SurroundButtonClick);
        SurroundButton5.onClick.AddListener(Surround5ButtonClick);
        SurroundButton7.onClick.AddListener(Surround7ButtonClick);
    }
    public void OpenSettings()
    {
        if (!isSettingPane)
        {
            SettingsPane.SetActive(false);
        }
        else if (isSettingPane)
        {
            SettingsPane.SetActive(true);
        }
    }
    public void SetDefaults()
    {
        SetAudioType("Stereo");
    }
    public void MonoButtonClick()
    {
        SetAudioType("Mono");
    }
    public void StereoButtonClick()
    {
        SetAudioType("Stereo");
    }
    public void SurroundButtonClick()
    {
        SetAudioType("Surround");
    }
    public void Surround5ButtonClick()
    {
        SetAudioType("Surround 5.1");
    }
    public void Surround7ButtonClick()
    {
        SetAudioType("Surround 7.1");
    }

    public void SetAll()
    {
        SetAudioType(PlayerPrefs.GetString("AudioType"));

        AudioSource[] audios = GameObject.FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

        foreach (AudioSource source in audios)
        {
            if (source.name.Contains("Music"))
            {
                source.GetComponent<MusicManager>().bgVolume = PlayerPrefs.GetFloat("MusicVolume");

            }
            else if (source.name.Contains("SFX"))
            {
                source.GetComponent<SoundEffectConfig>().sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
            }
        }
    }

    public void SetAudioType(string SpeakerMode)
    {
        AudioConfiguration audioConfig = AudioSettings.GetConfiguration();
        switch (SpeakerMode)
        {
            case "Mono":
                audioConfig.speakerMode = AudioSpeakerMode.Mono;
                break;
            case "Stereo":
                audioConfig.speakerMode = AudioSpeakerMode.Stereo;
                break;
            case "Surround":
                audioConfig.speakerMode = AudioSpeakerMode.Surround;
                break;
            case "Surround 5.1":
                audioConfig.speakerMode = AudioSpeakerMode.Mode5point1;
                break;
            case "Surround 7.1":
                audioConfig.speakerMode = AudioSpeakerMode.Mode7point1;
                break;
        }
    }
}
