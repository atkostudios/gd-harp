using Godot;

namespace Atko.GDHarp
{
    public class Sound
    {
        public SoundBus Bus { get; }

        public AudioStreamSample Sample { get; }

        public SoundOptions Options { get; }

        public bool IsStopped => Player == null;

        Node Root { get; }

        ISoundStreamPlayer Player { get; set; }

        internal Sound(Node root, SoundBus bus, AudioStreamSample sample, SoundOptions options = null)
        {
            Bus = bus;
            Sample = sample;
            Options = options ?? new SoundOptions();
            Root = root;
            Player = CreatePlayer();

            Root.AddChild((Node)Player);

            Player.Play();
        }

        public void Stop()
        {
            if (IsStopped)
            {
                return;
            }

            Player.Stop();
            Root.RemoveChild((Node)Player);
            Player = null;
        }

        ISoundStreamPlayer CreatePlayer()
        {
            ISoundStreamPlayer instance;

            if (Options.Origin is Node2D origin2D)
            {
                instance = new SoundStreamPlayer2D(Options);
            }
            else if (Options.Origin is Spatial origin3D)
            {
                instance = new SoundStreamPlayer3D(Options);
            }
            else
            {
                instance = new SoundStreamPlayer(Options);

            }

            instance.Stream = Sample;
            instance.Name = Bus.Name + "-" + Sample.ResourcePath.Replace('/', '-');
            instance.Bus = Bus.Name;

            instance.Finished += Stop;

            return instance;
        }
    }
}