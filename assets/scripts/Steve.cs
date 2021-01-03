using Godot;
using System;

public class Steve : KinematicBody
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // [Export] PackedScene asd = null;
    // [Export] int qwe = 1;

    string name = "player";
    Vector3 velocity;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(name);
    }
    public override void _PhysicsProcess(float delta)
    {
        // GD.Print("Hello!");
        if (Input.IsActionPressed("ui_right") && Input.IsActionPressed("ui_left"))
            velocity.x = 0f;
        else if (Input.IsActionPressed("ui_right"))
            velocity.x = 5f;
        else if (Input.IsActionPressed("ui_left"))
            velocity.x = -5f;
        else
            velocity.x = Mathf.Lerp(velocity.x, 0f, 0.1f);

        if (Input.IsActionPressed("ui_up") && Input.IsActionPressed("ui_down"))
            velocity.z = 0f;
        else if (Input.IsActionPressed("ui_up"))
            velocity.z = -5f;
        else if (Input.IsActionPressed("ui_down"))
            velocity.z = +5f;
        else
            velocity.z = Mathf.Lerp(velocity.z, 0f, 0.1f);
        MoveAndSlide(velocity);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}