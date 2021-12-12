using UnityEngine.Audio;
using UnityEngine;

public class settingsmenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void setvolume(float volume)
    {
         audioMixer.SetFloat("volume",volume);
    }
    public void setfullscreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }

    public void setquality (int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
    }
}
