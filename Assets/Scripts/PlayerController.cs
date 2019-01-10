using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;


public class PlayerController : MonoBehaviour {
	public Transform graphics;
	public SkeletonAnimation skeleton;
	public float speed = 5f;
	public float jumpPower = 10f;

	Rigidbody2D rb2d;
	float x, y;
	Transform trans;


	private void Start()
	{
		trans	= transform;
		rb2d	= GetComponent<Rigidbody2D>();
	}


	void Update () {
		x = Input.GetAxis("Horizontal") * speed;
		y = rb2d.velocity.y;
		if (Input.GetButtonDown("Jump"))
		{
			y = jumpPower;
		}

		if(x > 0 )
		{
			SetAnimation("walk", true);
			if(graphics.eulerAngles.y == 180)
				graphics.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else if(x < 0 )
		{
			SetAnimation("walk", true);
			if(graphics.eulerAngles.y == 0)
				graphics.localRotation = Quaternion.Euler(0, 180, 0);
		}
		else
		{
			SetAnimation("idle", true);
		}

		rb2d.velocity = new Vector2(x, y);
	}

	string strAniName = "";
	void SetAnimation(string _name, bool _loop)
	{
		if (strAniName.Equals(_name))
		{
			return;
		}

		//Debug.Log(_name);
		skeleton.state.SetAnimation(0, _name, _loop);
		strAniName = _name;
	}
}
