using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text winText;
    public Text timerText;
    private float startTime;
    public GameObject Obstacle;
    private Vector3 startPosition;
    private bool finished = false;
    public string seconds;
    float endTimer;
    public bool isTimerOn = true;

    private void Start()

    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        startTime = Time.time;
        startPosition = transform.position;
    }

    public void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f2");

        if (isTimerOn)
        {
            timerText.text = minutes + ":" + seconds;
        }
        if (endTimer >= 30)
        {
           
            isTimerOn = false;
        }
        

        endTimer = (t % 60);
       

       
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Ups"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
            
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {

            transform.position = startPosition;
          

        }
        else if (other.gameObject.CompareTag("End Goal"))
        {

            Finnish();


        }
    }

    public void Finnish()


    {
        if (count == 7 && isTimerOn == true)
        {
            winText.text = "You Win!";  //finished = true;
        }
        if(count != 7 && isTimerOn == true)
        {
            winText.text = "Level failed!";
        }
        else if (count == 7 && isTimerOn == false)
        {
            winText.text = "Level failed!"; // finished = false;
        }

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
       
    }
}
