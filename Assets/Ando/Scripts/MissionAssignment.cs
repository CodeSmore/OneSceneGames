using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionAssignment : MonoBehaviour {

    private Dropdown[] missionAssignmentDropdowns;
    private SupportController supportController;

    private void Awake()
    {
        // Finds ALL dropdowns in scene
        // REFACTOR
        // Change using tags or names if more dropdowns are used in different aspects of the program
        missionAssignmentDropdowns = GameObject.FindObjectsOfType<Dropdown>();
    }

    // Use this for initialization
    void Start () {
        supportController = GameObject.FindObjectOfType<SupportController>();

        Debug.Log(missionAssignmentDropdowns.Length);
        UpdateDropdownOptions();
	}
	
	// Update is called once per frame
    
        // FIX: keep the "selected" option in the list and check for all the others
	public void UpdateDropdownOptions () {
        UpdateSupportAssignementStatuses();

        Support[] allSupports = supportController.GetAllSupports();
        List<Dropdown.OptionData> options;

        foreach (Dropdown dropdown in missionAssignmentDropdowns)
        {
            var currentSelection = new Dropdown.OptionData(dropdown.captionText.text);
            int currentValue = dropdown.value;
            dropdown.ClearOptions();
            options = new List<Dropdown.OptionData>();
            options.Add(new Dropdown.OptionData("Unassigned"));

            foreach (Support supp in allSupports)
            {
                if (!supp.Assigned || supp.Name == currentSelection.text)
                {
                    options.Add(new Dropdown.OptionData(supp.Name));

                    if (supp.Name == currentSelection.text)
                    {
                        currentValue = options.Count - 1;
                    }
                }
            }

            dropdown.AddOptions(options);
            dropdown.value = currentValue;
        }
	}

    void UpdateSupportAssignementStatuses()
    {
        // set all support assignment status to false
        foreach (Support supp in supportController.GetAllSupports())
        {
            supp.Assigned = false;
        }

        // recheck support assignment statuses based on mission dropdown selections
        foreach (Support supp in supportController.GetAllSupports())
        {
            foreach (Dropdown dropdown in missionAssignmentDropdowns)
            {
                if (dropdown.captionText.text == supp.Name)
                {
                    supp.Assigned = true;
                }
            }
        } 
    }
}
