using UnityEngine;

namespace Assets.Scripts.UI.Managers {

    public class UI_Manager_Base : MonoBehaviour {

        public GameObject GetChild (GameObject go, string name) {
            return go.transform.FindChild(name).gameObject;
        }
    }
}