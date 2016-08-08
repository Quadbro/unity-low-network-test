using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Utils {

    public class UI_Toggle_Tabs {

        // <panel, button>
        public Dictionary<GameObject, Button> tabs { get; private set; }

        private GameObject currPanel;
        private GameObject prevPanel;

        public UI_Toggle_Tabs () {
            this.currPanel = null;
            this.prevPanel = null;
            this.tabs = new Dictionary<GameObject, Button>();
        }

        public void AddTab (GameObject panel, Button button) {
            panel.SetActive(false);
            button.image.color = Color.white;
            this.tabs.Add(panel, button);
        }

        private void ActivateTab (KeyValuePair<GameObject, Button> tab) {
            tab.Key.SetActive(true);
            tab.Value.image.color = Color.green;
        }

        private void DeactivateTab (KeyValuePair<GameObject, Button> tab) {
            tab.Key.SetActive(false);
            tab.Value.image.color = Color.white;
        }

        public void SwitchTab (GameObject panel) {
            if (currPanel == panel) {
                DeactivateTab(GetTab(panel));
                currPanel = null;
            } else if (currPanel == null) {
                currPanel = panel;
                ActivateTab(GetTab(panel));
            } else {
                DeactivateTab(GetTab(currPanel));
                ActivateTab(GetTab(panel));
                currPanel = panel;
            }
            prevPanel = currPanel;
        }

        public void SetCurrent (GameObject panel) {
            ActivateTab(GetTab(panel));
        }

        private KeyValuePair<GameObject, Button> GetTab (GameObject panel) {
            foreach (KeyValuePair<GameObject, Button> tab in tabs) {
                if (tab.Key == panel) {
                    return tab;
                }
            }
            return new KeyValuePair<GameObject, Button>(null, null);
        }
    }
}