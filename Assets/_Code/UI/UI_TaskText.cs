using Assets._Code.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class UI_TaskText : MonoBehaviour
{
    [SerializeField] private TaskManager _taskManager;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _text.CrossFadeAlpha(0, 0f, false);
    }

    private void Start()
    {
        _taskManager.NewTaskGenerated += UpdateText;

    }

    private void UpdateText(string answer)
    {
        _text.CrossFadeAlpha(1, 0.3f, false);
        _text.text = "Find " + answer;
    }
}
