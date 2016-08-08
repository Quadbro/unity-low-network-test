using System.Collections.Generic;
using UnityEngine;

public class UMP_Manager : MonoBehaviour {
    public List<GameObject> Windows = new List<GameObject>();

    [Space(10)]
    public List<LevelInfo> Levels = new List<LevelInfo>();

    public GameObject LevelPrefab;
    public Transform LevelPanel;

    private int CurrentWindow = -1;

    private void Awake () {
        InstanceLevels();
    }

    private void InstanceLevels () {
        for (int i = 0; i < Levels.Count; i++) {
            GameObject l = Instantiate(LevelPrefab) as GameObject;

            UMP_LevelInfo li = l.GetComponent<UMP_LevelInfo>();
            li.GetInfo(Levels[i].Title, Levels[i].Description, Levels[i].Preview, Levels[i].LevelName);

            l.transform.SetParent(LevelPanel, false);
        }
    }

    public void ChangeWindow (int id) {
        if (CurrentWindow == id)
            return;

        if (id != 2) {
            for (int i = 0; i < Windows.Count; i++) {
                Windows[i].SetActive(false);
            }
        }
        CurrentWindow = id;
        Windows[id].SetActive(true);
    }


    public void SocialButton (string url) {
        Application.OpenURL(url);
    }

    public void QuitApp () {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }

    [System.Serializable]
    public class LevelInfo {

        public string LevelName;

        [Space(5)]
        public string Title;

        public string Description;
        public Sprite Preview;
    }
}