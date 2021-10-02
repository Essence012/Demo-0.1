using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bullet : MonoBehaviour
{


	void Start()
	{
		Destroy(gameObject, 1.5f);
	}

	/*
	 TODO with that mix
	 */
}
