using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitcheObject;
    [SerializeField] private Transform iconeTemplate;

    private void Awake() {
        iconeTemplate.gameObject.SetActive(false);
    }

    private void Start() {
        plateKitcheObject.OnIngredientAdded += PlateKitcheObject_OnIngredientAdded;
    }

    private void PlateKitcheObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e) {
        UpdateVisual();
    }

    private void UpdateVisual() {
        foreach(Transform child in transform) {
            if (child == iconeTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach(KitchenObjectSO kitchenObjectSO in plateKitcheObject.GetKitchenObjectSOList()) {
            Transform iconTransform = Instantiate(iconeTemplate, transform);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<PlateIconsSingleUI>().SetKitchenObjectSO(kitchenObjectSO); 


        }
    }
}
