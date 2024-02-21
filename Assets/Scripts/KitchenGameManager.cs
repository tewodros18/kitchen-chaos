using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{

    public static KitchenGameManager Instance { get; private set; }

    private enum State {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTime = 10f;

    private void Awake() {
        Instance = this; 
        state = State.WaitingToStart;
    }

    private void Update() {
        switch (state) {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if(waitingToStartTimer < 0f) {
                    state = State.CountdownToStart;
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f) {
                    state = State.GamePlaying;
                }
                break;
            case State.GamePlaying:
                gamePlayingTime -= Time.deltaTime;
                if (gamePlayingTime < 0f) {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                break;

        }
    }

    public bool IsGamePlaying() {
        return state == State.GamePlaying;
    }

}
