using System;

namespace Simplist.Cqrs.Core
{
    public class Burner
    {
        public string Smoke(string target)
        {
            if (target == null) throw new ArgumentNullException(nameof(target));
            return target + " smoked";
        }
    }
}
