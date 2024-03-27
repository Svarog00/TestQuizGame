using Assets._Code.Tasks;
using Grid;
using Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EndGameScreen : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private GameObject _replayButton;
    [SerializeField] private Image _loadingScreen;
    [SerializeField] private Image _fader;

    [Space]
    [SerializeField] private DifficultyLevelSwapper _levelsController;
    [SerializeField] private GridView _gridView;
    [SerializeField] private GridGenerator _gridGenerator;

    private const float AppearDuration = 0.4f;
    private const float FaderDisppearDuration = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _levelsController.OnFinalLevelReached += ShowScreen;
        _gridGenerator.OnGridGenerated += () =>
            {
                FadeElement(_loadingScreen, 0f, FaderDisppearDuration);
            };

        _replayButton.SetActive(false);
        FadeElement(_fader, 0f, FaderDisppearDuration);
        FadeElement(_loadingScreen, 0f, FaderDisppearDuration);
    }

    private void ShowScreen()
    {
        _gridView.SetGridObjectsClickable(false);
        _replayButton.SetActive(true);

        FadeElement(_fader, 1f, AppearDuration);
    }

    public void RestartGame()
    {
        FadeElement(_fader, 0f, FaderDisppearDuration);
        FadeElement(_loadingScreen, 1f, AppearDuration);

        _replayButton.SetActive(false);

        _levelsController.StartGame();
        //_gridView.PlayStartAnimation();
    }

    private void FadeElement(Graphic target, float alpha, float duration)
    {
        target.CrossFadeAlpha(alpha, duration, false);
    }
}
