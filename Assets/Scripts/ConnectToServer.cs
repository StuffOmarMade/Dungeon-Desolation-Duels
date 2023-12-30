using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        /*if (*/
        PhotonNetwork.ConnectUsingSettings();/* == true) */
        //{
        //    Debug.Log("Success! Connected to server.");
        //}
        //else 
        //{
        //    Debug.Log("Failed! Unable to connect to server.");
        //}
    }

    public override void OnConnectedToMaster() 
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() 
    {
        SceneManager.LoadScene("multjoin");
    }
}
