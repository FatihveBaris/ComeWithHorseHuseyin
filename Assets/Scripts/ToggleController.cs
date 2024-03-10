using UnityEngine;
using UnityEngine.UI;

public class SelectController : MonoBehaviour
{
    // Select butonlarınızın listesi
    public Toggle[] toggles;

    void Start()
    {
        foreach (var toggle in toggles)
        {
            // Her bir butona bir listener ekler
            toggle.onValueChanged.AddListener(delegate {
                UpdateToggles(toggle);
            });
        }
    }

    void UpdateToggles(Toggle changedToggle)
{
    string changedName = changedToggle.name;
    bool isOn = changedToggle.isOn;

    if (isOn)
    {
        foreach (var toggle in toggles)
        {
            // Değiştirilen buton hariç, baş veya son karakteri aynı olan diğer butonların 'Is On' durumunu false yapar
            if (toggle != changedToggle && (toggle.name[0] == changedName[0] || toggle.name[1] == changedName[1]))
            {
                toggle.isOn = false;
            }
        }
    }
}

}

