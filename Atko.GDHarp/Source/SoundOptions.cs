using Godot;
using NullGuard;

namespace Atko.GDHarp
{
    public class SoundOptions
    {
        [AllowNull]
        public Node Origin { get; set; }

        public bool Follows { get; set; } = true;
    }
}