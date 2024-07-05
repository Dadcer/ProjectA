using Godot;
using System;

public partial class Cursor : Area2D
{
	[Export]
	public player plr;
	[Export]
	public Node2D sprite;
	public Godot.Collections.Array<enemy> enemies=new Godot.Collections.Array<enemy>();

	public void mouseGet() {
		GlobalPosition=GetGlobalMousePosition();
	}
	public void CheckBodies() {
		enemies.Clear();
		sprite.Scale = Vector2.One;
		foreach (var body in GetOverlappingBodies())
		{
			if(body is enemy en) {
				enemies.Add(en);
				sprite.Scale = Vector2.One*5;
			}
			
		}
		if(enemies.Count>0) {
			if(Input.IsActionJustPressed("mouseClickLeft")) 
			{
				plr.attack();
			}
		}
	}
	public override void _Process(double delta)
	{
		mouseGet();
		CheckBodies();
	}
}
