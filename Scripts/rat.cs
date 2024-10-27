using Godot;
using System;
using System.Numerics;
public partial class rat : CharacterBody2D
{	[Export]
	public float ratHp=1;
	[Export]
	public float ratSpeed=2;
	public void getPlayerPosition() {
		Godot.Vector2 direction=new Godot.Vector2();
		direction=player.Instance.Position-Position;
		direction=direction.Normalized();
		Velocity=direction*ratSpeed;
		MoveAndCollide(Velocity);
	}
	public void _on_area_2d_body_entered(Node body) {
		if(body is Bullet bl) {
			ratHp=ratHp-bl.damage;
		}
	}
	public void checkDead() {
		if(ratHp<=0) {
			QueueFree();
		}
	}
	public override void _Ready()
	{
	}
	public override void _Process(double delta)
	{   
		checkDead();
		getPlayerPosition();
	}
}
