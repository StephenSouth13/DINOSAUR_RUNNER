using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;         // Tốc độ di chuyển ngang
    [SerializeField] private float jumpForce = 15f;        // Lực nhảy
    [SerializeField] private LayerMask groundLayer;        // Layer mặt đất để kiểm tra va chạm
    [SerializeField] private Transform groundCheck;        // Vị trí kiểm tra mặt đất

    private bool isGrounded;                               // Kiểm tra nhân vật có đang đứng trên mặt đất không
    private Animator animator;                             // Animator để điều khiển animation
    private Rigidbody2D rb;                                // Rigidbody2D để điều khiển vật lý

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();                  // Lấy Rigidbody2D từ GameObject
        animator = GetComponent<Animator>();               // Lấy Animator từ GameObject
    }

    void Update()
    {
        HandleMovement();                                  // Xử lý di chuyển ngang
        HandleJump();                                      // Xử lý nhảy
        UpdateAnimation();                                 // Cập nhật animation
    }

    private void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");     // Nhận input từ bàn phím (A/D hoặc ←/→)
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y); // Di chuyển ngang

        // Lật hướng nhân vật theo chiều di chuyển
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void HandleJump()
    {
        // Kiểm tra có đang đứng trên mặt đất không
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Nếu nhấn nút nhảy và đang đứng trên mặt đất thì nhảy
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            Debug.Log("Jump!");
        }
    }

    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;  // Kiểm tra có đang chạy không
        bool isJumping = !isGrounded;                      // Kiểm tra có đang nhảy không

        animator.SetBool("isRunning", isRunning);          // Gửi trạng thái chạy cho Animator
        animator.SetBool("isJumping", isJumping);          // Gửi trạng thái nhảy cho Animator
    }

    // Vẽ gizmo để kiểm tra vùng va chạm mặt đất trong Scene
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
        }
    }
}
