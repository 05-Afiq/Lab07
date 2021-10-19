using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Vector3 jump;
    public float jumpForce = 2.0f;
    public Rigidbody rb;
    public Text Score;
    public int Scorepoint;

    void Start()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
      if (transform.position.y <= -4)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trigger")
        {
            Scorepoint++;
            Score.text = "Score: " + Scorepoint;
        }    
    }
}
