using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitcheObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitcheObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter) {
        if(this.clearCounter != null) {
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = clearCounter;
        if (clearCounter.HasKitchenObject()) {
            Debug.LogError("Counter HAAS object");
        }
        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter() {
        return this.clearCounter;
    }

}
