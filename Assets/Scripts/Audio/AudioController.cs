using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void MuteAudio(AudioSource audio)
    {
        var originalVolume = audio.volume;
    }
}
