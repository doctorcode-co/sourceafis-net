using System;
using System.Collections.Generic;
using System.Text;
using SourceAFIS.General;
using SourceAFIS.Extraction.Templates;

namespace SourceAFIS.Matching.Minutia
{
    public sealed class RootPairSelector
    {
        public DetailLogger.Hook Logger = DetailLogger.Null;

        public IEnumerable<MinutiaPair> GetRoots(Template probeTemplate, Template candidateTemplate)
        {
            for (int probe = 0; probe < probeTemplate.Minutiae.Length; ++probe)
                for (int candidate = 0; candidate < candidateTemplate.Minutiae.Length; ++candidate)
                {
                    int mixedProbe = (probe + candidate) % probeTemplate.Minutiae.Length;
                    var pair = new MinutiaPair(mixedProbe, candidate);
                    if (Logger.IsActive)
                        Logger.Log(pair);
                    yield return pair;
                }
        }
    }
}
