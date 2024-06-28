using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    Resolution[] resolutions;
    HashSet<string> uniqueResolutions = new HashSet<string>();
    int currentResolutionIndex = 0;

    void Start()
    {
        ResolutionDropdown();
        QualityDropdown();
    }

    public void SetResolution(int resolutionIndex)
    {
        List<Resolution> filteredResolution = new List<Resolution>(uniqueResolutions.Count);
        foreach (string resolutionStr in uniqueResolutions)
        {
            Resolution res = ResolutionFromString(resolutionStr);
            filteredResolution.Add(res);
        }

        Resolution selectedResolution = filteredResolution[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void QualityDropdown()
    {
        string[] qualityNames = QualitySettings.names;

        qualityDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentQualityIndex = QualitySettings.GetQualityLevel();

        for (int i = 0; i < qualityNames.Length; i++)
        {
            options.Add(qualityNames[i]);
        }

        qualityDropdown.AddOptions(options);
        qualityDropdown.value = currentQualityIndex;
        qualityDropdown.RefreshShownValue();
    }

    public void ResolutionDropdown()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        uniqueResolutions.Clear();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionStr = $"{resolutions[i].width}x{resolutions[i].height}";
            uniqueResolutions.Add(resolutionStr);
        }

        List<string> options = new List<string>(uniqueResolutions);

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    private Resolution ResolutionFromString(string resolutionStr)
    {
        string[] parts = resolutionStr.Split('x');
        int width = int.Parse(parts[0]);
        int height = int.Parse(parts[1]);
        return new Resolution { width = width, height = height };
    }
}
