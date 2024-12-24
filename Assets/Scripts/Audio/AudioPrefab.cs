using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPrefab : PISMonoBehaviour
{
    [SerializeField] private List<AudioMusicCtrl> _listAudioMusicPrefabs = new();
    [SerializeField] private List<AudioSFXCtrl> _listAudioSFXPrefabs = new();

    protected override void LoadComponents()
    {
        LoadListAudioMusicPrefab();
        LoadListAudioSFXPrefab();

        //if (_listMusicPrefab.Count == transform.childCount) return;
        //if (_listSFXPrefab.Count == transform.childCount) return;
        //foreach (Transform child in transform)
        //{
        //    AudioMusicCtrl ausMusicPrefab = child.GetComponent<AudioMusicCtrl>();
        //    AudioSFXCtrl ausSFXPrefab = child.GetComponent<AudioSFXCtrl>();
        //    if (ausMusicPrefab != null) _listMusicPrefab.Add(ausMusicPrefab);
        //    if (ausSFXPrefab != null) _listSFXPrefab.Add(ausSFXPrefab);
        //}
        //Debug.Log("Load: " + transform.name);
    }

    private void LoadListAudioMusicPrefab()
    {
        if (_listAudioMusicPrefabs.Count > 0) return;
        _listAudioMusicPrefabs.Clear();
        AudioMusicCtrl[] musicPrefabs = Resources.LoadAll<AudioMusicCtrl>("Audios/AudioMusic");
        foreach (AudioMusicCtrl musicPrefab in musicPrefabs)
        {
            if (musicPrefab != null) _listAudioMusicPrefabs.Add(musicPrefab);
        }
        Debug.Log("Load: " + transform.name);
    }

    private void LoadListAudioSFXPrefab()
    {
        if (_listAudioSFXPrefabs.Count > 0) return;
        _listAudioSFXPrefabs.Clear();
        AudioSFXCtrl[] sfxPrefabs = Resources.LoadAll<AudioSFXCtrl>("Audios/AudioSFX");
        foreach (AudioSFXCtrl sfxPrefab in sfxPrefabs)
        {
            if (sfxPrefab != null) _listAudioSFXPrefabs.Add(sfxPrefab);
        }
        Debug.Log("Load: " + transform.name);
    }

    public AudioMusicCtrl GetAudioMusic()
    {
        foreach (var inList in _listAudioMusicPrefabs)
        {
            if (inList.GetType() == typeof(AudioMusicGamePlay))
            {
                return inList;
            }
        }
        return null;
    }

    public AudioSFXCtrl GetAudioSFXTowerFire()
    {
        foreach (var inList in _listAudioSFXPrefabs)
        {
            if (inList.GetType() == typeof(AudioSFXTowerFire))
            {
                return inList;
            }
        }
        return null;
    }
}
