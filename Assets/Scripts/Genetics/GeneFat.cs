﻿using System;
using UnityEngine;

public class GeneFat : Gene
{
	public GeneFat () : base()
	{
		this.type = Genetics.GeneType.FAT;
	}

	override protected void onValChange(float oldVal, float newVal){
	}
}

