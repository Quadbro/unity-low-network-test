using Assets.Scripts.UI.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Managers {

    public class UI_Manager_Editor : UI_Manager_Base {

        //Pages
        private GameObject page_Creation;

        private GameObject page_Editor;

        // Creation menu
        private Slider slider_MapSize;

        private Text slider_MapSize_Value;

        // Editor menu
        private GameObject panel_Main;

        private GameObject navigationTop;
        private GameObject panel_Terrain;
        private GameObject panel_Objects;
        private GameObject panel_Map;
        private GameObject panel_Container;

        // Top navigattion buttons
        private Button btn_Terrain;

        private Button btn_Objects;
        private Button btn_Map;

        private UI_Toggle_Tabs navigationTabs;

        public void Awake () {
            // Pages
            page_Creation = GetChild(gameObject, "Page_Creation");
            page_Editor = GetChild(gameObject, "Page_Editor");

            // Creation menu
            var temp_SliderGO = GetChild(page_Creation, "Slider_MapSize");
            slider_MapSize = temp_SliderGO.GetComponent<Slider>();
            slider_MapSize_Value = GetChild(temp_SliderGO, "Value").GetComponent<Text>();

            // Editor menu
            panel_Main = GetChild(page_Editor, "Panel_Main");
            navigationTop = GetChild(panel_Main, "Navigation_Top");
            panel_Container = GetChild(panel_Main, "Panel_Container");
            panel_Terrain = GetChild(panel_Container, "Panel_Terrain");
            panel_Objects = GetChild(panel_Container, "Panel_Objects");
            panel_Map = GetChild(panel_Container, "Panel_Map");

            // Top navigattion buttons
            btn_Terrain = GetChild(navigationTop, "Btn_Terrain").GetComponent<Button>();
            btn_Objects = GetChild(navigationTop, "Btn_Objects").GetComponent<Button>();
            btn_Map = GetChild(navigationTop, "Btn_Map").GetComponent<Button>();

            btn_Terrain.onClick.AddListener(() => { Editor_OnButtonTerrain(); });

            navigationTabs = new UI_Toggle_Tabs();

            navigationTabs.AddTab(panel_Terrain, btn_Terrain);
            navigationTabs.AddTab(panel_Objects, btn_Objects);
            navigationTabs.AddTab(panel_Map, btn_Map);
        }

        public void Start () {
            page_Creation.SetActive(true);
            Creation_OnSliderMapSizeValueChanged();
            DeactivateEditorPanels();
        }

        private void DeactivateEditorPanels () {
            panel_Main.SetActive(false);
            navigationTop.SetActive(false);
            panel_Terrain.SetActive(false);
            panel_Objects.SetActive(false);
            panel_Map.SetActive(false);
            page_Editor.SetActive(false);
        }

        private void ActivateEditorPanels () {
            page_Editor.SetActive(true);
            panel_Main.SetActive(true);
            navigationTop.SetActive(true);
        }

        // Creation panel methods
        public void Creation_OnButtonCreate () {
            page_Creation.SetActive(false);
            ActivateEditorPanels();
        }

        public void Creation_OnButtonExit () {
            Application.LoadLevel("Entry");
        }

        public void Creation_OnSliderMapSizeValueChanged () {
            slider_MapSize_Value.text = slider_MapSize.value.ToString();
        }

        // Editor panel methods
        public void Editor_OnButtonTerrain () {
            navigationTabs.SwitchTab(panel_Terrain);
        }

        public void Editor_OnButttonObjects () {
            navigationTabs.SwitchTab(panel_Objects);
        }

        public void Editor_OnButtonMap () {
            navigationTabs.SwitchTab(panel_Map);
        }

        public void Editor_OnButtonSave () {
        }

        public void Editor_OnButtonLoad () {
        }

        public void Editor_OnButtonTest () {
        }

        public void Editor_OnButtonChangeFragment () {
        }
    }
}