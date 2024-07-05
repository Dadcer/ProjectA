using Godot;
using System;

public partial class Camera2D : Godot.Camera2D
{
	public Node2D target;
	public void CameraSet() {
		if(target!=null) 
		{
			Position=target.Position-Offset;
		}	
	}
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CameraSet();
	}
}
