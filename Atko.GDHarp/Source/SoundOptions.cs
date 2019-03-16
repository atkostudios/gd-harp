using Godot;
using NullGuard;

namespace Atko.GDHarp
{
    public struct SoundOptions
    {
        [AllowNull]
        public Node Origin { get; set; }
    }
}