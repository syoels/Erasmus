﻿using UnityEngine;
using System.Collections;

public class GeneLife : Gene {

	public GeneLife () : base()
	{
		this.type = Genetics.GeneType.LIFE;
	}

	override protected void onValChange(float oldVal, float newVal){
	}
}
