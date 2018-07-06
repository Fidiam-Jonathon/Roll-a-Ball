using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Text countText;
    public float speed;
    private int count;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        countText.text = SetCount(count);
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collider: ", other.gameObject);
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = SetCount(count);
        }
    }



    string SetCount(int count)
    {
        return "Score: " + count.ToString();
    }


}
