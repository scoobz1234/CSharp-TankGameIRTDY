using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour {

    public InputField wButton, aButton, sButton, dButton, spaceButton;
    public Image wButtonImg, aButtonImg, sButtonImg, dButtonImg, spaceButtonImg;
    InputField tempButton;
    ProgressBarPro mainTimerPBP, rollTimerPBP, lockTimerPBP;
    public GameObject mainTimerObj, rollTimerObj, lockTimerObj; 
    int rollForButton, rollForControl;
    public List<int> rList = new List<int>();
    public int wControl, aControl, sControl, dControl, spaceControl;
    float mainTimer = 4000f, lockTimer = 0f, rollTimer = 0f;
    bool canRoll, canLock;

    private void Start() {
        ResetSchematic();
        mainTimerPBP = mainTimerObj.GetComponent<ProgressBarPro>();
        rollTimerPBP = rollTimerObj.GetComponent<ProgressBarPro>();
        lockTimerPBP = lockTimerObj.GetComponent<ProgressBarPro>();
    }

    void Update() {

        if (Input.GetKeyUp(KeyCode.Keypad1) && canRoll) {
            if (rList.Count > 0) {
                rollTimer = 0;
                rollTimerPBP.SetValue(rollTimer, 100);
                rollForButton = Random.Range(1, 6);
                while (!rList.Contains(rollForButton))
                    rollForButton = Random.Range(1, 6);

                RollForButton(rollForButton);
                canRoll = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Keypad2) && canLock) {
            if (rList.Count > 0) {
                lockTimer = 0;
                lockTimerPBP.SetValue(lockTimer, 800);

                StartCoroutine(WaitForKeyDown(KeyCode.W));
                StartCoroutine(WaitForKeyDown(KeyCode.A));
                StartCoroutine(WaitForKeyDown(KeyCode.S));
                StartCoroutine(WaitForKeyDown(KeyCode.D));
                StartCoroutine(WaitForKeyDown(KeyCode.Space));
                canLock = false;
            }
        }
        //main timer for reset
        if (mainTimer >= 1) {
            mainTimer--;
            mainTimerPBP.SetValue(mainTimer, 4000);
        }
        else if (mainTimer <= 0) {
            mainTimer = 4000;
            ResetSchematic();
        }
        //roll timer
        if (canRoll == false) {
            if (rollTimer < 100) {
                rollTimer++;
                rollTimerPBP.SetValue(rollTimer, 100);
            }
            else
                canRoll = true;
        }
        //lock timer
        if (canLock == false) {
            if (lockTimer < 800) {
                lockTimer++;
                lockTimerPBP.SetValue(lockTimer, 800);
            }
            else
                canLock = true;
        }
    }

    IEnumerator WaitForKeyDown(KeyCode keyCode) {
        while (!Input.GetKeyDown(keyCode)) {

            if (Input.GetKey(KeyCode.W)) {
                wButtonImg.color = new Color(255,0,0);
                rList.Remove(1);
                break;
            }
            else if (Input.GetKey(KeyCode.A)) {
                aButtonImg.color = new Color(255, 0, 0);
                rList.Remove(2);
                break;
            }
            else if (Input.GetKey(KeyCode.S)) {
                sButtonImg.color = new Color(255, 0, 0);
                rList.Remove(3);
                break;
            }
            else if (Input.GetKey(KeyCode.D)) {
                dButtonImg.color = new Color(255, 0, 0);
                rList.Remove(4);
                break;
            }
            else if (Input.GetKey(KeyCode.Space)) {
                spaceButtonImg.color = new Color(255, 0, 0);
                rList.Remove(5);
                break;
            }
            yield return 0;
        }
    }

    void ResetSchematic() {
        //re add 1-5 to the roll list...
        if (!rList.Contains(1) || !rList.Contains(2) || !rList.Contains(3) || !rList.Contains(4) || !rList.Contains(5)) {
            rList.Add(1);
            rList.Add(2);
            rList.Add(3);
            rList.Add(4);
            rList.Add(5);
        }
        //reset button control texts...
        wButton.text = "Broken";
        aButton.text = "Broken";
        sButton.text = "Broken";
        dButton.text = "Broken";
        spaceButton.text = "Broken";

        //reset the color of the buttons
        wButtonImg.color = new Color(255, 255, 255);
        aButtonImg.color = new Color(255, 255, 255);
        sButtonImg.color = new Color(255, 255, 255);
        dButtonImg.color = new Color(255, 255, 255);
        spaceButtonImg.color = new Color(255, 255, 255);

        //reset the controls...
        wControl = 0;
        aControl = 0;
        sControl = 0;
        dControl = 0;
        spaceControl = 0;

        //reset the tempButton
        tempButton = null;
    }

    private void RollForButton(int roll) {
        switch (roll) {
            case 1:
                tempButton = wButton;
                RollForControl(tempButton, rollForControl = Random.Range(1, 6));
                break;
            case 2:
                tempButton = aButton;
                RollForControl(tempButton, rollForControl = Random.Range(1, 6));
                break;
            case 3:
                tempButton = sButton;
                RollForControl(tempButton, rollForControl = Random.Range(1, 6));
                break;
            case 4:
                tempButton = dButton;
                RollForControl(tempButton, rollForControl = Random.Range(1, 6));
                break;
            case 5:
                tempButton = spaceButton;
                RollForControl(tempButton, rollForControl = Random.Range(1, 6));
                break;
        }
    }

    private void RollForControl(InputField button,int roll) {
        switch (roll) {
            case 1:
                button.text = "Left Track";
                if (button == wButton) 
                    wControl = 1;
                else if (button == aButton) 
                    aControl = 1;
                else if (button == sButton) 
                    sControl = 1;
                else if (button == dButton) 
                    dControl = 1;
                else if (button == spaceButton) 
                    spaceControl = 1;
                break;
            case 2:
                button.text = "Right Track";
                if (button == wButton) 
                    wControl = 2;
                else if (button == aButton) 
                    aControl = 2;
                else if (button == sButton) 
                    sControl = 2;
                else if (button == dButton) 
                    dControl = 2;
                else if (button == spaceButton) 
                    spaceControl = 2;
                break;
            case 3:
                button.text = "Forward";
                if (button == wButton) 
                    wControl = 3;
                else if (button == aButton) 
                    aControl = 3;
                else if (button == sButton) 
                    sControl = 3;
                else if (button == dButton) 
                    dControl = 3;
                else if (button == spaceButton) 
                    spaceControl = 3;
                break;
            case 4:
                button.text = "Backward";
                if (button == wButton)
                    wControl = 4;
                else if (button == aButton) 
                    aControl = 4;
                else if (button == sButton) 
                    sControl = 4;
                else if (button == dButton)
                    dControl = 4;
                else if (button == spaceButton) 
                    spaceControl = 4;
                break;
            case 5:
                button.text = "Shoot";
                if (button == wButton) 
                    wControl = 5;
                else if (button == aButton) 
                    aControl = 5;
                else if (button == sButton) 
                    sControl = 5;
                else if (button == dButton) 
                    dControl = 5;
                else if (button == spaceButton) 
                    spaceControl = 5;
                break;
        }
    }
}
