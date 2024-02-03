using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] CuttingRecipeSO[] cuttingRecipeSOArray;
    

    public override void Interact(Player player) {
        if (!HasKitchenObject() && player.HasKitchenObject()) {
            if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())) {
                //accept kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            
        }
        else if (HasKitchenObject() && !player.HasKitchenObject()) {
            //counter has object and give to player
            GetKitchenObject().SetKitchenObjectParent(player);
        }
    }

    public override void InteractAlternate(Player player) {
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO())) {
            //there is a kitchen object on the cutting couter
            KitchenObjectSO outputKitchenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

            GetKitchenObject().DestroySelf();

            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitcheObjetSO) {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray) {
            if(cuttingRecipeSO.input == inputKitcheObjetSO) {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitcheObjetSO) {
        foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray) {
            if(cuttingRecipeSO.input == inputKitcheObjetSO) {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }

}
