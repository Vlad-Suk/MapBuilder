using System;
using System.Collections.Generic;


namespace MapBuilder
{
    public class MapBuilder
    {
        public IEnumerable<string> BuildRouteMap(IEnumerable<SignStep> signatureMap)
        {
            var start = new SignStep { Floor = 0, Section = 1 };
            foreach (var el in signatureMap)
            {
                if (Stairs(start, el))
                {
                    start = el;
                    yield return "S";
                    continue;
                }
                if (Elevator1(start, el))
                {
                    start = el;
                    yield return "E1";
                    continue;
                }
                if (Elevator2(start, el))
                {
                    start = el;
                    yield return "E2";
                    continue;
                }

            }
        }

        private bool Elevator1(SignStep current, SignStep next)
        {
            var varianceFloor = Math.Abs(current.Floor - next.Floor);
            var varianceSection = Math.Abs(current.Section - next.Section);
            if (next.Floor % 2 == 1 || varianceFloor < 2 || (varianceFloor == 2 && varianceSection == 1))
            {
                return false;
            }
            else
                return true;
        }

        private bool Elevator2(SignStep current, SignStep next)
        {
            var varianceFloor = Math.Abs(current.Floor - next.Floor);
            var varianceSection = Math.Abs(current.Section - next.Section);
            if (next.Floor % 2 == 0 || varianceFloor < 2 || (varianceFloor == 2 && varianceSection == 1))
            {
                return false;
            }
            else
                return true;
        }

        private bool Stairs(SignStep current, SignStep next)
        {
            var varianceFloor = Math.Abs(current.Floor - next.Floor);
            var varianceSection = Math.Abs(current.Section - next.Section);
            if (next.Floor % 2 == 0 && varianceFloor == 2 && varianceSection == 0 && current.Section == 2)
                return true;
            else if (next.Floor % 2 == 1 && varianceFloor == 2 && varianceSection == 0 && current.Section == 1)
                return true;
            else if (Elevator1(current, next) || Elevator2(current, next))
                return false;
            else
                return true;
        }
    }

    public struct SignStep
    {
        public int Floor { get; set; }
        public int Section { get; set; }
    }
}
