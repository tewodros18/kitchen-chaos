using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private GameInput gameInput;
  

    private bool isWalking;
    private void Update() {
        HandleMovement();
    }

    private void HandleMovement() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y); // change vector2 to vector3


        float playerRadius = 0.7f;
        float playerHeight = 2f;
        float moveDistance = Time.deltaTime * moveSpeed;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove) {
            //can not move in the forward directions
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
            if (canMove) {
                moveDir = moveDirX;
            }
            else {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove) {
                    moveDir = moveDirZ;
                }
                else {
                    //can not move in any directoin
                }
            }
        }


        if (canMove) {
            transform.position += moveDir * moveDistance;
        }



        isWalking = moveDir != Vector3.zero;

        float roatationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * roatationSpeed);
    }

    public bool IsWalking() {
        return isWalking;
    }
}