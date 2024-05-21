using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	public static UI instance = null;

	public int Pop {
		get { return pop; }
		set {
			pop = value;
			popNumber.text = pop.ToString ();
		}
	}

	public int Gen {
		get { return gen; }
		set {
			Interlocked.Increment (ref gen);
			genNumber.text = gen.ToString ();
		}
	}

	public int Mut {
		get { return mut; }
		set {
			Interlocked.Increment (ref mut);

			if (value == 0)
				mut = 0;

			mutNumber.text = mut.ToString ();
		}
	}

	public int Hit {
		get { return hit; }
		set {
			Interlocked.Increment (ref hit);

			if (value == 0)
				hit = 0;

			hitNumber.text = hit.ToString ();
		}
	}

	public int Best {
		get { return best; }
		set {
			best = value;
			bestNumber.text = best.ToString ();
		}
	}

	[SerializeField]private Transform main;
	[SerializeField]private Transform ayuda;
	[SerializeField]private Text popNumber, genNumber, mutNumber, hitNumber, bestNumber;

	private int pop, gen, mut, hit, best;

	private void Awake ()
	{
		if (instance == null)
			instance = this;
		if (instance != this)
			Destroy (this.gameObject);

		Screen.SetResolution(600, 600, false);
	}

	private void Update ()
	{
		if (Input.GetKeyDown (KeyCode.I)) {
			main.gameObject.SetActive (!main.gameObject.activeSelf);
			ayuda.gameObject.SetActive (!ayuda.gameObject.activeSelf);
		}

		if (Input.GetKeyDown (KeyCode.R))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);

		if (Input.GetKeyDown (KeyCode.Q))
			Application.Quit ();
	}
}
