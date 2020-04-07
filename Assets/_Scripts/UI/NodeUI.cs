using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour {
	public GameObject ui;

	private Node node;
	[SerializeField]
	public TMPro.TMP_Text upgradeText;
	[SerializeField]
	public Button upgradeButton;
	[SerializeField]
	public TMPro.TMP_Text sellText;

	public void setTarget(Node node) {
		this.node = node;
		transform.position = node.getBuildPosition();

		upgradeText.text = string.Format("<b>UPGRADE</b>\n${0}", node.turretBlueprint.upgradeCost);
		if (node.isUpgraded) {
			upgradeText.text = "<b>UPGRADED</b>";
		}
		upgradeButton.interactable = !node.isUpgraded;
		sellText.text = string.Format("<b>SELL</b>\n${0}", node.sellCost);
		ui.SetActive(true);
	}

	public void hide() {
		ui.SetActive(false);
	}

	public void upgrade() {
		node.upgradeTurret();
		BuildManager.instance.deselectNode();
	}

	public void sell() {
		node.sellTurret();
		BuildManager.instance.deselectNode();
	}

}