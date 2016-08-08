using UnityEngine;
using UnityEngine.UI;

public class UMP_LevelInfo : MonoBehaviour {
    public Text Title;
    public Text Description;
    public Image Preview;

    [Space(7)]
    public string EventAnimation = "LevelEnter";

    //Name of scene of build setting
    private string LevelName;

    public void GetInfo (string title, string desc, Sprite preview, string scene) {
        Title.text = title;
        Description.text = desc;
        Preview.sprite = preview;

        LevelName = scene;
    }

    public void OpenLevel () { Application.LoadLevel(LevelName); }

    public void EventMouse (bool Forward = true) {
        Animation a = this.GetComponent<Animation>();
        if (Forward) {
            a[EventAnimation].time = 0.0f;
            a[EventAnimation].speed = 1.0f;
            a.CrossFade(EventAnimation);
        } else {
            if (a[EventAnimation].time == 0.0f) {
                a[EventAnimation].time = a[EventAnimation].length;
            }
            a[EventAnimation].speed = -1.0f;
            a.CrossFade(EventAnimation);
        }
    }
}