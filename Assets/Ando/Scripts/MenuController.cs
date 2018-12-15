using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject SupportsMenu;
    public GameObject MissionsMenu;

    public Button SupportMenuButton;
    public Button MissionMenuButton;

	// Use this for initialization
	void Start () {
        SupportsMenu.SetActive(false);
        MissionsMenu.SetActive(false);

        SupportMenuButton.onClick.AddListener(SupportMenuClick);
        MissionMenuButton.onClick.AddListener(MissionMenuClick);
	}

    void SupportMenuClick()
    {
        SupportsMenu.SetActive(!SupportsMenu.activeSelf);
        MissionsMenu.SetActive(false);
    }

    void MissionMenuClick()
    {
        MissionsMenu.SetActive(!MissionsMenu.activeSelf);
        SupportsMenu.SetActive(false);
    }
}
