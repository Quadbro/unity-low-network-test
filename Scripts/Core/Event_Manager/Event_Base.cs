namespace Assets.Scripts.Core.Event_Manager {

    public class Event_Base : IEvent {

        public Event_Base () {
        }

        public System.Collections.ArrayList GetData () {
            return new System.Collections.ArrayList();
        }
    }
}