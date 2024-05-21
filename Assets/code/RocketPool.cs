using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPool : MonoBehaviour
{
	[Header ("Settings")]
	[SerializeField] private float period = 1f;
	[SerializeField] private float launchSpacing = 0.1425f;
	[Header ("References")]
	[SerializeField] private RocketBehaviour[] rocketBehaviours;

	private List<Rocket> pool;
	private float lastIterationTime;

	private void Awake ()
	{
		pool = new List<Rocket> ();
		lastIterationTime = period * 1.2f;

		rocketBehaviours = GetComponentsInChildren<RocketBehaviour> ();
	}

	private void Start ()
	{
		UI.instance.Pop = rocketBehaviours.Length;
		
		foreach (RocketBehaviour r in rocketBehaviours)
			r.gameObject.SetActive (false);

		StartCoroutine (Launch ());
	}

	private void Update ()
	{
		if (Time.time > lastIterationTime + period)
			IteratePool ();
	}

	private void IteratePool ()
	{
		lastIterationTime = Time.time;

		foreach (RocketBehaviour r in rocketBehaviours) {
			if (r.gameObject.activeSelf) {
				return;
			}
		}

		SelectParents ();
		Breed ();

		StartCoroutine (Launch ());
	}

	private void SelectParents ()
	{
		pool.Clear ();
		
		foreach (RocketBehaviour r in rocketBehaviours) {
			float chance = Random.Range (0.001f, 1f); 
			if (chance > r.rocket.fitness) {
				pool.Add (r.rocket);
			}
		}

		do {
			int index = Random.Range (0, rocketBehaviours.Length);

			if (!pool.Contains (rocketBehaviours [index].rocket))
				pool.Add (rocketBehaviours [index].rocket);
		} while (pool.Count < 2);

		#if UNITY_EDITOR
		System.Text.StringBuilder strBuilder = new System.Text.StringBuilder ();

		foreach (Rocket r in pool)
			strBuilder.Append (r.fitness.ToString ("F") + " ");

		strBuilder.Append ("-> " + pool.Count + " parents selected");
		Debug.Log (strBuilder);
		#endif
	}

	private void Breed ()
	{
		int lastParentIndex = pool.Count - 1;

		for (int i = 0; i < rocketBehaviours.Length; i++) {
			if (i < pool.Count) {
				rocketBehaviours [i].rocket = pool [i];
				continue;
			}

			int a = Random.Range (0, pool.Count);
			int b = a;
			do { 
				b = Random.Range (0, pool.Count);
			} while (a == b);

			rocketBehaviours [i].rocket = pool [a].Mate (pool [b]);
		}

		pool.Clear ();
	}

	private IEnumerator Launch ()
	{
		UI.instance.Gen++;
		UI.instance.Hit = 0;
		
		foreach (RocketBehaviour r in rocketBehaviours) {
			r.gameObject.SetActive (true);
			yield return new WaitForSeconds (launchSpacing);
		}
	}
}
