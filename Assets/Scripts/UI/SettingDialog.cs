using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingDialog : Dialog
{
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderSFX;
    [SerializeField] private Button _btnSetting;
    [SerializeField] private Button _btnClose;

    private void Start()
    {
        _sliderMusic.value = AudioManager.Ins.VolumeMusic;
        _sliderSFX.value = AudioManager.Ins.VolumeSFX;

        _sliderMusic.onValueChanged.AddListener(VolumeChangeMusic);
        _sliderSFX.onValueChanged.AddListener(VolumeChangeSFX);

        _btnSetting.onClick.AddListener(() => ShowHide());
        _btnClose.onClick.AddListener(() => ShowHide());
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        if(_sliderMusic != null && _sliderSFX != null && _btnSetting != null && _btnClose != null) return;
        _sliderMusic = GameObject.Find("PanelMusic").GetComponentInChildren<Slider>();
        _sliderSFX = GameObject.Find("PanelSFX").GetComponentInChildren<Slider>();
        _btnSetting = GameObject.Find("BtnSetting").GetComponent<Button>();
        _btnClose = GameObject.Find("BtnClose").GetComponent<Button>();
        Debug.Log("Load: " + transform.name);
    }

    private void VolumeChangeMusic(float volume)
    {
        AudioManager.Ins.VolumeMusic = volume;
        AudioManager.Ins.UpdateVolumeMusic(volume);
    }

    private void VolumeChangeSFX(float volume)
    {
        AudioManager.Ins.VolumeSFX = volume;
        AudioManager.Ins.UpdateVolumeSFX(volume);
    }

}
