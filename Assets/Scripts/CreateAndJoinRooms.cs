using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField _createRoomInputField;

    [SerializeField] 
    private InputField _joinRoomInputField;

    public void CreateRoom() 
    {
        PhotonNetwork.CreateRoom(_createRoomInputField.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinRoomInputField.text);
    }

    public override void OnJoinedRoom() 
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }
}
