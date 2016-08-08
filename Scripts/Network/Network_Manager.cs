using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Network {
    public class Network_Manager {
        NetworkClient client;


        // Create a server and listen on a port
        public void SetupServer (int port) {
            NetworkServer.Listen(port);
        }

        // Create a client and connect to the server port
        public void SetupClient (string ip, int port) {
            client = new NetworkClient();
            client.RegisterHandler(MsgType.Connect, OnConnected);
            client.Connect(ip, port);
        }

        // Create a local client and connect to the local server
        public void SetupLocalClient () {
            client = ClientScene.ConnectLocalServer();
            client.RegisterHandler(MsgType.Connect, OnConnected);
        }

        public void CloseServer () {
            client.RegisterHandler(MsgType.Disconnect, OnDisconnected);
            NetworkServer.Shutdown ();
        }

        // client function
        public void OnConnected (NetworkMessage netMsg) {
            Debug.Log("Connected to server");
        }

        public void OnDisconnected (NetworkMessage netMsg) {
            Debug.Log("Disconnected from server");
        }
    }
}
