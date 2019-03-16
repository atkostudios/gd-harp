using Godot;
using System.Collections.Generic;
using NullGuard;
using System;

namespace Atko.GDHarp
{
    public static class Harp
    {
        public static bool IsLoaded => Root != null;

        public static SoundBus Master => Bus(0);

        [AllowNull]
        static Node Root { get; set; }

        [AllowNull]
        static SoundBus[] Busses { get; set; }

        internal static void Load(Node root)
        {
            Root = root;

            var count = AudioServer.GetBusCount();

            Busses = new SoundBus[count];

            for (int i = 0; i < count; i++)
            {
                Busses[i] = new SoundBus(Root, i);
            }
        }

        internal static void Unload()
        {
            Root = null;
            Busses = null;
        }

        internal static void AssertLoaded()
        {
            if (IsLoaded)
            {
                return;
            }

            throw new GDHarpException("Harp has not been loaded into the scene tree.");
        }

        public static SoundBus Bus(int i)
        {
            AssertLoaded();

            try
            {
                return Busses[i];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Bus index out of range.");
            }
        }

        [return: AllowNull]
        public static SoundBus Bus(string name)
        {
            AssertLoaded();

            foreach (var bus in Busses)
            {
                if (bus.Name == name)
                {
                    return bus;
                }
            }

            return null;
        }
    }
}