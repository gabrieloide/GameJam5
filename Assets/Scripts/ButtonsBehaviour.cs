using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsBehaviour : MonoBehaviour
{
    Animator animator;
    ButtonManager buttonManager;
    public bool isPushing;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        buttonManager = FindObjectOfType<ButtonManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Activator"))
        {
            isPushing = true;
            buttonManager.buttonCountPressed++;
            animator.SetBool("Pushing", isPushing);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Activator"))
        {
            buttonManager.buttonCountPressed--;
            isPushing = false;
            animator.SetBool("Pushing", isPushing);
        }
    }
}
