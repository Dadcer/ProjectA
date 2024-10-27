using Godot;
using System;

public partial class Bullet : CharacterBody2D
{	
	[Export]
	public float damage;
	[Export]
	public float speed=10;
	[Export]
	Vector2 velocity=new Vector2();
	public Vector2 direction=new Vector2();
	public void setParameters(float _damage, float _speed, Vector2 _mousePosition ) {
		damage=_damage;
		speed=_speed;
		direction=_mousePosition-Position;
		LookAt(_mousePosition);
	}
	
		public override void _Ready()
	{
		
	}
	public override void _Process(double delta)
	{
	
	}
	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
		direction=direction.Normalized();
		Velocity=direction*speed;
		MoveAndCollide(Velocity);
	}
}
