using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataValidator.Plate
{
    public class CheckPlate : ICheckPlate
    {
        private readonly Regex _brazilRgx;
        private readonly Regex _mercosulRgx;

        /// <summary>
        /// Base ctor
        /// </summary>
        public CheckPlate()
        {
            _brazilRgx = new Regex(@"(\b([A-Z]|[a-z]){3}([/]|[\-]|[.]|[_]|[\s])*([\d]{4}))", RegexOptions.IgnoreCase);
            _mercosulRgx = new Regex(@"(\b(?i)([a-z]{3}([/]|[\-]|[.]|[_]|[\s])*\d([\/]|[\-]|[.]|[_]|[\s])*[a-z]([\/]|[\-]|[.]|[_]|[\s])*[\d]{2})\b)", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Extracts a possible plate from a sentence/text block and checks if the format is 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Plate ExtractAndCheckPlate(string text)
        {
            var coll = _brazilRgx.Matches(text);
            var plateType = PlateTypes.Brazil;
            if (coll.Count <= 0 || coll[0].Groups.Count <= 0)
            {
                coll = _mercosulRgx.Matches(text);
                if (coll.Count <= 0 || coll[0].Groups.Count <= 0)
                {
                    return new Plate();
                }
                plateType = PlateTypes.Mercosul;
            }

            var result = coll[0].Groups[0].Value;

            return new Plate(ExtractPlate(result), IsValid(result), plateType);
        }

        /// <summary>
        /// Checks if an already extracted plate is valid or not
        /// </summary>
        /// <param name="plate"></param>
        /// <returns></returns>
        public bool IsValid(string plate)
        {
            plate = ExtractPlate(plate);

            return (_brazilRgx.IsMatch(plate) || _mercosulRgx.IsMatch(plate));
        }

        private static string ExtractPlate(string text)
        {
            var plate = text.Replace("-", "").Replace(".", "").Replace("/", "").Replace("_", "").Replace(" ", "").Trim();
            return plate.ToUpper();
        }
    }
}
