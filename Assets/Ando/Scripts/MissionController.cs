using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionController : MonoBehaviour {

    public MissionStats[] missionStats;

    private SupportController supportController;
    private Support[] allSupports;

	// Use this for initialization
	void Start () {
        supportController = GameObject.FindObjectOfType<SupportController>();
        allSupports = supportController.GetAllSupports();


        ResetLoadingBarUI();

        UpdateMissionData();

        UpdateMissionUI();
	}

    // Update is called once per frame
    void Update() {
        
        HandleMissionTimers();
	}

    // **MAIN MISSION UI UPDATE METHOD**
    void UpdateMissionUI()
    {
        // LoadingBars MUST be updated each frame
        foreach (MissionStats mStat in missionStats)
        {
            mStat.MissionLoadingBar.fillAmount = mStat.GetTimer() / mStat.GetUpdatedDuration();

            // Only needs to be updated when values change (variable times)
            mStat.MissionIncomeText.text = mStat.MissionIncome.ToString();
            mStat.MissionDurationText.text = mStat.GetUpdatedDuration().ToString() + "s";
        }
    }

    public void UpdateMissionData()
    {
        for (int i = 0; i < missionStats.Length; ++i)
        {
            UpdateMission(i);
        }
    }

    private void HandleMissionTimers()
    {
        foreach (MissionStats mStats in missionStats)
        {
            if (mStats.GetMissionEnabled())
            {
                mStats.AddTimer(Time.deltaTime);
            }

            if (mStats.GetTimer() >= mStats.GetUpdatedDuration())
            {
                mStats.ResetTimer();

                StatsController.currency += mStats.MissionIncome;
            }
        }

        // updateUI 
        UpdateMissionUI();
    }

    void UpdateMission(int index)
    {
        //FIX: compare option string and support name rather than value

        foreach (Support supp in allSupports)
        {
            if (missionStats[index].MissionDropdown.captionText.text == supp.Name)
            {
                missionStats[index].SetMissionEnabled(true);

                var baseDuration = missionStats[index].BaseDuration;
                var updatedDuration = Mathf.Clamp(baseDuration - (supp.CurrentPower * 0.25f), 0.1f, baseDuration);
                missionStats[index].SetUpdatedDuration(updatedDuration);

                supp.Assigned = true;

                return;
            }
        }

        missionStats[index].SetMissionEnabled(false);
        missionStats[index].SetUpdatedDuration(missionStats[index].BaseDuration);
    }

    //void UpdateMission1()
    //{
    //    //FIX: compare option string and support name rather than value
    //    if (Mission1Dropdown.captionText.text == allSupports[0].Name)
    //    {
    //        Mission1Enabled = true;

    //        // The intention was to make a power level of 10 half the duration
    //        m1UpdatedDuration = Mathf.Clamp(m1BaseDuration - (allSupports[0].CurrentPower * 0.25f), 0, m1BaseDuration);
    //        allSupports[0].Assigned = true; 
    //    }
    //    else if (Mission1Dropdown.captionText.text == allSupports[1].Name)
    //    {
    //        Mission1Enabled = true;

    //        m1UpdatedDuration = Mathf.Clamp(m1BaseDuration - (allSupports[1].CurrentPower * 0.25f), 0, m1BaseDuration);
    //        allSupports[1].Assigned = true;
    //    }
    //    else if (Mission1Dropdown.captionText.text == allSupports[2].Name)
    //    {
    //        Mission1Enabled = true;

    //        m1UpdatedDuration = Mathf.Clamp(m1BaseDuration - (allSupports[2].CurrentPower * 0.25f), 0, m1BaseDuration);
    //        allSupports[2].Assigned = true;
    //    }
    //    else
    //    {
    //        Mission1Enabled = false;

    //        m1UpdatedDuration = m1BaseDuration;
    //    }
    //}

    //void UpdateMission2()
    //{
    //    if (Mission2Dropdown.value == 1)
    //    {
    //        Mission2Enabled = true;

    //        m2UpdatedDuration = Mathf.Clamp(m2BaseDuration - (supportController.supports[0].CurrentPower * 0.25f), 0, m2BaseDuration);
    //    }
    //    else if (Mission2Dropdown.value == 2)
    //    {
    //        Mission2Enabled = true;

    //        m2UpdatedDuration = Mathf.Clamp(m2BaseDuration - (supportController.supports[1].CurrentPower * 0.25f), 0, m2BaseDuration);
    //    }
    //    else if (Mission2Dropdown.value == 3)
    //    {
    //        Mission2Enabled = true;

    //        m2UpdatedDuration = Mathf.Clamp(m2BaseDuration - (supportController.supports[2].CurrentPower * 0.25f), 0, m2BaseDuration);
    //    }
    //    else
    //    {
    //        Mission2Enabled = false;

    //        m2UpdatedDuration = m2BaseDuration;
    //    }
    //}

    //void UpdateMission3()
    //{
    //    if (Mission3Dropdown.value == 1)
    //    {
    //        Mission3Enabled = true;

    //        m3UpdatedDuration = Mathf.Clamp(m3BaseDuration - (supportController.supports[0].CurrentPower * 0.25f), 0, m3BaseDuration);
    //    }
    //    else if (Mission3Dropdown.value == 2)
    //    {
    //        Mission3Enabled = true;

    //        m3UpdatedDuration = Mathf.Clamp(m3BaseDuration - (supportController.supports[1].CurrentPower * 0.25f), 0, m3BaseDuration);
    //    }
    //    else if (Mission3Dropdown.value == 3)
    //    {
    //        Mission3Enabled = true;

    //        m3UpdatedDuration = Mathf.Clamp(m3BaseDuration - (supportController.supports[2].CurrentPower * 0.25f), 0, m3BaseDuration);
    //    }
    //    else
    //    {
    //        Mission3Enabled = false;

    //        m3UpdatedDuration = m3BaseDuration;
    //    }
    //}

    void ResetLoadingBarUI()
    {
        foreach (MissionStats mStat in missionStats)
        {
            mStat.MissionLoadingBar.fillAmount = 0;
        }
    }
}

// TODO refactor methods zzzz
[System.Serializable]
public class MissionStats {
    public string Name;
    public int MissionIncome;
    public Dropdown MissionDropdown;
    public Image MissionLoadingBar;
    public Text MissionIncomeText;
    public Text MissionDurationText;
    public float BaseDuration;

    private float Timer = 0;
    private float UpdatedDuration;
    private bool MissionEnabled = false;

    public float GetTimer()
    {
        return Timer;
    }

    public void AddTimer(float addedTime)
    {
        Timer += addedTime;
    }

    public void ResetTimer()
    {
        Timer = 0;
    }

    public bool GetMissionEnabled()
    {
        return MissionEnabled;
    }

    public void SetMissionEnabled(bool setBool)
    {
        MissionEnabled = setBool;
    }

    public float GetUpdatedDuration()
    {
        return UpdatedDuration;
    }

    public void SetUpdatedDuration(float newDuration)
    {
        UpdatedDuration = newDuration;
    }
}
