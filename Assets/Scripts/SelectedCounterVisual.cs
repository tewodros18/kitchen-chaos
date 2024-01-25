using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject visualGameObject; 

    private void Start() {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e) {
        //if the current selected counter matches the one that this script is on then toggle visual
        if(e.selectedCounter == clearCounter) {
            show();
        }
        else {
            hide();
        }
    }

    private void show() {
        visualGameObject.SetActive(true);

    }

    private void hide() {
        visualGameObject.SetActive(false);

    }


}
