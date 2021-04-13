﻿namespace ZafiraIntegration.Client.Requests
{
    public class ArtifactReference
    {
        public string Name { get; }
        public string Value { get; }

        public ArtifactReference(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}