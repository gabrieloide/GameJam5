using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum FamilyState
{
    Dad,
    Mom,
    Son
}
public class PlayerController : MonoBehaviour
{
    public FamilyState familyState = FamilyState.Dad;
    public int indexFamilyState;
    Dictionary<int,FamilyState> tableFamily = new Dictionary<int, FamilyState>();

    public Rigidbody theRB;
    public float moveSpeed, jumpForce;
    private Vector2 moveInput;
    public LayerMask whatIsGround;
    public Transform groundPoint;
    private bool isGrounded;
    public Animator anim;
    public SpriteRenderer show;
    public Sprite fowards, Backwards;
    private void Start()
    {
        tableFamily.Add(0, FamilyState.Dad);
        tableFamily.Add(1, FamilyState.Mom);
        tableFamily.Add(2, FamilyState.Son);
    }
    void Update()
    {
        ChangeFamilyMember();
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();

        anim.SetFloat("moveSpeed", theRB.velocity.magnitude);

        RaycastHit hit;
        bool Hit =Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround)? isGrounded = true: isGrounded = false;

        if(Input.GetButtonDown("Jump") && isGrounded)
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
    private void FixedUpdate()=> theRB.velocity = new Vector3(moveInput.x * moveSpeed, theRB.velocity.y, moveInput.y * moveSpeed);
    void ChangeFamilyMember()
    {
        if (true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                indexFamilyState++;
                familyState = tableFamily[indexFamilyState];
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                indexFamilyState--;
                familyState = tableFamily[indexFamilyState];
            }
        }
    }
}
