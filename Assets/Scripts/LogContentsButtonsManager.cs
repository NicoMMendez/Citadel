﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogContentsButtonsManager : MonoBehaviour {
	[SerializeField] private GameObject[] LogButtons;
	[SerializeField] private Text[] LogButtonsText;
	public int currentLevelFolder;
	public string[] logNames;
	public int[] retrievedIndices;
	public MultiMediaLogButton[] logRefButtons;

	void Start() {
		InitializeLogsFromLevelIntoFolder();
	}

	public void InitializeLogsFromLevelIntoFolder() {
		retrievedIndices = new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
		logNames = GetLogNamesFromLevel(currentLevelFolder);
		for (int i=0; i<15; i++) {
			logRefButtons[i] = LogButtons[i].GetComponent<MultiMediaLogButton>();
		}
	}

	void Update() {
		for (int i=0; i<15; i++) {
			LogButtonsText[i].text = logNames[i];
			logRefButtons[i].logReferenceIndex = retrievedIndices[i];
			if (LogInventory.a.hasLog[retrievedIndices[i]]) {
				LogButtons[i].SetActive(true);
			} else {
				LogButtons[i].SetActive(false);
			}
		}
	}

	string[] GetLogNamesFromLevel (int index) {
		string[] retval = {"","","","","","","","","","","","","","",""};
		int indexingVal = 0;
		for (int i=0;i<255;i++) {
			if ((Const.a.audioLogLevelFound[i] == index)) {
				retval[indexingVal] = Const.a.audiologNames[i];
				retrievedIndices[indexingVal] = i;
				indexingVal++;
				if (indexingVal > 14)
					break; // No need to iterate through remaining list if we already have 14 values
			}
		}
		return retval;
	}
}
