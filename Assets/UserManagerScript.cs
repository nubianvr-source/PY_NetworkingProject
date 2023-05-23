using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserManagerScript : MonoBehaviour
{
   
    public TMP_Text usernameError;
    public static UserManagerScript instance;
    public NetworkManager networkManager;
    
    [Header("Input Fields")]
    public TMP_InputField usernameField;
    public TMP_InputField ipAddressesField;


    
    [Header("UI Panels")]
    public GameObject EnterNamePanel;
    public GameObject HostOrJoinPanel;
    public GameObject JoinAddressPanel;
    

    private void Awake()
    {
        if(instance == null)
            instance = this;
        
        ShowEnterNamePanel();
        
    }
    

    public void SetUsername()
    {
        //Error Checking to make sure no empty string is sent
        if (string.IsNullOrWhiteSpace(usernameField.text))
        { 
            usernameError.gameObject.SetActive(true);
        }
        else
        {
            
            //playerName = new BoxPlayer(usernameField.text);
            ShowHostOrJoinScreen();
        }
    }

    public void ConnectToGame()
    {
        if (!string.IsNullOrEmpty(ipAddressesField.text))
        {
            //Network Stuff Happens Here
            networkManager.networkAddress = ipAddressesField.text;
            
            networkManager.StartClient();
        }

        HideAllPanels();
    }


    private void ShowEnterNamePanel()
    {
        EnterNamePanel.SetActive(true);
        HostOrJoinPanel.SetActive(false);
        JoinAddressPanel.SetActive(false);
    }

    public void ShowHostOrJoinScreen()
    {
        EnterNamePanel.SetActive(false);
        HostOrJoinPanel.SetActive(true);
        JoinAddressPanel.SetActive(false);
    }

    public void HostGame()
    {
        Debug.Log("Hosting A Game");
        networkManager.StartHost();
        
        EnterNamePanel.SetActive(false);
        HostOrJoinPanel.SetActive(false);
        JoinAddressPanel.SetActive(false);
    }

    public void JoinGame()
    {
        EnterNamePanel.SetActive(false);
        HostOrJoinPanel.SetActive(false);
        JoinAddressPanel.SetActive(true);
    }

    public void HideAllPanels()
    {
        EnterNamePanel.SetActive(false);
        HostOrJoinPanel.SetActive(false);
        JoinAddressPanel.SetActive(false);
    }
}
