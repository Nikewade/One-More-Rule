using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D collider;
    [SerializeField] public Rigidbody2D bullet;
    [SerializeField] public Transform bulletPosition;
    [SerializeField] public float bulletSpeed = 2000;
    [SerializeField] public float shootRate = 0.7f;
    [SerializeField] Animator animator;
    [SerializeField] Transform groundChecker;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioSource shootSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] float checkGroundRadius = 0.1f;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] float speed = 20f;

    Vector2 startingSize;
    Vector2 startingOffset;
    [SerializeField] public Vector2 crouchingSize;
    public bool isGrounded = false;
    public bool isCrouching = false;
    bool isFacingRight = true;
    public bool canShoot = true;
    public bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = GetComponent<Sprite>();
        collider = GetComponent<CapsuleCollider2D>();

        startingSize = collider.size;
        startingOffset = collider.offset;
    }

    private void Update()
    {
        CheckIfGrounded();
        Crouch();
        Shoot();
        if (isCrouching) { return; };
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(isCrouching)
        {
            return;
        }

        float x = Input.GetAxisRaw("Horizontal");
        if(x > 0 || x < 0)
            animator.SetBool("isWalking", true);
           else
            animator.SetBool("isWalking", false);


        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        if(x < 0 && isFacingRight)
        {
            Rotate();
        }else if(!isFacingRight && x > 0)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.y, jumpForce);
                isJumping = true;
                shootSource.PlayOneShot(jumpSound);
            }
        }
    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundChecker.position, checkGroundRadius, groundLayer);

        if (collider != null)
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJumping = false;
        }
        else
        {
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }


    void Crouch()
    {
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            if (isGrounded && !isCrouching)
            {
                rb.velocity = Vector2.zero;
                Vector2 newOffset = new Vector2(0, (startingSize.y - crouchingSize.y) / 2);
                collider.size = crouchingSize;
                isCrouching = !isCrouching;
                animator.SetBool("isCrouching", true);
                animator.SetBool("isWalking", false);
                collider.offset = collider.offset - newOffset;
            }
        }

        if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {

            if(isCrouching)
            {
                collider.size = startingSize;
                isCrouching = !isCrouching;
                animator.SetBool("isCrouching", false);
                collider.offset = startingOffset;
            }
        }
    }


    void Shoot()
    {
        if(Input.GetKey(KeyCode.LeftShift) && canShoot || Input.GetKey(KeyCode.RightShift) && canShoot)
        {
            Vector3 newBulletPosition = bulletPosition.position;
            if(isCrouching)
            {
                newBulletPosition.y -= 0.7f;
            }
            canShoot = false;
            var firedBullet = Instantiate(bullet, newBulletPosition, bulletPosition.rotation);
            firedBullet.AddForce(bulletPosition.right * bulletSpeed);
            shootSource.PlayOneShot(shootSound);
            StartCoroutine("FireRate");
        }
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(shootRate);
        canShoot = true;
    }

}
