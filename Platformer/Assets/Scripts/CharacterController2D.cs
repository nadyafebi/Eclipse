using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Handles the core logic of character movement.
/// </summary>
public class CharacterController2D : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float m_MovementMultiplier = 10f;
    [SerializeField][Range(0, .3f)] private float m_MovementSmoothing = .05f;
    [SerializeField] private LayerMask m_GroundLayer = 0;
    [SerializeField] private Transform m_GroundCheck = null;

    [Header("Jumping")]
    [SerializeField] private bool m_AirControl = false;
    [SerializeField] private float m_JumpForce = 800f;
    [SerializeField] public int m_AirJumps = 0;

    [Header("Events")]
    public UnityEvent OnJumpEvent;
    public UnityEvent OnFallEvent;
    public UnityEvent OnLandEvent;

    private bool m_Grounded;
    private float m_speedY;
    private bool m_FacingRight = true;
    private int m_AirJumpsLeft;
    private Vector2 m_Velocity = Vector2.zero;

    private Rigidbody2D m_RigidBody2D;

    void Awake()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = Physics2D.Linecast(transform.position, m_GroundCheck.position, m_GroundLayer);
        if (m_Grounded)
        {
            m_AirJumpsLeft = m_AirJumps;
            if (!wasGrounded)
            {
                OnLandEvent.Invoke();
            }
        }
    }

    void LateUpdate()
    {
        float speedY = m_RigidBody2D.velocity.y;
        if (m_speedY >= 0 && speedY < 0)
        {
            OnFallEvent.Invoke();
        }
        m_speedY = speedY;
    }

    /// <summary>
    /// Moves the character left or right and if they should jump or not.
    /// </summary>
    /// <param name="move">The movement distance. If negative, the character moves to the left.</param>
    /// <param name="jump">Whether the character should jump or not.</param>
    public void Move(float move, bool jump)
    {
        if (m_Grounded || m_AirControl)
        {
            Vector2 targetVelocity = new Vector2(move * m_MovementMultiplier, m_RigidBody2D.velocity.y);
            m_RigidBody2D.velocity = Vector2.SmoothDamp(m_RigidBody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            if ((move > 0 && !m_FacingRight) || (move < 0 && m_FacingRight))
            {
                Flip();
            }
        }

        if (m_Grounded && jump)
        {
            Jump(m_JumpForce);
        }
        else if (jump && m_AirJumpsLeft > 0)
        {
            Jump(m_JumpForce);
            m_AirJumpsLeft--;
        }
    }

    /// <summary>
    /// Makes the character jump.
    /// </summary>
    /// <param name="jumpForce">The force to be applied for the jump.</param>
    public void Jump(float jumpForce)
    {
        m_Grounded = false;
        m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, jumpForce));
        OnJumpEvent.Invoke();

        // Resets gravity for the next jump so it doesn't kill the jump force.
        if (m_AirJumpsLeft > 0)
        {
            m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 0);
        }
    }

    /// <summary>
    /// Flips the character's sprite from whichever direction they are currently facing.
    /// </summary>
    public void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
