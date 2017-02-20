using System.Threading;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Timer abillityTimer;
    private Animator anim;
    public bool Grounded;
    public bool HasAbility;
    public float jumpForce = 350;
    public float maxSpeed = 3;
    public float movingSpeed = 150;
    private Rigidbody2D rb;
    private float timeLeft = 300.0f;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("grounded", Grounded);
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("P1_Horizontal")));
        // anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("P2_Horizontal")));


        if (gameObject.tag == "playerOne")
        {
            if (Input.GetAxis("P1_Horizontal") < -0.1F)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (Input.GetAxis("P1_Horizontal") > 0.1F)
                transform.localScale = new Vector3(1, 1, 1);

            if (Input.GetKeyDown(KeyCode.W) && Grounded)
                rb.AddForce(Vector2.up * jumpForce);
        }

        //if (gameObject.tag == "playerTwo")
        //{
        //    if (Input.GetAxis("P2_Horizontal") < -0.1F)
        //    {
        //        transform.localScale = new Vector3(-1, 1, 1);
        //    }
        //    else if (Input.GetAxis("P2_Horizontal") > 0.1F)
        //    {
        //        transform.localScale = new Vector3(1, 1, 1);
        //    }

        //    if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        //    {
        //        rb.AddForce(Vector2.up * jumpForce);
        //    }
        //}
    }

    private void FixedUpdate()
    {
        var h1 = Input.GetAxis("P1_Horizontal");
        // float h2 = Input.GetAxis("P1_Horizontal");

        if (gameObject.tag == "playerOne")
        {
            rb.AddForce(Vector2.right * movingSpeed * h1);
            Debug.Log("P1: Moving");
        }

        //if (gameObject.tag == "playerTwo")
        //{
        //    if (Input.GetKey(KeyCode.LeftArrow))
        //    {
        //        Debug.Log("P2: Moveing Left");
        //        rb.AddForce((Vector2.right * movingSpeed) * h2);
        //    }
        //    else if (Input.GetKey(KeyCode.D))
        //    {
        //        Debug.Log("P2: Moveing Right");
        //        rb.AddForce((Vector2.right * movingSpeed) * h2);
        //    }
        //}
        //// moving player
        //rb.AddForce((Vector2.right * movingSpeed) * h1);

        //Speed limiting
        if (rb.velocity.x > maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        else if (rb.velocity.x < -maxSpeed)
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "speedUpItem")
        {
            Debug.Log("Collision with speedUpItem");
            Destroy(coll.gameObject);
            {
                timeLeft -= Time.deltaTime;
                Debug.Log("Countdown Started");
                while (HasAbility == false)
                {
                    maxSpeed = (float)(maxSpeed * 1.5);
                    jumpForce = (float)(jumpForce * 1.5);
                    HasAbility = true;
                }
                if (timeLeft <= 0)
                {
                    HasAbility = false;
                }

                Debug.Log("Countdown Ended");
            }
        }
    }
}