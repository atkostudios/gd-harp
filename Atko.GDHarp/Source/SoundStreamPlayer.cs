using System;
using Godot;

namespace Atko.GDHarp
{
    class SoundStreamPlayer : AudioStreamPlayer, ISoundStreamPlayer
    {
        public event Action Finished;

        public SoundOptions Options { get; }

        public SoundStreamPlayer(SoundOptions options)
        {
            Options = options;
        }

        public override void _Ready()
        {
            Connect("finished", this, nameof(OnEnded));
        }

        void OnEnded()
        {
            Finished?.Invoke();
        }
    }
}