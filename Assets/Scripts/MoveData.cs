﻿using RubiksCube;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class used to save game data
/// </summary>
[System.Serializable]
public class MoveData
{
	public int cubeDimension;
	public string[] axis;
	public float[] angle;
	public int[] index;

	/// <summary>
	/// Convert queue of moves to MoveData
	/// </summary>
	/// <param name="moves"></param>
	public MoveData(Queue<Move> moves)
	{
		cubeDimension = PlayerSettings.CubeDimension;
		axis = new string[moves.Count];
		angle = new float[moves.Count];
		index = new int[moves.Count];

		int i = 0;

		foreach(Move move in moves)
		{
			axis[i] = move.Axis.ToString();
			angle[i] = move.Angle;
			index[i] = move.Index;
			i++;
		}
	}

	/// <summary>
	/// Convert Movedata to Queue of moves
	/// </summary>
	/// <returns></returns>
	public Queue<Move> ToQueue()
	{
		Queue<Move> moves = new Queue<Move>();

		for (int i = 0; i < axis.Length; i++)
		{
			moves.Enqueue(new Move(
				(RotationAxis)Enum.Parse(typeof(RotationAxis), axis[i], true), 
				angle[i], 
				index[i]
			));
		}
		
		return moves;
	}
}
