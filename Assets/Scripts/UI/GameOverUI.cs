using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI receipesDeliveredText;
    [SerializeField] private Button mainMenuButton;

    private void Awake() {
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }

    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenManage_OnStateChanged;
        Hide();
    }



    private void KitchenManage_OnStateChanged(object sender, System.EventArgs e) {
        if (KitchenGameManager.Instance.IsGameOver()) {
            Show();
            receipesDeliveredText.text = Mathf.Ceil(DeliveryManager.Instance.GetSuccessfulDeliveryAmount()).ToString();

        }
        else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}
