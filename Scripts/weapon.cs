using Godot;
using System;

public partial class weapon : Area2D
{
    public WeaponResource res;
    public void Timer() {

        var timer= new Timer();
        AddChild(timer);
        timer.WaitTime=res.timeLimit;
        timer.Start();
        timer.Timeout += _on_timer_timeout;   
    }
    public void _on_timer_timeout() {
        QueueFree();
    }
    public void SetupWeapon(WeaponResource resToSet){
		res = resToSet;
	}
    public override void _Ready() 
    {
        Timer();
        BodyEntered+=_on_body_entered;
    }
    public virtual void _on_body_entered(Node2D body) {
		if(body is enemy en) {
			en.hp -= 1;
		}
	}
}