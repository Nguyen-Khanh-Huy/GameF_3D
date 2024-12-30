using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioPrefab _audioPrefab;
    [SerializeField] private AudioPool _audioPool;

    [Range(0, 1)]
    public float VolumeMusic = 0.5f;
    [Range(0, 1)]
    public float VolumeSFX = 1f;

    [SerializeField] private List<AudioCtrl> _listSetVolumeMusic;
    [SerializeField] private List<AudioCtrl> _listSetVolumeSFX;

    private void Start()
    {
        SpawnMusic(typeof(AudioMusicGamePlay));
    }
    protected override void LoadComponents()
    {
        if (_audioPrefab != null && _audioPool != null) return;
        _audioPrefab = GetComponentInChildren<AudioPrefab>();
        _audioPool = GetComponentInChildren<AudioPool>();
        Debug.Log("Load: " + transform.name);
    }

    public void SetVolume(AudioCtrl audioMusic, float volume)
    {
        audioMusic.AudioSource.volume = volume;
    }

    public void UpdateVolumeMusic(float volume)
    {
        VolumeMusic = volume;
        foreach (AudioCtrl audioCtrl in _listSetVolumeMusic)
        {
            audioCtrl.AudioSource.volume = VolumeMusic;
        }
    }

    public void UpdateVolumeSFX(float volume)
    {
        VolumeMusic = volume;
        foreach (AudioCtrl audioCtrl in _listSetVolumeSFX)
        {
            audioCtrl.AudioSource.volume = VolumeSFX;
        }
    }

    public void SpawnMusic(Type audioMusicCtrl)
    {
        AudioCtrl newMusicPrefab = _audioPrefab.GetMusicPrefab(audioMusicCtrl);
        if (newMusicPrefab != null)
        {
            AudioCtrl newMusic = PoolManager<AudioCtrl>.Ins.Spawn(newMusicPrefab, Vector3.zero, Quaternion.identity);
            SetVolume(newMusic, VolumeMusic);
            if (_listSetVolumeMusic.Contains(newMusic)) return;
            _listSetVolumeMusic.Add(newMusic);
        }
    }

    public void SpawnSFX(Type audioSFXCtrl, Vector3 position)
    {
        AudioCtrl newSFXPrefab = _audioPrefab.GetSFXPrefab(audioSFXCtrl);
        if (newSFXPrefab != null)
        {
            AudioCtrl newSFX = PoolManager<AudioCtrl>.Ins.Spawn(newSFXPrefab, position, Quaternion.identity);
            SetVolume(newSFX, VolumeSFX);
            if (_listSetVolumeSFX.Contains(newSFX)) return;
            _listSetVolumeSFX.Add(newSFX);
        }
    }
}
