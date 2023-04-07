using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioSource> Sources;
    public Dictionary<string, AudioSource> AudioSources => Sources.ToDictionary(x=> x.gameObject.name, x => x);

    public void PlaySound(string name)
    {
        AudioSources[name].Stop();
        AudioSources[name].Play();
    }

    public void StopSound(string name)
    {
        AudioSources[name].Stop();
    }

    public void PauseSound(string name)
    {
        AudioSources[name].Pause();
    }

    public void StopAllSounds()
    {
        foreach(AudioSource source in Sources)
        {
            source.Pause();
        }
    }

    public void ContinueAllSounds()
    {
        foreach (AudioSource source in Sources)
        {
            source.Play();
        }
    }
}
