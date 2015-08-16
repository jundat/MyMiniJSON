using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Reflection;
using MiniJSON;

public class Friend {
	public string name;
	public int year;
	public Dictionary<int, User> dict = new Dictionary<int, User> ();
	public List<User> lst = new List<User> ();
	public User[] arr = new User[2];

	public Friend () {}

	public Friend (string n, int y) {
		name = n;
		year = y;

		dict.Add (1, new User (11, "User11"));
		dict.Add (2, new User (22, "User22"));

		lst.Add (new User (3, "User3"));
		lst.Add (new User (4, "User4"));

		arr[0] = new User (5, "User5");
		arr[1] = new User (6, "User6");
	}
}

public class Vec3 {
	public float x;
	public float y;
	public float z;

	public Vec3 () {}

	public Vec3 (float xx, float yy, float zz) {
		x = xx;
		y = yy;
		z = zz;
	}
}

public class User {
	public int id;
	public string name;
	public Dictionary<int,Vec3> fs = new Dictionary<int,Vec3> ();

	public User () {}

	public User (int i, string n) {
		id = i;
		name = n;
		fs.Add (1, new Vec3(1.23f, 2.34f, 3.45f));
		fs.Add (2, new Vec3(4, 5, 6));
	}
}

public class Demo : MonoBehaviour {

	public Text text;

	void Start () {}
	void Update () {}

	public void OnClick1 () {
		Friend f1 = new Friend ("Pham Tan Long", 12);
		string s1 = MiniJSON.Json.Serialize (f1);
		Debug.Log (s1);
		Friend f2 = MiniJSON.Json.Deserialize <Friend> (s1);
		if (f2 != null) {
			Debug.Log (MiniJSON.Json.Serialize (f2));
		} else {
			Debug.LogError ("Can not parse");
		}
	}
}
