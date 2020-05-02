using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{

    Rigidbody RocketRB;
    AudioSource rocketthurst;
    [SerializeField] float upspeed = 1f;
    [SerializeField] float rspeed = 1f;
    /*bool isPlaying;
    bool toggleChange;*/

        enum State {Alive, Dying, Trascending}
    State state = State.Alive;

    // Start is called before the first frame update
    void Start()
    {
        RocketRB = GetComponent<Rigidbody>();
        rocketthurst = GetComponent<AudioSource>();
       /* isPlaying = false;
        toggleChange = true;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Alive)
        {

            Thrust();
            Rotate();
        }

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        print("Collided");

        if (state != State.Alive)
        {

            return;
        }



        switch (collision.gameObject.tag)
        {

            case "Friendly":
                Debug.Log("Ok");
                break;
            case "Finish":
                Debug.Log("NextLevel");
                state = State.Trascending;
                Invoke("LoadNextScene", 1f);
                break;
            default:
               Invoke("DyingState", 1f);
                state = State.Dying;
                Debug.Log("Dead");
                break;
        }
    }

    private  void DyingState()
    {
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
        
    }

    private  void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            float thrustspeed = upspeed * Time.deltaTime;
            //isPlaying = true;
            RocketRB.AddRelativeForce(transform.up * thrustspeed);
            //audioManager();
            if (!rocketthurst.isPlaying)
            {
                rocketthurst.Play();

            }


        }
        else
        {
            //isPlaying = false;
            // audioManager();
            rocketthurst.Stop();
        }
    }

    private void Rotate()
    {
        RocketRB.freezeRotation = true;

        float rotationSpeed = rspeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) /*&& Input.GetKey(KeyCode.Space)*/)
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
           // print("Rotating Lef");
        }
        else if (Input.GetKey(KeyCode.D) /*&& Input.GetKey(KeyCode.Space) */)
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
            //print("Rotating Right");

        }

        RocketRB.freezeRotation = false;

    }



    /* void audioManager()
     {
         if (isPlaying && toggleChange)
         {
             print("audio");
             rocketthurst.Play();
             toggleChange = false;

         }
        else if (!toggleChange && !isPlaying)
         {
             toggleChange = true;
             rocketthurst.Stop();
         }

     }*/

} 
 