using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitcheObjectSO;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitcheObjectSO;
    }

}
