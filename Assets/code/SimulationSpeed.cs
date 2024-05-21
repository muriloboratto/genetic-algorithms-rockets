using UnityEngine;

public class SimulationSpeed : MonoBehaviour
{
	private int[] values = { 1, 2, 4, 8, 16 };
	private int index;

	private void Update ()
	{
		if (Input.GetKeyDown (KeyCode.M))
			index++;
		if (Input.GetKeyDown (KeyCode.N))
			index--;

		index = Mathf.Clamp (index, 0, values.Length - 1);
		Time.timeScale = (float)values [index];
	}
}
