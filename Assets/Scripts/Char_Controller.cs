using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    Animator animator;
    public bool Connected { get; set; }
    public bool MouseOnMenu { get; set; }
    private bool splitTimer;

    [SerializeField] float speed = 10f;
    [SerializeField] private Component next_Level;
    public GameObject secondHalfHorizontal;
    public GameObject secondHalfVertical;
    public Sprite horizontalSplitSprite;
    public Sprite verticalSplitSprite;
    public Sprite defaultSprite;
    SpriteRenderer sp;
    [SerializeField] private AudioSource movementSound;
    [SerializeField] private AudioSource horizontalSplitSound;
    [SerializeField] private AudioSource verticalSplitSound;
    [SerializeField] private AudioSource mergingSound;

    Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        splitTimer = true;
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>(); 
        Connected = true;
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Mouse0) && Connected && splitTimer && !MouseOnMenu) 
        {
            animator.SetBool("verticalSplit", true);
            splitTimer = false;
            Invoke("VerticalSplit", 0.24f);
            Invoke("ResetTimer", 0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && Connected && splitTimer && !MouseOnMenu)
        {
            animator.SetBool("horizontalSplit", true);
            splitTimer = false;
            Invoke("HorizontalSplit",0.24f);
            Invoke("ResetTimer", 0.5f);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = (movementDirection * speed * Time.deltaTime);
        if(rb.velocity != Vector2.zero)
        {
            movementSound.mute = false;
        }
        else
        {
            movementSound.mute = true;
        }
    }

    void VerticalSplit()
    {
        animator.SetBool("reconnected", false);
        animator.SetBool("verticalSplit", false);
        animator.SetBool("afterVerticalSplit", true);
        sp.sprite = verticalSplitSprite;
        rb.transform.Translate(transform.localScale.x / 2f , 0,0);
        bc.size = new Vector2(bc.size.x/2, bc.size.y);
        Instantiate(secondHalfVertical, gameObject.transform.position - new Vector3(transform.localScale.x + 0.1f, 0, 0), gameObject.transform.rotation);
        SecondHalfController sc = GameObject.Find("SecondHalfVertical(Clone)").GetComponent<SecondHalfController>();
        sc.Speed = speed;
        next_Level.SendMessage("InvertCharacterConnected");
        Connected = false;
        verticalSplitSound.Play();
    }

    void HorizontalSplit()
    {
        animator.SetBool("reconnected", false);
        animator.SetBool("horizontalSplit", false);
        animator.SetBool("afterHorizontalSplit", true);
        sp.sprite = horizontalSplitSprite;
        rb.transform.Translate(0, transform.localScale.y / 2f, 0);
        bc.size = new Vector2(bc.size.x, bc.size.y / 2);
        Instantiate(secondHalfHorizontal, gameObject.transform.position - new Vector3(0, gameObject.transform.localScale.y, 0), gameObject.transform.rotation);
        SecondHalfController sc = GameObject.Find("SecondHalfHorizontal(Clone)").GetComponent<SecondHalfController>();
        sc.Speed = speed;
        next_Level.SendMessage("InvertCharacterConnected");
        Connected = false;
        horizontalSplitSound.Play();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Reconnect(collision);
    }

    void Reconnect(Collision2D collision)
    {
        if (collision.collider.name == "SecondHalfHorizontal(Clone)")
        {
            animator.SetBool("afterHorizontalSplit", false);
            animator.SetBool("reconnected", true);
            Destroy(collision.gameObject);
            next_Level.SendMessage("InvertCharacterConnected");
            Connected = true;
            sp.sprite = defaultSprite;
            bc.size = new Vector2(bc.size.x, bc.size.y * 2);
            mergingSound.Play();
            
        }
        else if (collision.collider.name == "SecondHalfVertical(Clone)")
        {
            animator.SetBool("afterVerticalSplit", false);
            animator.SetBool("reconnected", true);
            Destroy(collision.gameObject);
            next_Level.SendMessage("InvertCharacterConnected");
            Connected = true;
            sp.sprite = defaultSprite;
            bc.size = new Vector2(bc.size.x * 2, bc.size.y);
            mergingSound.Play();
        }
    }

    void ResetTimer()
    {
        splitTimer = true;
    }
}