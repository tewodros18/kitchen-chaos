using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IkitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update() {
        if(testing && Input.GetKeyDown(KeyCode.T)){
            if(kitchenObject != null) {
                kitchenObject.SetKitchenObjectParent(secondClearCounter);
            }

        }
    }

    public void Interact(Player player) {
        if(kitchenObject == null) {
            Transform kitcheObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitcheObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else {
            kitchenObject.SetKitchenObjectParent(player);
        }

        
        

        //Debug.Log(kitcheObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }

    public Transform GetKitchenObjectFollowTransform(){
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
