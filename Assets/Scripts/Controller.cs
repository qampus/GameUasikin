using UnityEngine;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{

    bool isJump = true;
    bool isDead = false;
    int idMove = 0;
    string currentScene;
    Animator anim;
    // Use this for initialization
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < -7)
        {
            SceneManager.LoadScene(currentScene);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
            anim.Play("LeftAni");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
            anim.Play("RightAni");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Idle();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Idle();
        }
        Move();
        Dead();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        if (isJump)
        {
            isJump = false;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Kondisi ketika menyentuh tanah
        isJump = true;
    }
    public void MoveRight()
    {
        idMove = 1;
    }
    public void MoveLeft()
    {
        idMove = 2;
       
    }
    private void Move()
    {
        if (idMove == 1 && !isDead)
        {
            // Kondisi ketika bergerak ke kekanan
            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
            //transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (idMove == 2 && !isDead)
        {
            // Kondisi ketika bergerak ke kiri
            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
            //transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    public void Jump()
    {
        if (!isJump)
        {
            // Kondisi ketika Loncat           
            if (GetComponent<Rigidbody2D>().velocity.y < 1)
                gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400f);
        }
    }
    public void Idle()
    {
        if (!isJump)
        {
            anim.Play("IdleAnim");
        }
        idMove = 0;

    }
    private void Dead()
    {
        if (!isDead)
        {
            if (transform.position.y < -10f)
            {
                isDead = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals("Coin"))
        {
            Data.score += 15;
            Destroy(collision.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(this);
            SceneManager.LoadScene(currentScene);
        }
    }
}