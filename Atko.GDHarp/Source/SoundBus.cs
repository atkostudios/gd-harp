using Godot;

namespace Atko.GDHarp
{
    public class SoundBus
    {
        public int Index { get; }

        public string Name => AudioServer.GetBusName(Index);

        Node Root { get; }

        public SoundBus(Node root, int index)
        {
            Root = root;
            Index = index;
        }

        public Sound Play(AudioStreamSample sample, SoundOptions options = default(SoundOptions))
        {
            return new Sound(Root, this, sample, options);
        }
    }
}