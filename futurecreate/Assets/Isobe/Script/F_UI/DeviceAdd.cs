using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DeviceAdd : MonoBehaviour
{
    private Dropdown.OptionData m_data;
    // Start is called before the first frame update
    void Start()
    {
        m_data = new Dropdown.OptionData();
        if (Gamepad.current != null)
        {
            m_data.text = Gamepad.current.device.name;
            this.GetComponent<Dropdown>().options.Add(m_data);
        }
    }
}
