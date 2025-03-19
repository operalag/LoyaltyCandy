using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAvatar : MonoBehaviour
{
    public Toggle boyToggle;
    public Toggle girlToggle;
    private ToggleAvatar toggleAvatar;
    // Start is called before the first frame update
    void Start()
    {
        toggleAvatar = FindObjectOfType<ToggleAvatar>();
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

        if (toggleAvatar != null)
        {
            toggleAvatar.AvatarUpdate();
        }
    }

    void LoadSelectedAvatar()
    {
        string savedAvatar = PlayerPrefs.GetString("SelectedAvatar", "");
        if (savedAvatar == "Boy")
        {
            boyToggle.isOn = true;
        }

        if (savedAvatar == "Girl")
        {
            girlToggle.isOn = true;
        }
    }

}
