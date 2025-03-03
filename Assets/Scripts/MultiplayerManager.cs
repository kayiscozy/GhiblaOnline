using Photon.Pun;
using UnityEngine;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Verbunden mit Photon Server!");
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom("GhiblaRoom");
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Beigetreten: " + PhotonNetwork.CurrentRoom.Name);
    }
}