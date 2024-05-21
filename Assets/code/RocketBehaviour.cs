using UnityEngine;

public class RocketBehaviour : MonoBehaviour
{
	const float TURNINGFORCEFACTOR = 0.01f;

	[HideInInspector]public Rocket rocket;

	[Header ("Thrusters")]
	[SerializeField] private Transform left;
	[SerializeField] private Transform center;
	[SerializeField] private Transform right;
	[Header ("Settings")]
	[SerializeField] private float thrusterForce = 300f;
	[SerializeField] private int rocketLifeTime = 600;
	[Header ("References")]
	[SerializeField] private Transform target;
	[SerializeField] private Rigidbody2D rb2D;
	[SerializeField] private string geneInfo;

	private Vector3 startingPosition = new Vector3 (0f, -1.35f, 0f);
	private bool tLeft, tCenter, tRight;
	private int frame;

	private void OnEnable ()
	{
		frame = 0;
		rocket.fitness = 1f;
	}

	private void OnDisable ()
	{
		rb2D.velocity = Vector3.zero;
		transform.position = startingPosition;
		transform.rotation = Quaternion.identity;
	}

	private void OnBecameInvisible ()
	{
		gameObject.SetActive (false);
	}

	private void FixedUpdate ()
	{
		frame++;
		UpdateFitness ();

		if (frame > rocketLifeTime)
			gameObject.SetActive (false);

		CheckThrusters ();
		ApplyThrust ();

		#if UNITY_EDITOR
		UpdateGeneInfo ();
		#endif
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag ("Finish")) {
			gameObject.SetActive (false);
			rocket.fitness = 0f;
			UpdateGeneInfo ();

			UI.instance.Hit++;
			if (UI.instance.Hit > UI.instance.Best)
				UI.instance.Best = UI.instance.Hit;
		}
	}

	private void CheckThrusters ()
	{
		tLeft = ((int)(frame % rocket.dna [0])) == 0;
		tCenter = ((int)(frame % rocket.dna [1])) == 0;
		tRight = ((int)(frame % rocket.dna [2])) == 0;
	}

	private void ApplyThrust ()
	{
		if (tCenter)
			rb2D.AddForce (thrusterForce * transform.up);
		if (tLeft)
			rb2D.AddForceAtPosition ((left.localPosition - transform.localPosition) * thrusterForce * TURNINGFORCEFACTOR, left.position);
		if (tRight)
			rb2D.AddForceAtPosition ((right.localPosition - transform.localPosition) * thrusterForce * TURNINGFORCEFACTOR, right.position);

		tLeft = false;
		tCenter = false;
		tRight = false;
	}

	private void UpdateFitness ()
	{
		float maxDistance = Vector3.Distance (startingPosition, target.position);
		float distance = Vector3.Distance (transform.position, target.position);
		float frameFitness = Mathf.Pow (distance / maxDistance, 1 / 3f);

		rocket.fitness = frameFitness < rocket.fitness ? frameFitness : rocket.fitness;
	}

	private void UpdateGeneInfo ()
	{
		geneInfo = rocket.dna [0] + " " + rocket.dna [1] + " " + rocket.dna [2] + " fit: " + rocket.fitness;
	}
}
