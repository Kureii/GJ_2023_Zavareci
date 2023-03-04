using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Char_Controller : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D bc;
    public bool Connected { get; set; }

    [SerializeField] float speed = 10f;
    [SerializeField] private Component next_Level;
    public GameObject secondHalfHorizontal;
    public GameObject secondHalfVertical;
    public Sprite horizontalSplitSprite;
    public Sprite verticalSplitSprite;
    public Sprite defaultSprite;
    SpriteRenderer sp;

    Vector2 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>(); 
        Connected = true;
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Mouse0) && Connected) 
        {
            VerticalSplit();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && Connected)
        {
            HorizontalSplit();
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = (movementDirection * speed * Time.deltaTime);
    }

    void VerticalSplit()
    {
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x/2, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        sp.sprite = verticalSplitSprite;
        rb.transform.Translate(transform.localScale.x / 2f , 0,0);
        bc.size = new Vector2(bc.size.x/2, bc.size.y);
        Instantiate(secondHalfVertical, gameObject.transform.position - new Vector3(transform.localScale.x + 0.1f, 0, 0),gameObject.transform.rotation);
        next_Level.SendMessage("InvertCharacterConnected");
        Connected = false;
    }

    void HorizontalSplit()
    {
        //gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y / 2, gameObject.transform.localScale.z);
        sp.sprite = horizontalSplitSprite;
        rb.transform.Translate(0, transform.localScale.y / 2f, 0);
        bc.size = new Vector2(bc.size.x, bc.size.y / 2);
        Instantiate(secondHalfHorizontal, gameObject.transform.position - new Vector3(0, gameObject.transform.localScale.y, 0), gameObject.transform.rotation);
        next_Level.SendMessage("InvertCharacterConnected");
        Connected = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "SecondHalfHorizontal(Clone)")
        {
           Destroy(collision.gameObject);
            next_Level.SendMessage("InvertCharacterConnected");
            Connected = true;
            sp.sprite = defaultSprite;
            bc.size = new Vector2(bc.size.x, bc.size.y * 2);
        }
        else if(collision.collider.name == "SecondHalfVertical(Clone)")
        {
            Destroy(collision.gameObject);
            next_Level.SendMessage("InvertCharacterConnected");
            Connected = true;
            sp.sprite = defaultSprite;
            bc.size = new Vector2(bc.size.x * 2, bc.size.y);
        }
    }
}
