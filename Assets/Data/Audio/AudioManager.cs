using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : TruongMonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance => instance;

    [SerializeField] protected List<AudioSource> audioSources;
    public List<AudioSource> AudioSources => audioSources;

    [SerializeField] protected float oldVolume = 0f;

    [SerializeField] protected bool stopMusic = false;
    public bool StopMusic { get => stopMusic; set => stopMusic = value; }


    protected override void Awake()
    {
        base.Awake();
        if (AudioManager.instance != null) Debug.LogError("Only 1 AudioManager allow to exist");
        AudioManager.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.PlayAudio("Soundtrack");
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource()
    {
        AudioSource[] sources = GameObject.FindObjectsOfType<AudioSource>(true);
        foreach (AudioSource source in sources)
        {
            if(source.volume == 1) source.volume = 0.2f;
            this.audioSources.Add(source);
        }
        Debug.LogWarning(transform.name + ": LoadAudioSource", gameObject);
    }

    public virtual void PlayAudio(string nameAudio)
    {
        if (this.stopMusic) return;

        for(int i = 0; i < this.audioSources.Count; i++)
            if (this.audioSources[i].name == nameAudio) this.audioSources[i].Play();
    }

    public virtual void StopAudio(string nameAudio)
    {
        for (int i = 0; i < this.audioSources.Count; i++)
            if (this.audioSources[i].name == nameAudio) this.audioSources[i].Stop();
    }

    public virtual void DisableVolume(string nameAudio)
    {
        for (int i = 0; i < this.audioSources.Count; i++)
            if (this.audioSources[i].name == nameAudio) {
                this.oldVolume = this.audioSources[i].volume;
                this.audioSources[i].volume = 0;
            }     
    }

    public virtual void EnableVolume(string nameAudio)
    {
        if (this.stopMusic) return;

        for (int i = 0; i < this.audioSources.Count; i++)
            if (this.audioSources[i].name == nameAudio)
                this.audioSources[i].volume = this.oldVolume;
    }
}
