using Godot;
using System;

public partial class Marker : Node2D
{
	public void GetPosition() {
		GlobalPosition=GetGlobalMousePosition();
	}
	public override void _Process(double delta)
	{
		
		GetPosition();
		
	}
}
