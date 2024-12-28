using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPrefab : PISMonoBehaviour
{
    [SerializeField] private List<AudioCtrl> _listMusicPrefabs = new();
    [SerializeField] private List<AudioCtrl> _listSFXPrefabs = new();

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
        if (_listMusicPrefabs.Count > 0) return;
        _listMusicPrefabs.Clear();
        AudioCtrl[] musicPrefabs = Resources.LoadAll<AudioCtrl>("Audios/Music");
        foreach (AudioCtrl musicPrefab in musicPrefabs)
        {
            if (musicPrefab != null) _listMusicPrefabs.Add(musicPrefab);
        }
        Debug.Log("Load: " + transform.name);
    }

    private void LoadListAudioSFXPrefab()
    {
        if (_listSFXPrefabs.Count > 0) return;
        _listSFXPrefabs.Clear();
        AudioCtrl[] sfxPrefabs = Resources.LoadAll<AudioCtrl>("Audios/SFX");
        foreach (AudioCtrl sfxPrefab in sfxPrefabs)
        {
            if (sfxPrefab != null) _listSFXPrefabs.Add(sfxPrefab);
        }
        Debug.Log("Load: " + transform.name);
    }

    public AudioCtrl GetMusicPrefab(Type musicPrefab)
    {
        foreach (var inList in _listMusicPrefabs)
        {
            if (musicPrefab.IsAssignableFrom(inList.GetType()))
            {
                return inList;
            }
        }
        return null;
    }

    public AudioCtrl GetSFXPrefab(Type sfxPrefab)
    {
        foreach (var inList in _listSFXPrefabs)
        {
            if (sfxPrefab.IsAssignableFrom(inList.GetType()))
            {
                return inList;
            }
        }
        return null;
    }

    //public AudioMusicCtrl GetAudioMusic()
    //{
    //    foreach (var inList in _listAudioMusicPrefabs)
    //    {
    //        if (inList.GetType() == typeof(AudioMusicGamePlay))
    //        {
    //            return inList;
    //        }
    //    }
    //    return null;
    //}

    //public AudioSFXCtrl GetAudioSFXTowerFire()
    //{
    //    foreach (var inList in _listAudioSFXPrefabs)
    //    {
    //        if (inList.GetType() == typeof(AudioSFXTowerFire))
    //        {
    //            return inList;
    //        }
    //    }
    //    return null;
    //}
}
