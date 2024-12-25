using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialog : PISMonoBehaviour
{
    [SerializeField] protected Transform _showHide;
    private bool isShow;

    private void OnEnable()
    {
        Hide();
    }

    protected override void LoadComponents()
    {
        if (_showHide != null) return;
        _showHide = transform.Find("ShowHide");
        Debug.Log("Load: " + transform.name);
    }

    public void ShowHide()
    {
        if (isShow) Show();
        else Hide();
    }

    private void Show()
    {
        isShow = false;
        _showHide.gameObject.SetActive(true);
    }

    private void Hide()
    {
        isShow = true;
        _showHide.gameObject.SetActive(false);
    }
}
