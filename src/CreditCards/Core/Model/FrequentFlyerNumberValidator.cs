using System;
using System.Globalization;
using System.Linq;

namespace CreditCards.Core.Model
{
    public class FrequentFlyerNumberValidator
    {
        readonly char[] _validSchemeIdentifiers = { 'A', 'Q', 'Y' };
        const int ExpectedTotalLength = 8;
        const int ExpectedMemberNumberLength = 6;

        public bool IsValid(string frequentFlyerNumber)
        {
            if (frequentFlyerNumber is null)
            {
                throw new ArgumentNullException(nameof(frequentFlyerNumber));
            }

            if (frequentFlyerNumber.Length != ExpectedTotalLength)
            {
                return false;
            }

            var memberNumberPart = frequentFlyerNumber.Substring(0, ExpectedMemberNumberLength);

            if (!int.TryParse(memberNumberPart, NumberStyles.None, null, out int _))
            {
                return false;
            }

            var schemeIdentifier = frequentFlyerNumber.Last();
            return _validSchemeIdentifiers.Contains(schemeIdentifier);
        }
    }
}
