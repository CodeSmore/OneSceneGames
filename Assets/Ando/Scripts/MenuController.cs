using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
    public GameObject PlayerMenu;
    public GameObject SupportsMenu;
    public GameObject MissionsMenu;

    public Button PlayerMenuButton;
    public Button SupportMenuButton;
    public Button MissionMenuButton;

	// Use this for initialization
	void Start () {
        HideMenus();

        PlayerMenuButton.onClick.AddListener(PlayerMenuClick);
        SupportMenuButton.onClick.AddListener(SupportMenuClick);
        MissionMenuButton.onClick.AddListener(MissionMenuClick);
	}

    void HideMenus()
    {
        PlayerMenu.SetActive(false);
        SupportsMenu.SetActive(false);
        MissionsMenu.SetActive(false);
    }

    void PlayerMenuClick()
    {
        PlayerMenu.SetActive(!PlayerMenu.activeSelf);
        SupportsMenu.SetActive(false);
        MissionsMenu.SetActive(false);
    }

    void SupportMenuClick()
    {
        SupportsMenu.SetActive(!SupportsMenu.activeSelf);
        PlayerMenu.SetActive(false);
        MissionsMenu.SetActive(false);
    }

    void MissionMenuClick()
    {
        MissionsMenu.SetActive(!MissionsMenu.activeSelf);
        PlayerMenu.SetActive(false);
        SupportsMenu.SetActive(false);
    }
}
