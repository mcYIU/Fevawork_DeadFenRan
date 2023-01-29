using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float maxSpeed = 10f;
	public float jumpForce = 30f;
	public float maxJumpSpeed = 13;
	public bool airControl = true;
	public bool allowDoubleJump = false;
	public LayerMask whatIsGround;
	public AudioClip jumpSound;
	private bool jump;

	const float groundedRadius = .2f;
	bool grounded;
	Animator anim;
	Rigidbody2D rb2d;
	AudioSource AS;
	bool facingRight = true;
	float move;
	bool startJump;
	bool doubleJumped;

	public Joystick joystick;

	void Start()
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		AS = GetComponent<AudioSource>();
		startJump = false;
		doubleJumped = false;
	}

	void Update()
	{
		if (Input.GetButtonDown("Jump"))
			startJump = true;
	}

	public void JumpButton()
    {
		startJump = true;
    }

	void FixedUpdate()
	{

		grounded = false;
		GroundCheck();
		anim.SetBool("ground", grounded);

		move = Input.GetAxis("Horizontal");
		move = joystick.Horizontal;

		if (grounded || airControl)
		{
			anim.SetFloat("speed", Mathf.Abs(move));
			rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
		}

		if (move > 0 && !facingRight)
			Flip();
		else if (move < 0 && facingRight)
			Flip();

		if ((grounded || (!doubleJumped && allowDoubleJump)) && startJump)
		{
			anim.SetBool("ground", false);
			rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			AS.PlayOneShot(jumpSound);
			startJump = false;

			if (!grounded && !doubleJumped)
			{
				doubleJumped = true;
				rb2d.velocity = new Vector2(move * maxSpeed, rb2d.velocity.y);
				anim.SetTrigger("jump");
			}
		}
		else
			startJump = false;

		rb2d.velocity = new Vector2(rb2d.velocity.x,
						Mathf.Min(rb2d.velocity.y, maxJumpSpeed));
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void GroundCheck()
    {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position,
								 groundedRadius, whatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
				doubleJumped = false;
			}
		}
	}

}
