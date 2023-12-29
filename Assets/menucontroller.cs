using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menucontroller : MonoBehaviour
{
    [SerializeField] private string VersioName = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;
    
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;
    [SerializeField] private GameObject StartButton;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersioName);

    }
    private void Start()
    {
        UsernameMenu.SetActive(true);
    }
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }
    public void ChangeUserNameInput()
    {
        if (UsernameInput.text.Length >= 1)
        {
            StartButton.SetActive(true);

        }
        else
        {
            StartButton.SetActive(false);
        }


    }
    public void SetUserName()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }
    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(CreateGameInput.text, new RoomOptions { MaxPlayers = 2 }, null);
    }

    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }

