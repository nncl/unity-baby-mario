using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour {

	public float forcaImpulso;
	public float forcaImpulsoLados;
	bool jogando;
	Rigidbody2D rb;
	SpriteRenderer sr;
	Vector3 posicaoInicial;
	float limiteX;
	private int pontos;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		sr = GetComponent<SpriteRenderer> ();
		rb.gravityScale = 0.0f;
		pontos = 0;

		posicaoInicial = transform.position;
		limiteX = posicaoInicial.x * -1;
	}

	void IniciaGravidade() {
		if (!jogando) {
			rb.gravityScale = 1.0f;
			jogando = true;
		}
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			IniciaGravidade ();

			rb.velocity = new Vector2 (0.0f, 0.0f);
			rb.AddForce (Vector2.up * forcaImpulso);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			sr.flipX = false;
			IniciaGravidade();
			rb.AddForce (Vector2.left * forcaImpulsoLados);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			sr.flipX = true;
			IniciaGravidade();
			rb.AddForce (Vector2.right * forcaImpulsoLados);
		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		if (c.gameObject.tag == "parede" && rb.position.x < 0) {
			Debug.Log ("Colidiu com parede esquerda");
			transform.position = new Vector2 (2.44f, transform.position.y);

		} else if ((c.gameObject.tag == "parede" && rb.position.x > 0)){
			Debug.Log ("Colidiu com parede direita");
			transform.position = new Vector2 (-2.48f, transform.position.y);

		} else {
			Destroy (c.gameObject);
			pontos++;

			if (pontos == 3) {
				SceneManager.LoadScene ("inicio");
			}
		}
	}
}
