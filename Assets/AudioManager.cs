using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public enum SoundEffect
    {
        Clear,

    }



    public AudioSource destroyAudioSource;


    public void PlayAudio(SoundEffect type)
    {
        AudioSource source = null;

        switch (type)
        {
            case SoundEffect.Clear:
                source = destroyAudioSource;
                break;

        }

        if (source != null)
        {
            GameObject go = new GameObject();
            var audiosource = go.AddComponent<AudioSource>();
            audiosource.clip = source.clip;
            audiosource.outputAudioMixerGroup = source.outputAudioMixerGroup;
            audiosource.volume = source.volume;
            audiosource.Play();

            GameObject.Destroy(go, audiosource.clip.length);
        }
    }
}
