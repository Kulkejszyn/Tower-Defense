using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour {

	public Color hoverColor;
	public Color cantBuildHoverColor;

	[HideInInspector]
	public GameObject turret;
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	[HideInInspector]
	public bool isUpgraded = false;

	private Renderer rend;
	BuildManager buildManager;
	private Color baseColor;

	public int sellCost { get { return isUpgraded ? (turretBlueprint.upgradeCost + turretBlueprint.cost) / 2 : turretBlueprint.cost / 2; } }

	void Start() {
		turret = null;
		buildManager = BuildManager.instance;
		rend = GetComponent<Renderer>();
		baseColor = rend.material.GetColor("_BaseColor");
	}

	public Vector3 getBuildPosition() {
		Vector3 offset = new Vector3(0, rend.bounds.size.y, 0);
		return transform.position + offset;
	}

	public void upgradeTurret() {
		if (PlayerStats.money < turretBlueprint.upgradeCost) {
			Debug.Log("not enough money to upgrade");
			return;
		}
		Quaternion rotation = this.turret.GetComponent<Turret>().partToRotate.transform.rotation;
		Destroy(this.turret);
		GameObject turret = (GameObject) Instantiate(turretBlueprint.upgradedPrefab, getBuildPosition(), Quaternion.identity);
		turret.GetComponent<Turret>().partToRotate.transform.rotation = rotation;

		GameObject buildParticles = (GameObject) Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
		Destroy(buildParticles, 3f);
		isUpgraded = true;
		this.turret = turret;
		PlayerStats.money -= turretBlueprint.upgradeCost;
		Debug.Log("Turret Upgarded!");
	}

	public void sellTurret() {
		Destroy(turret);
		turret = null;
		PlayerStats.money += sellCost;
		GameObject sellEffect = (GameObject) Instantiate(buildManager.sellEffect, getBuildPosition(), Quaternion.identity);
		Destroy(sellEffect, 5f);
		isUpgraded = false;
	}

	void buildTurret(TurretBlueprint turretBlueprint) {
		if (PlayerStats.money < turretBlueprint.cost) {
			Debug.Log("not enough money");
			return;
		}

		GameObject turret = (GameObject) Instantiate(turretBlueprint.prefab, getBuildPosition(), Quaternion.identity);
		GameObject buildParticles = (GameObject) Instantiate(buildManager.buildEffect, getBuildPosition(), Quaternion.identity);
		Destroy(buildParticles, 2);
		this.turret = turret;
		this.turretBlueprint = turretBlueprint;
		PlayerStats.money -= turretBlueprint.cost;
	}

	void setColor(Color color) {
		rend.material.SetColor("_BaseColor", color);
	}

	void OnMouseEnter() {
		if (EventSystem.current.IsPointerOverGameObject())
			return;
		if (!buildManager.canBuild)
			return;
		if (buildManager.hasMoney)
			setColor(hoverColor);
		else
			setColor(cantBuildHoverColor);
	}

	void OnMouseExit() {
		setColor(baseColor);
	}

	void OnMouseDown() {
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (turret != null) {
			buildManager.selectNode(this);
			return;
		}

		if (!buildManager.canBuild)
			return;

		buildTurret(buildManager.getTurretToBuild());
	}
}