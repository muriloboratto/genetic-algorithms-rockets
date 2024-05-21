using System.Threading;
using UnityEngine;

[System.Serializable]
public class Rocket
{
	const int MINLEFT = 1, MAXLEFT = 30;
	const int MINCENTER = 4, MAXCENTER = 30;
	const int MINRIGHT = 1, MAXRIGHT = 30;
	const float MUTATIONRATE = 0.03f;

	static System.Random Rand {
		get { 
			if (_rand == null)
				_rand = new System.Random ();
			
			return _rand; 
		}
	}

	public readonly int[] dna;

	public float fitness;

	private static int mutations = 0;
	private static System.Random _rand;

	public Rocket ()
	{
		dna = new int[3];

		dna [0] = Rand.Next (MINLEFT, MAXLEFT);
		dna [1] = Rand.Next (MINCENTER, MAXCENTER);
		dna [2] = Rand.Next (MINRIGHT, MAXRIGHT);

		fitness = 1f;
	}

	public Rocket (int[] dna)
	{
		if (dna.Length == 3)
			this.dna = dna;

		fitness = 1f;
	}

	public Rocket Mate (Rocket pair)
	{
		int[] offspringDna = new int[3];

		for (int i = 0; i < 3; i++) {
			bool mutate = Random.Range (0f, 1f) < MUTATIONRATE;
			bool parent = Random.Range (0f, 1f) < 0.5f;

			if (parent)
				offspringDna [i] = dna [i];
			else
				offspringDna [i] = pair.dna [i];
			
			if (mutate) {
				switch (i) {
				case 0:
					dna [0] = Random.Range (MINLEFT, MAXLEFT);
					break;
				case 1:
					dna [1] = Random.Range (MINCENTER, MAXCENTER);
					break;
				case 2:
					dna [2] = Random.Range (MINRIGHT, MAXRIGHT);
					break;
				}

				UI.instance.Mut++;
			}
		}

		return new Rocket (offspringDna);
	}
}
