using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{

    private CharacterController Character_Boy;
    private Animator animator;
    private Vector3 inputs;

    private float velocidade = 5f;




    // Start is called before the first frame update
    void Start()
    {
        Character_Boy = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Character_Boy.Move(inputs * Time.deltaTime * velocidade);

        if(inputs != Vector3.zero)
        {
            animator.SetBool("Andando", true);
            transform.forward = Vector3.Slerp(transform.forward, inputs, Time.deltaTime * 10); 
        }
        else
        {
            animator.SetBool("Andando", false);
        }


    }
}