using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public Rigidbody theRB;
    public float moveSpeed, jumpForce;
    public Vector2 moveInput;
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
    public bool canPass;
    public AK.Wwise.Event Jump;
    public bool shoot;

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        LastPosition = transform.position;
        anim.SetFloat("moveSpeed", theRB.velocity.magnitude);

        RaycastHit hit;
        bool Hit =Physics.Raycast(groundPoint.position, Vector3.down, out hit, .3f, whatIsGround)? isGrounded = true: isGrounded = false;

        //Cambio de Familiar

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            theRB.velocity += new Vector3(0f, jumpForce, 0f);
            Jump.Post(gameObject);
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
        if (GameManager.instance.MoveCamera)
        {
            FindObjectOfType<CameraMovement>().CameraM(transform);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            shoot = false;
            canPass = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            shoot = true;
            canPass = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Activator"))
        {
            canMoveBox = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Activator"))
        {
            canMoveBox = false;
        }
    }
}
