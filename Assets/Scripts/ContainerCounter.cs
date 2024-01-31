using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IkitchenObjectParent
{

    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player) {
        if (!player.HasKitchenObject()){
            Transform kitcheObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitcheObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);


            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
            
    }

}
