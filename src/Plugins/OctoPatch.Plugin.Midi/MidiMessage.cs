﻿using System;
using OctoPatch.ContentTypes;
using OctoPatch.Descriptions;

namespace OctoPatch.Plugin.Midi
{
    /// <summary>
    /// Single message from a midi device
    /// </summary>
    public readonly struct MidiMessage
    {
        /// <summary>
        /// Returns the type description
        /// </summary>
        public static TypeDescription TypeDescription =>
            TypeDescription.Create<MidiMessage>(Guid.Parse(MidiPlugin.PluginId),
                "MIDI Message",
                "Represents a single MIDI message",
                new PropertyDescription(nameof(MessageType), nameof(MessageType), "Contains the message type", new IntegerContentType()),
                new PropertyDescription(nameof(Channel), nameof(Channel), "Contains the channel", new IntegerContentType()),
                new PropertyDescription(nameof(Key), nameof(Key), "Contains the key", new IntegerContentType()),
                new PropertyDescription(nameof(Value), nameof(Value), "Contains the value", new IntegerContentType()));

        /// <summary>
        /// message type
        /// </summary>
        public int MessageType { get; }

        /// <summary>
        /// MIDI Channel
        /// </summary>
        public int Channel { get; }

        /// <summary>
        /// Key
        /// </summary>
        public int Key { get; }

        /// <summary>
        /// Value
        /// </summary>
        public int Value { get; }

        public MidiMessage(int messageType, int channel, int key, int value)
        {
            MessageType = messageType;
            Channel = channel;
            Key = key;
            Value = value;
        }
    }
}
