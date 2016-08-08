using Assets.Scripts.Core.Event_Manager;
using Assets.Scripts.Network;
using Assets.Scripts.Utils;

namespace Assets.Scripts.Core {

    public class Game_Manager : Singleton<Game_Manager> {
        private Event_Handler _events;
        private Network_Manager _network;

        public static Event_Handler events {
            get { return instance._events; }
            private set { }
        }

        public static Network_Manager network {
            get { return instance._network; }
            private set { }
        }

        public void Awake () {
            this._events = new Event_Handler();
            this._network = new Network_Manager();
        }

        public void OnApplicationQuit () {
            
        }
    }
}