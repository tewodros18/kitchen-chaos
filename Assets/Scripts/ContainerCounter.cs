using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IkitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player) {
            Transform kitcheObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitcheObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
    }

}
