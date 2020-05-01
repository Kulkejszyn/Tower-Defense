using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBlueprint standardTurretPrefab;
	public TurretBlueprint laserTurretPrefab;
	public TurretBlueprint missleLauncherPrefab;

	BuildManager buildManager;

	private void Start() {
		buildManager = BuildManager.instance;
	}

	public void selectStandardTurret() {
		buildManager.selectTurretToBuild(standardTurretPrefab);
	}

	public void selectLaserTurret() {
		buildManager.selectTurretToBuild(laserTurretPrefab);
	}

	public void selectMissleLauncher() {
		buildManager.selectTurretToBuild(missleLauncherPrefab);
	}

}