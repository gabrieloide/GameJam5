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
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        if (playerController.canMoveBox)
                        {
                            FindObjectOfType<BoxMovement>().MoveBox(transform);
                        }
                    }
                    if (Input.GetKeyUp(KeyCode.J))
                    {
                        playerController.canMoveBox = false;

                        GameObject newparent = GameObject.Find("Level 1-1");
                        FindObjectOfType<BoxMovement>().MoveBox(newparent.transform);
                    }
                }
                break;
            case FamilyState.Mom:
                break;
            case FamilyState.Son:
                if (GameManager.instance.familyState == FamilyState.Son)
                {
                    if (Input.GetKeyDown(KeyCode.J))
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
                    if (Input.GetKeyUp(KeyCode.J))
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
