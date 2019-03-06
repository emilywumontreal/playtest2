using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject manager;
    private Rigidbody rbody;
    float speed =100f;
    float rotationSpeed = 10f;
   // float speedright = 0.2f;
    private void Start()
    {
        manager = GameObject.Find("GameObject");
        rbody = GetComponent<Rigidbody>();
    }

 

    private void FixedUpdate()
    {

        // transform.Translate(Input.GetAxis("Vertical") *speed*Time.deltaTime,0f, Input.GetAxisRaw("Horizontal") * -speed * Time.deltaTime);
        rbody.AddForce(Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f, Input.GetAxisRaw("Horizontal") * -speed * Time.deltaTime);
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
       
       // rotation *= Time.deltaTime;
      // transform.Rotate(0,rotation,0);
    }


    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Pattern")
        {
            System.String traceName = collision.gameObject.name;
            int traceId = int.Parse(traceName.Substring(traceName.Length - 2));
            manager.GetComponent<generateMatrix>().patternTarget.Add(traceId);

            collision.gameObject.transform.position = new Vector3(0, -2, 0);

            //Debug.Log(manager.GetComponent<generateMatrix>().patternTarget)
            Debug.Log(traceId);

        }

        if (collision.gameObject.tag == "key")
        {
            gameOver();

            //Debug.Log(manager.GetComponent<generateMatrix>().patternTarget)

        }
    }

    public void gameOver() {

        if (manager.GetComponent<generateMatrix>().checkMatch(manager.GetComponent<generateMatrix>().patternSource, manager.GetComponent<generateMatrix>().patternTarget))
        {
            // manager.GetComponent<Pipe>.
            //destroy the pipe
            GameObject pip = GameObject.Find("Pipe");
            Destroy(pip);

            Debug.Log("escape done");
        } 
        else
        {
            //do nothing , reset the game
            Debug.Log("try again");
           
        }

    }
}

