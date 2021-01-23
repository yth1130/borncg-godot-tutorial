using Godot;
using System;

public class Counter : Label
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    int coins = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GetNode<Timer>("Timer").Connect("timeout", this, nameof(OnTimeOut));
        Text = coins.ToString();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    void IncreaseCoin()
    {
        coins++;
        // Text = coins.ToString();
        _Ready();

        if (coins == 5)
            GetNode<Timer>("Timer").Start();
    }

    void OnTimeOut()
    {
        GetTree().ChangeScene("res://assets/Menu.tscn");
    }
}
