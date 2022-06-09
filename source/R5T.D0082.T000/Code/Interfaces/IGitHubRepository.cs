using System;


namespace R5T.D0082.T000
{
    public interface IGitHubRepository
    {
        string Description { get; }
        string Name { get; }
        bool IsPrivate { get; }
    }
}
