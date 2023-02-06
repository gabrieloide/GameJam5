using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyAbility : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField]LayerMask Hole;
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        FamilyAbilities();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
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
                if (Input.GetKeyDown(KeyCode.J) && GameManager.instance.familyState == FamilyState.Son)
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
                break;
        }

    }
}
