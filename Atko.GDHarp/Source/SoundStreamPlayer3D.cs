using System;
using Godot;

namespace Atko.GDHarp
{
    class SoundStreamPlayer3D : AudioStreamPlayer3D, ISoundStreamPlayer
    {
        public event Action Finished;

        public Spatial Origin { get; }

        public SoundStreamPlayer3D(Spatial origin)
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