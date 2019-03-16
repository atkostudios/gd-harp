using System;
using Godot;

namespace Atko.GDHarp
{
    class SoundStreamPlayer2D : AudioStreamPlayer2D, ISoundStreamPlayer
    {
        public event Action Finished;

        public Node2D Origin { get; }

        public SoundStreamPlayer2D(Node2D origin)
        {
            Origin = origin;
        }

        public override void _Ready()
        {
            Connect("finished", this, nameof(OnEnded));
        }

        public override void _Process(float delta)
        {
            GlobalTransform = Origin.GlobalTransform;
        }

        void OnEnded()
        {
            Finished?.Invoke();
        }
    }
}