using Godot;
using System;

public class Coin : Area
{
    [Signal] public delegate void coin_collected();

    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Timer>("Timer").Connect("timeout", this, nameof(OnTimeOut));
        Connect("body_entered", this, nameof(OnBodyEntered));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {
        RotateY(Mathf.Deg2Rad(3));
    }

    void OnBodyEntered(Node body)
    {
        if (body.Name == "Steve")
        {
            GD.Print("collect");
            GetNode<Timer>("Timer").Start();
            GetNode<AnimationPlayer>("AnimationPlayer").Play("bounce");
        }
    }

    void OnTimeOut()
    {
        EmitSignal("coin_collected");
        QueueFree();
    }
}
