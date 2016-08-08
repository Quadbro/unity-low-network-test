using System.Net;
using Assets.Scripts.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Managers {

    public class UI_Manager_MainMenu : UI_Manager_Base {
        private GameObject page_MainMenu;
        private GameObject page_Host;
        private GameObject page_Join;
        private GameObject page_Credits;
        private GameObject page_Options;

        private InputField join_input_Ip;
        private InputField join_input_Port;
        private InputField join_input_Username;
        private InputField join_input_Password;
        private Button join_btn_Join;

        private InputField host_input_GameName;
        private InputField host_input_Port;
        private InputField host_input_Username;
        private InputField host_input_Password;
        private Button host_btn_Host;

        private UI_Navigator_Indent navigator;

        public void Awake () {
            navigator = new UI_Navigator_Indent();

            page_MainMenu = GetChild(gameObject, "Page_MainMenu");
            page_Host = GetChild(gameObject, "Page_Host");
            page_Join = GetChild(gameObject, "Page_Join");
            page_Credits = GetChild(gameObject, "Page_Credits");
            page_Options = GetChild(gameObject, "Page_Options");

            join_input_Ip = GetChild(page_Join, "InputField_IP").GetComponent<InputField>();
            join_input_Port = GetChild(page_Join, "InputField_Port").GetComponent<InputField>();
            join_input_Username = GetChild(page_Join, "InputField_Username").GetComponent<InputField>();
            join_input_Password = GetChild(page_Join, "InputField_Password").GetComponent<InputField>();
            join_btn_Join = GetChild(page_Join, "Btn_Join").GetComponent<Button>();

            host_input_GameName = GetChild(page_Host, "InputField_GameName").GetComponent<InputField>();
            host_input_Port = GetChild(page_Host, "InputField_Port").GetComponent<InputField>();
            host_input_Username = GetChild(page_Host, "InputField_Username").GetComponent<InputField>();
            host_input_Password = GetChild(page_Host, "InputField_Password").GetComponent<InputField>();
            host_btn_Host = GetChild(page_Host, "Btn_Host").GetComponent<Button>();

            join_input_Ip.text = "127.0.0.1";
            join_input_Port.text = "44445";
            join_input_Username.text = "SomeUser";
            join_input_Password.text = "SomePassword";

            host_input_GameName.text = "SomeGameName";
            host_input_Port.text = "44445";
            host_input_Username.text = "SomeUser";
            host_input_Password.text = "SomePassword";

            navigator.SetFirstPage(page_MainMenu);
        }

        public void Start () {
        }

        public void OnButtonBack () {
            navigator.Back();
        }

        /**
        * Main menu section
        */

        public void MainMenu_OnButtonHost () {
            navigator.Next(page_Host);
        }

        public void MainMenu_OnButtonJoin () {
            navigator.Next(page_Join);
            Join_CheckData();
        }

        public void MainMenu_OnButtonOptions () {
            navigator.Next(page_Options);
        }

        public void MainMenu_OnButtonEditor () {
            Map.Map_Editor.Start();
        }

        public void MainMenu_OnButtonCredits () {
            navigator.Next(page_Credits);
        }

        public void MainMenu_OnButtonQuit () {
            Application.Quit();
        }

        /**
        * Join menu section
        */

        public void Join_OnButtonJoin () {
            var ip = join_input_Ip.text;
            var port = int.Parse(join_input_Port.text);
            var username = join_input_Username.text;
            var password = join_input_Password.text;

            Core.Game_Manager.network.SetupClient(ip, port);
        }

        public void Join_CheckData () {
            // Get data
            var ip = join_input_Ip.text;
            var port = join_input_Port.text;
            var username = join_input_Username.text;
            var password = join_input_Password.text;

            // Check ip
            IPAddress address;
            bool isValidIp = System.Net.IPAddress.TryParse(ip, out address);

            // Check epty strings
            if (ip != "" && port != "" && username != "" && password != "" && isValidIp) {
                join_btn_Join.interactable = true;
            } else {
                join_btn_Join.interactable = false;
            }
        }

        /**
        * Host menu section
        */

        public void Host_OnButtonHost () {
            var gameName = host_input_GameName.text;
            var port = int.Parse(host_input_Port.text);
            var username = host_input_Username.text;
            var password = host_input_Password.text;

            Core.Game_Manager.network.SetupServer(port);
            Core.Game_Manager.network.SetupLocalClient();
        }

        public void Host_CheckData () {
            // Get data
            var gameName = host_input_GameName.text;
            var port = host_input_Port.text;
            var username = host_input_Username.text;
            var password = host_input_Password.text;

            // Check epty strings
            if (gameName != "" && port != "" && username != "" && password != "") {
                host_btn_Host.interactable = true;
            } else {
                host_btn_Host.interactable = false;
            }
        }
    }
}