using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarToggle : MonoBehaviour
{
    public Toggle boyToggle;
    public Toggle girlToggle;
    // Start is called before the first frame update
    void Start()
    {
        LoadSelectedAvatar();

        if (boyToggle != null && girlToggle != null)
        {
            boyToggle.onValueChanged.AddListener( delegate {SaveAvatarSelection("Boy"); });
            girlToggle.onValueChanged.AddListener( delegate {SaveAvatarSelection("Girl"); }); 
        }
    }

    void SaveAvatarSelection(string selectedAvatar)
    {
        PlayerPrefs.SetString("SelectedAvatar", selectedAvatar);
        PlayerPrefs.Save();
    }

    void LoadSelectedAvatar()
    {
        string savedAvatar = PlayerPrefs.GetString("SelectedAvatar", "");
        if (savedAvatar == "Boy")
        {
            boyToggle.isOn = true;
            Debug.Log("Selected boy");
        }

        else if (savedAvatar == "Girl")
        {
            girlToggle.isOn = true;
            Debug.Log("Selected girl");
        }
    }

}
