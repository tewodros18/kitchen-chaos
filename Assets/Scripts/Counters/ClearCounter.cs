using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    

    public override void Interact(Player player) {
        if (!HasKitchenObject() && player.HasKitchenObject()) {
            //accept kitchen object
            player.GetKitchenObject().SetKitchenObjectParent(this);
        }
        else if(HasKitchenObject() && !player.HasKitchenObject()) {
            //counter has object and give to player
            GetKitchenObject().SetKitchenObjectParent(player);
        }
        else {
            //can niether give or take kitchen object
            Debug.Log("can neither give or receive");
        }
    }

   


}
