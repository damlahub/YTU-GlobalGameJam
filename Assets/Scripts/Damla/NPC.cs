using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject Player;
    private float speed = 2f;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
        /*
        Transform target;
        public float speed = 2f;

        void FixedUpdate()
        {


            target = GameObject.FindWithTag("Player").transform;

            Vector3 forwardAxis = new Vector3(0, 0, -1);

            transform.LookAt(target.position, forwardAxis);
            Debug.DrawLine(transform.position, target.position);
            transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
            transform.position -= transform.TransformDirection(Vector2.up) * speed;
        }
        */
    }
