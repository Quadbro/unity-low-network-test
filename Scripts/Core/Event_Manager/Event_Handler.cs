using System;
using System.Collections.Generic;

// Event System
// Gives ability to subscribe on events, and to trigger them later

namespace Assets.Scripts.Core.Event_Manager {

    // Event handler
    // You can subscribe to events and trigger them
    public class Event_Handler {

        // Stores all information about event and handlers
        private Dictionary<string, List<Action<IEvent>>> register;

        // Creates handler entity
        public Event_Handler () {
            this.register = new Dictionary<string, List<Action<IEvent>>>();
        }

        // Regiser an event handlers, that will be listening events by "name"
        public void On (string name, Action<IEvent> callback) {
            if (!this.register.ContainsKey(name)) {
                this.register[name] = new List<Action<IEvent>>();
            }
            this.register[name].Add(callback);
        }

        // Triggers the event, by it's name, default event object will be passed to callback
        public void Trigger (string name) {
            this.Trigger(name, new Event_Base());
        }

        // Triggers the event by it's name, "data" event object will be passed to callback
        public void Trigger (string name, IEvent data) {
            if (this.register.ContainsKey(name)) {
                foreach (Action<IEvent> callback in this.register[name]) {
                    callback(data);
                }
            }
        }
    }
}