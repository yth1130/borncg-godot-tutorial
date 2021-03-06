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

    const float speed = 12f;
    const float rotateSpeed = 9f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(name);
        
        GetNode<Area>("../Enemy1").Connect("body_entered", this, nameof(OnEnemyEntered));

    }
    public override void _PhysicsProcess(float delta)
    {
        // GD.Print("Hello!");
        if (Input.IsActionPressed("ui_right") && Input.IsActionPressed("ui_left"))
            velocity.x = 0f;
        else if (Input.IsActionPressed("ui_right"))
        {
            // Rotate(Vector3.Up, 5);
            GetNode<MeshInstance>("MeshInstance").RotateZ(Mathf.Deg2Rad(-rotateSpeed));
            velocity.x = +speed;
        }
        else if (Input.IsActionPressed("ui_left"))
        {
            GetNode<MeshInstance>("MeshInstance").RotateZ(Mathf.Deg2Rad(+rotateSpeed));
            velocity.x = -speed;
        }
        else
            velocity.x = Mathf.Lerp(velocity.x, 0f, 0.1f);

        if (Input.IsActionPressed("ui_up") && Input.IsActionPressed("ui_down"))
            velocity.z = 0f;
        else if (Input.IsActionPressed("ui_up"))
        {
            GetNode<MeshInstance>("MeshInstance").RotateX(Mathf.Deg2Rad(-rotateSpeed));
            velocity.z = -speed;
        }
        else if (Input.IsActionPressed("ui_down"))
        {
            GetNode<MeshInstance>("MeshInstance").RotateX(Mathf.Deg2Rad(+rotateSpeed));
            velocity.z = +speed;
        }
        else
            velocity.z = Mathf.Lerp(velocity.z, 0f, 0.1f);
        MoveAndSlide(velocity);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    void OnEnemyEntered(Node enemy)
    {
        if (enemy.Name != "Steve")
            return;

        // GD.Print(enemy.Name);
        GetTree().ChangeScene("res://assets/Menu.tscn");
    }
}
