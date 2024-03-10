using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiletTikParent : MonoBehaviour
{
    public ToggleGroup group1;
    public ToggleGroup group2;
    public ToggleGroup group3;
    public ToggleGroup group4;

    void Start()
    {
        // Her bir grup için Toggle'ları ayarla
        SetTogglesForGroup(group1);
        SetTogglesForGroup(group2);
        SetTogglesForGroup(group3);
        SetTogglesForGroup(group4);
    }

    void SetTogglesForGroup(ToggleGroup group)
    {
        // Grubun içindeki tüm Toggle'ları al
        Toggle[] toggles = group.GetComponentsInChildren<Toggle>();

        // Her bir Toggle için bir event ekleyin
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(toggle, group);
            });
        }
    }

    void ToggleValueChanged(Toggle changedToggle, ToggleGroup group)
    {
        // Değişen Toggle'ın değeri true ise, diğerlerini false yap
        if (changedToggle.isOn)
        {
            Toggle[] toggles = group.GetComponentsInChildren<Toggle>();
            foreach (Toggle toggle in toggles)
            {
                if (toggle != changedToggle)
                {
                    toggle.isOn = false;
                }
            }
        }
    }

}
