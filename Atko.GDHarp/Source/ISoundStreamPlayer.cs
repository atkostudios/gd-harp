using System;
using Godot;

namespace Atko.GDHarp
{
    interface ISoundStreamPlayer
    {
        event Action Finished;

        bool Autoplay { get; set; }

        AudioStream Stream { get; set; }

        string Name { get; set; }

        string Bus { get; set; }

        void Play(float fromPosition = 0);

        void Stop();
    }
}