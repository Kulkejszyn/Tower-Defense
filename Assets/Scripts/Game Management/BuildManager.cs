using UnityEngine;

public class BuildManager : MonoBehaviour {
	//singleton pattern
	public static BuildManager instance;
	public NodeUI nodeUI;
	[Header("Turrets")]
	public GameObject standardTurretPrefab;
	public GameObject laserTurretPrefab;
	public GameObject missleLauncherPrefab;
	[Header("Particles")]
	public GameObject buildEffect;
		public GameObject sellEffect;
	private TurretBlueprint turretToBuild;
	private Node selectedNode;

	public bool canBuild { get { return turretToBuild != null; } }
	public bool hasMoney { get { return turretToBuild.cost <= PlayerStats.money; } }

	private void Awake() {
		if (instance != null) {
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public void selectTurretToBuild(TurretBlueprint turret) {
		turretToBuild = turret;
		deselectNode();
	}

	public void selectNode(Node node) {
		if (selectedNode == node) {
			deselectNode();
			return;
		}

		selectedNode = node;
		turretToBuild = null;
		nodeUI.setTarget(node);
	}

	public void deselectNode() {
		selectedNode = null;
		nodeUI.hide();
	}

	public TurretBlueprint getTurretToBuild() {
		return turretToBuild;
	}
}