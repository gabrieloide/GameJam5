using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyAbility : MonoBehaviour
{
    PlayerController playerController;
    public CapsuleCollider capsuleCollider;
    [SerializeField]LayerMask Hole;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        FamilyAbilities();
    }
    public void FamilyAbilities()
    {
        switch (GameManager.instance.familyState)
        {
            case FamilyState.Dad:
                if (GameManager.instance.familyState == FamilyState.Dad)
                {
                    playerController.anim.SetBool("Push", playerController.canMoveBox);
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (playerController.canMoveBox)
                        {
                            FindObjectOfType<BoxMovement>().MoveBox(transform);
                        }
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        playerController.canMoveBox = false;

                        GameObject newparent = GameObject.Find("Level 1-1");
                        FindObjectOfType<BoxMovement>().MoveBox(newparent.transform);
                    }
                }
                break;
            case FamilyState.Mom:
                if (GameManager.instance.familyState == FamilyState.Mom)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0) && playerController.takePot)
                    {
                        playerController.takePot = false;
                        playerController.anim.SetTrigger("PickUp");
                        FindObjectOfType<PotMovement>().Pot(transform, playerController.LastPosition + new Vector3(0, 1f, 0));
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse0) && !playerController.takePot)
                    {
                        
                        FindObjectOfType<PotMovement>().Pot(transform, playerController.LastPosition + new Vector3(1, 0f, 0));
                    }

                }
                break;
            case FamilyState.Son:
                if (GameManager.instance.familyState == FamilyState.Son)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (playerController.shoot)
                        {
                            playerController.anim.SetTrigger("Shoot");
                            float d = Input.GetAxisRaw("Vertical");
                            if (playerController.moveInput.x != 0f || d != 0)
                            {
                                GameObject b = Instantiate(playerController.Bullet, playerController.bulletCreation.position, Quaternion.identity);
                                Rigidbody rb = b.GetComponent<Rigidbody>();
                                rb.AddForce(new Vector3(playerController.moveInput.x, 0, Input.GetAxisRaw("Vertical")) * 5, ForceMode.Impulse);
                                Destroy(b, 2);
                            }
                        }
                        if (playerController.canPass)
                        {
                            capsuleCollider.height = 1;
                            capsuleCollider.center = new Vector3(0,-1.330288e-07f, 3.547435e-07f);
                            playerController.anim.SetBool("Crouch", true);
                        }
                        else
                        {
                            playerController.anim.SetBool("Crouch", false);
                        }
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        playerController.anim.SetBool("Crouch", false);
                        capsuleCollider.height = 3.522902f;
                        capsuleCollider.center = new Vector3(0, 1.261451f, 3.662338e-07f);
                    }
                }
                break;
        }

    }
}
