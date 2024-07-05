using Godot;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;

public partial class Hand : Node2D
{
	public bool attackTimerCheck=true;

	public void attackDetect() {
		if(Input.IsActionJustPressed("attack")&&attackTimerCheck==true) {
			var weaponScene = player.Instance.CurrentWeaponRes.scene;
			weapon weapon=(weapon)weaponScene.Instantiate();
			weapon.SetupWeapon(player.Instance.CurrentWeaponRes);
			
			weapon.Position = Position;
			weapon.Rotation = Rotation;
			GetParent().AddChild(weapon);
			timerActivate();
		}
	}
	public void timerActivate() {
		var timer=GetNode<Timer>("Timer");
		timer.Start();
		attackTimerCheck=false;
	}
	public void _on_timer_timeout() {
		attackTimerCheck=true;
	}
	public override void _Ready()
	{

		}
	public override void _Process(double delta)
	{
		attackDetect();
	}
}
