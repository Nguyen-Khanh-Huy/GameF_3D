using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnExitGame : PISMonoBehaviour
{
    [SerializeField] private Button _exitGame;

    private void Start()
    {
        _exitGame.onClick.AddListener(() => ActionButton());
    }

    protected override void LoadComponents()
    {
        if (_exitGame != null) return;
        _exitGame = GetComponent<Button>();
    }

    private void ActionButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
