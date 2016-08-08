using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player {
    public class Player_Camera : MonoBehaviour {
        // Config
        public Transform target;
        public Vector3 cameraRotation;
        public float damping = 5;
        public float height = 15;
        public float offset = -10;
        public float viewDistance = 20;
        public bool isControlable = true;
     
        // Cursor
        public Texture2D cursorTexture;

        //Private stuff
        private Transform _t;
        private Quaternion _rotation;
        private Vector2 wantedPos;


        public void Awake () {
            _t = this.transform;
            _t.position = target.position;
            _t.rotation = Quaternion.Euler(cameraRotation);

            Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);
            Cursor.lockState = CursorLockMode.Confined;
            
        }

        public void Start () {
          
        }

        public void Update () {

        }

        public void FixedUpdate () {
            if (target) {
                if (isControlable) {
                    var mousePos = Input.mousePosition;
                    mousePos.z = viewDistance;
                    var CursorPosition = Camera.main.ScreenToWorldPoint(mousePos);
                    var center = new Vector3((target.position.x + CursorPosition.x) / 2, target.position.y, (target.position.z + CursorPosition.z) / 2);
                    _t.position = Vector3.Lerp(_t.position, center + new Vector3(0, height, offset), Time.deltaTime * damping);
                }
            }
        }
    }
}
