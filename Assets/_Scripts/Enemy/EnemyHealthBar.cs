using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
	[SerializeField] Image imageHP;
	[SerializeField] Gradient color;

	private void Start() {
		imageHP.color = color.Evaluate(1);
		imageHP.fillAmount = 1;
	}

	public void updateHealthBart(float percent) {
		float value = Mathf.Clamp(percent, 0, 1);
		imageHP.color = color.Evaluate(value);
		imageHP.fillAmount = value;
	}

}