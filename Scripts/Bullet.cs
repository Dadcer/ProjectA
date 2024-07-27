using Godot;
using System;

public partial class Bullet : CharacterBody2D
{	
	[Export]
	public float damage;
	[Export]
	public float speed;
	Vector2 velocity=new Vector2();
	public void setParameters(float _damage, float _speed ) {
		damage=_damage;
		speed=_speed;
	}
	public void setMoving() 
	{
		velocity.X=velocity.X+speed;
		MoveAndCollide(velocity);
	}
	public override void _Ready()
	{
		
	}
	public override void _Process(double delta)
	{
		setMoving();
		
	}
}
