using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IkitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;


    private KitchenObject kitchenObject;


    public override void Interact(Player player) {
        if (kitchenObject == null) {
            Transform kitcheObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitcheObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else {
            kitchenObject.SetKitchenObjectParent(player);
        }




        //Debug.Log(kitcheObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }

    public Transform GetKitchenObjectFollowTransform() {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        this.kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
