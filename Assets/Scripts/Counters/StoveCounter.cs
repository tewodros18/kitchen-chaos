using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{

    private enum State {
        Idle,
        Frying,
        Fried,
        Burned,
    }

    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;

    private float fryingTimer;
    private FryingRecipeSO fryingRecipeSO;
    private State state;

    private void Start() {
        state = State.Idle;
    }

    private void Update() {
        if (HasKitchenObject()) {
            switch (state) {
                case State.Idle:
                    break;
                case State.Frying:
                    fryingTimer += Time.deltaTime;
                    if (fryingTimer > fryingRecipeSO.fryingTimerMax) {
                        //Fried
                        GetKitchenObject().DestroySelf();

                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
                        state = State.Fried;
                    }
                    break;
                case State.Fried:
                    break;
                case State.Burned:
                    break;
            }
        }
    }

    public override void Interact(Player player) {
        if (!HasKitchenObject() && player.HasKitchenObject()) {
            if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) {
                //accept kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);

                fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                state = State.Frying;
                fryingTimer = 0f;

            }

        }
        else if (HasKitchenObject() && !player.HasKitchenObject()) {
            //counter has object and give to player
            GetKitchenObject().SetKitchenObjectParent(player);
        }
    }


    private bool HasRecipeWithInput(KitchenObjectSO inputKitcheObjetSO) {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitcheObjetSO);
        return fryingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitcheObjetSO) {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitcheObjetSO);
        if (fryingRecipeSO != null) {
            return fryingRecipeSO.output;
        }
        else {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjetSO) {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray) {
            if (fryingRecipeSO.input == inputKitchenObjetSO) {
                return fryingRecipeSO;
            }
        }
        return null;
    }
}
