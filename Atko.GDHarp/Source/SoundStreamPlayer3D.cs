using System;
using System.Diagnostics;
using Godot;

namespace Atko.GDHarp
{
    class SoundStreamPlayer3D : AudioStreamPlayer3D, ISoundStreamPlayer
    {
        public event Action Finished;

        public Spatial Origin => (Spatial)Options.Origin;

        public SoundOptions Options { get; }

        public SoundStreamPlayer3D(SoundOptions options)
        {
            Debug.Assert(options.Origin is Spatial);

            Options = options;
        }

        public override void _Ready()
        {
            Connect("finished", this, nameof(OnEnded));
            UpdateTransform();
        }

        public override void _Process(float delta)
        {
            UpdateTransform();
        }

        void UpdateTransform()
        {
            if (Options.Follows)
            {
                GlobalTransform = Origin.GlobalTransform;
            }
        }

        void OnEnded()
        {
            Finished?.Invoke();
        }
    }
}