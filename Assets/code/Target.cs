using UnityEngine;

public class Target : MonoBehaviour
{
	[SerializeField]private Camera cam;

	private static Vector3 persistentPosition = new Vector3 (1.5f, 5f, 0f);

	private void Start ()
	{
		transform.position = persistentPosition;
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			
			Vector3 newTarget = cam.ScreenToWorldPoint (Input.mousePosition);
			Debug.Log (newTarget);
			newTarget.z = 0f;
				
			persistentPosition = newTarget;
			transform.position = newTarget;

			UI.instance.Best = 0;
		}
	}
}
