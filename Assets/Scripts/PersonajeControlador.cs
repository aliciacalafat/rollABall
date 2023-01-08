using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonajeControlador : MonoBehaviour {

	public float speed;
	public TextMeshProUGUI countText;
	public TextMeshProUGUI winText;

	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Puntos"))
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "" + count.ToString ();
		if (count >= 12)
		{
			winText.text = "Has ganado!";
		}
	}
}
