using System;
using Godot;

namespace Atko.GDHarp
{
    class SoundStreamPlayer : AudioStreamPlayer, ISoundStreamPlayer
    {
        public event Action Finished;

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