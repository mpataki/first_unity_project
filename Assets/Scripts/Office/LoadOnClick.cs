﻿using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	public void loadOnClick(int level){
		Application.LoadLevel (level);
	}
}
