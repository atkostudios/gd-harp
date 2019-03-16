
using Godot;

namespace Atko.GDHarp
{
    public class HarpPluginBase : Node
    {
        public override void _EnterTree()
        {
            Harp.Load(this);
        }

        public override void _ExitTree()
        {
            Harp.Unload();
        }
    }
}