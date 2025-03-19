using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAvatar : MonoBehaviour
{
    public GameObject boyAvatar;
    public GameObject girlAvatar;
    // Start is called before the first frame update
    void Start()
    {
       AvatarUpdate();
    }

    // Update is called once per frame
    public void AvatarUpdate()
    {
        if (boyAvatar != null && girlAvatar != null)
        {
            string savedAvatar = PlayerPrefs.GetString("SelectedAvatar", "");
            if (savedAvatar == "Boy")
            {
                boyAvatar.SetActive(true);
                girlAvatar.SetActive(false);
            }

            if (savedAvatar == "Girl")
            {
                girlAvatar.SetActive(true);
                boyAvatar.SetActive(false);
            }
        }
    }
}
