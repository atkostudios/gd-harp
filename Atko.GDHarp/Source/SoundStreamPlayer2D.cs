using System;
using System.Diagnostics;
using Godot;

namespace Atko.GDHarp
{
    class SoundStreamPlayer2D : AudioStreamPlayer2D, ISoundStreamPlayer
    {
        public event Action Finished;

        public Node2D Origin => (Node2D)Options.Origin;

        public SoundOptions Options { get; }

        public SoundStreamPlayer2D(SoundOptions options)
        {
            Debug.Assert(options.Origin is Node2D);

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