using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioPrefab _audioPrefab;
    [SerializeField] private AudioPool _audioPool;

    [Range(0, 1)]
    public float VolumeMusic;
    [Range(0, 1)]
    public float VolumeSFX;

    [SerializeField] private List<AudioMusicCtrl> _listMusic;
    [SerializeField] private List<AudioSFXCtrl> _listSFX;

    protected override void LoadComponents()
    {
        if (_audioPrefab != null && _audioPool != null) return;
        _audioPrefab = GetComponentInChildren<AudioPrefab>();
        _audioPool = GetComponentInChildren<AudioPool>();
        Debug.Log("Load: " + transform.name);
    }
}
