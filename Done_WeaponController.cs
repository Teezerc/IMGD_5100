﻿using UnityEngine;
using System.Collections;

public class Done_WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn1;
    public Transform shotSpawn2;
    public Transform shotSpawn3;
    public float fireRate;
	public float delay;

	void Start ()
	{
		InvokeRepeating ("Fire", delay, fireRate);
	}

	void Fire ()
	{
		Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
        Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        Instantiate(shot, shotSpawn3.position, shotSpawn3.rotation);
        GetComponent<AudioSource>().Play();
	}
}
