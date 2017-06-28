using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour {

	public float forcaImpulso;
	public float forcaImpulsoLados;
	bool jogando;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			if (!jogando) {
				rb.gravityScale = 1.0f;
				jogando = true;
			}

			rb.velocity = new Vector2 (0.0f, 0.0f);
			rb.AddForce (Vector2.up * forcaImpulso);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce (Vector2.left * forcaImpulsoLados);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			rb.AddForce (Vector2.right * forcaImpulsoLados);
		}
	}
}
