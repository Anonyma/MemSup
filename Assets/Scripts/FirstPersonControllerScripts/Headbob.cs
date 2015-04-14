using UnityEngine;
using System.Collections;

public class Headbob : MonoBehaviour {

	public enum BobType { Key, Time, External };
	public BobType type = BobType.Key;

	public float headbobSpeed = 10f;
	public float headbobHeight = 0.05f;

	private float headbobLevel = 0f;
	private Vector3 basePosition;

	// Use this for initialization
	void Start () {
		basePosition = transform.localPosition;
	}

	public void bob() {
		Vector3 pos = basePosition;
		headbobLevel += headbobSpeed * Time.deltaTime;
		pos.y += headbobHeight * Mathf.Sin(headbobLevel);
		transform.localPosition = pos;
	}

	// Update is called once per frame
	void Update () {
		switch (type) {
			case BobType.Key:
				if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
					bob();
				}
			break;
			case BobType.Time:
				bob();
			break;
		}
	}
}
