using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using System.Linq;

//Please dont confuse the main Mirror Network Manager class with this. This inherits from that one.
public class NetworkManager : Mirror.NetworkManager
{
    [SerializeField] public PlayerMovement player;

    public List<PlayerMovement> playerList { get; } = new List<PlayerMovement>();
    
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
}
