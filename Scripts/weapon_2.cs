using Godot;
using System;

public partial class weapon_2 : weapon
{

	public override void _on_body_entered(Node2D body) {
		
		if(body is enemy en) {
			float force=20;
			Vector2 direction = player.Instance.GlobalPosition.DirectionTo(body.GlobalPosition);
			direction = direction.Normalized();
			en.Knockback(direction, force);
		}
	}
}
