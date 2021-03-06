﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 3f;
    [SerializeField] ParticleSystem particleEffect;

    Rigidbody _rb = null;
    // Start is called before the first frame update
    void Start()
    {
       
    }

   
    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoveShip();
        TurnShip();
        //Particle Effect Activation
        

        if (Input.GetKey(KeyCode.W ) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            particleEffect.gameObject.SetActive(true);
        }
        else
        {
            particleEffect.gameObject.SetActive(false);
        }

        
       

    }

    void TurnShip()
    {
        float turnAmounThisFrame = Input.GetAxisRaw("Horizontal");
        Quaternion turnOffSet = Quaternion.Euler(0, turnAmounThisFrame, 0);
        _rb.MoveRotation(_rb.rotation * turnOffSet);
        
    }

    void MoveShip()
    {
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        _rb.AddForce(moveDirection);
       
    }

    public void Kill()
    {
        Debug.Log("Ship Gone");
        this.gameObject.SetActive(false);
        
    }

}
