using System;

namespace Simplist.Core.Domain
{
    public static class GuidMaker
    {
        public static Guid Get(int guidSequence)
        {
            return new Guid(guidSequence, 0, 0, new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0});
        }
    }
}