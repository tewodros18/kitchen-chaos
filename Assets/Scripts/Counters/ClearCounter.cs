using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            if (player.HasKitchenObject()) {
                //accept kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else {
                //player is not carrying item
            }

            
        }
        else {
            if (player.HasKitchenObject()) {
                //player is carrying something
                if(player.GetKitchenObject() is PlateKitchenObject) {
                    PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;
                    plateKitchenObject.AddIngredient(GetKitchenObject().GetKitchenObjectSO());
                    GetKitchenObject().DestroySelf();
                }
            }
            else {
                //counter has object and give to player
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
        
    }

   


}
