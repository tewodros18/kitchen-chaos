using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InGamePauseButtonUI : MonoBehaviour
{
    [SerializeField] private Button inGamePauseButton;

    private void Awake() {
        inGamePauseButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();
        });
    }
}
