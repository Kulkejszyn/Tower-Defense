using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour {

    public TMPro.TMP_Text moneyText;

    private void Update() {
        moneyText.text = "$" + PlayerStats.money.ToString();
    }

}