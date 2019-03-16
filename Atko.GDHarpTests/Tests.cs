using Godot;
using System;
using Atko.GDHarp;

public class Tests : Node
{
    [Export] AudioStreamSample Sample;

    [Export] AudioStreamSample Music;

    Sound MusicInstance { get; set; }

    float StopTimer = 10;

    Node2D Point { get; set; }

    public override void _Ready()
    {
        Point = GetNode<Node2D>(nameof(Point));

        MusicInstance = Harp.Bus(0).Play(Music, new SoundOptions
        {
            Origin = Point
        });
    }

    public override void _Process(float delta)
    {

        StopTimer = Math.Max(StopTimer - delta, 0);
        Point.Position += Vector2.Right * delta * 250;

        if (StopTimer == 0)
        {
            MusicInstance.Stop();
        }
    }
}
