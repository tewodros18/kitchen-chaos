using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnDeliverySuccess;
    public event EventHandler OnDeliveryFailure; 

    public static DeliveryManager Instance { get; private set; }

    [SerializeField] private RecipeListSO recipeListSO;

    private List<RecipeSO> waitingRecipeSOList;

    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipesMax = 4;
    private int successfulDeliveryAmount;

    private void Awake() {
        Instance = this;
        waitingRecipeSOList = new List<RecipeSO>();
        //Application.targetFrameRate = 300;
    }

    private void Update() {
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer <= 0f) {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if(waitingRecipeSOList.Count < waitingRecipesMax) {
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                waitingRecipeSOList.Add(waitingRecipeSO);

                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }

        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject) {
        for (int i = 0; i < waitingRecipeSOList.Count; i++){
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if(waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count) {
                //has the same number of ingeredients
                bool plateContentMatchesRecipe = true;
                foreach(KitchenObjectSO recipekitchenObjectSO in waitingRecipeSO.kitchenObjectSOList) {
                    //cycling through all ingredients in the recipe
                    bool ingredientFound = false;
                    foreach(KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList()) {
                        //cycling through all the ingredients in the plate
                        if(plateKitchenObjectSO == recipekitchenObjectSO) {
                            //ingredient found on plate
                            ingredientFound = true;
                            break;  
                        }
                    }
                    if (!ingredientFound) {
                        //this recipe was missing from palte
                        plateContentMatchesRecipe = false;
                    }
                }
                if (plateContentMatchesRecipe) {
                    //player delivered the correct recipe
                    successfulDeliveryAmount++;
                    waitingRecipeSOList.RemoveAt(i);
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnDeliverySuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
                
            }
        }
        //wrong delivery 
        OnDeliveryFailure?.Invoke(this, EventArgs.Empty);


    }


    public List<RecipeSO> GetWaitingRecipeSOList() {
        return waitingRecipeSOList;
    }

    public int GetSuccessfulDeliveryAmount() {
        return successfulDeliveryAmount;
    }
}
