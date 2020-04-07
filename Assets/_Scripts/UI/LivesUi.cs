using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesUi : MonoBehaviour {
    public TMPro.TMP_Text livesText;

    private void Update() {
        livesText.text = PlayerStats.lives + " LIVES";
    }

}