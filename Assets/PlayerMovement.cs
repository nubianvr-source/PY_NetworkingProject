using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UI;
using Mirror;
using System.Linq;

//A custom class in case you want to pass multiple properties for the player 
public class BoxPlayer
{
    public string username;
    public BoxPlayer(string playerusername)
    {
        username = playerusername;
    }
    
}

public class PlayerMovement : NetworkBehaviour
{
    public BoxPlayer playerNameObject;
    
    public float playerSpeed;
    
    public TMP_Text playerName;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            //Basic Movement
            float Xaxismovement = Input.GetAxis("Horizontal");
            float Yaxismovement = Input.GetAxis("Vertical");
            _rigidbody2D.velocity = new Vector2(Xaxismovement * playerSpeed, Yaxismovement * playerSpeed);
        }
    }

    private void OnEnable()
    {
        playerName.text = UserManagerScript.instance.usernameField.text;
    }
}
