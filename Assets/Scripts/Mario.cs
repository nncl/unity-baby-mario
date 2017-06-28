using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mario : MonoBehaviour {

	public float forcaImpulso;
	public float forcaImpulsoLados;
	bool jogando;
	Rigidbody2D rb;
	Vector3 posicaoInicial;
	float limiteX;
	private int pontos;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
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

	/**
	 * Caso o personagem ultrapasse um dos lados da tela, ele aparece no outro
	 */
	void AtualizaPosicaoPersonagem() {
		// TODO
	}
	
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			IniciaGravidade ();

			rb.velocity = new Vector2 (0.0f, 0.0f);
			rb.AddForce (Vector2.up * forcaImpulso);
		}

		if (Input.GetKey(KeyCode.LeftArrow)) {
			IniciaGravidade();

			rb.AddForce (Vector2.left * forcaImpulsoLados);

			AtualizaPosicaoPersonagem ();
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			IniciaGravidade();

			rb.AddForce (Vector2.right * forcaImpulsoLados);
		}
	}

	void OnTriggerEnter2D (Collider2D c) {
		Debug.Log ("Colidiu");
		Destroy (c.gameObject);
		pontos++;

		if (pontos == 3) {
			SceneManager.LoadScene ("inicio");
		}
	}
}
