using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;
    private Vector2 moveInput;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;
    public Animator anim;
    public SpriteRenderer show;
    public Sprite fowards, Backwards;
    public Vector3 LastPosition;
    public bool canMoveBox;
    public GameObject Bullet;
    public Transform bulletCreation;
    bool canPass;

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        LastPosition = transform.position;
        anim.SetFloat("moveSpeed", theRB.velocity.magnitude);

        RaycastHit hit;
        bool Hit =Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround)? isGrounded = true: isGrounded = false;
        FamilyAbilities();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
        }

        anim.SetBool("onGround", isGrounded);
        Vector3 n = moveInput.x < -0.1f  ? transform.localScale = new Vector3(-1, 1, 1) : transform.localScale = new Vector3(1, 1, 1);

        if (moveInput.y > 0.1)
            show.sprite = Backwards;
        else
            show.sprite = fowards;
    }
    private void FixedUpdate()
    {
        theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);
    }
    void FamilyAbilities()
    {
        switch (GameManager.instance.familyState)
        {
            case FamilyState.Dad:
                if (GameManager.instance.familyState == FamilyState.Dad)
                {
                    if (Input.GetKeyDown(KeyCode.J))
                    {
                        if (canMoveBox)
                        {
                            FindObjectOfType<BoxMovement>().MoveBox(transform);
                        }
                    }
                    if (Input.GetKeyUp(KeyCode.J))
                    {
                        canMoveBox = false;
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
                    anim.SetTrigger("Shoot");
                    float d = Input.GetAxisRaw("Vertical");
                    if (moveInput.x != 0f || d != 0)
                    {
                        GameObject b = Instantiate(Bullet, bulletCreation.position, Quaternion.identity);
                        Rigidbody rb = b.GetComponent<Rigidbody>();
                        rb.AddForce(new Vector3(moveInput.x, 0, Input.GetAxisRaw("Vertical")) * 5, ForceMode.Impulse);
                        Destroy(b, 2);
                    }
                }
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Activator"))
        {
            canMoveBox = true;
        }
        if (collision.gameObject.CompareTag("Hole"))
        {
            canPass = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Activator"))
        {
            canMoveBox = false;
        }
        if (collision.gameObject.CompareTag("Hole"))
        {
            canPass = false;
        }
    }
}
