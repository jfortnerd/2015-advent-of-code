using Jfortnerd.Aod2k15.Dailies;

namespace Aod2k15.Dailies
{
    internal class Day02 : Day
    {
        private const int Length = 0;
        private const int Width = 1;
        private const int Height = 2;

        public override void RunSolution()
        {
            List<int[]> packages = ParseInputSample();
            int squareFeetNeeded = 0;
            int feetRibbonNeeded = 0;

            // calculate square feet needed for wrapping paper
            foreach (int[] package in packages)
            {
                // Add surface area of current package
                squareFeetNeeded += CalculateSurfaceArea(package);

                // Add area of smallest plane of package (rectangular prism)
                squareFeetNeeded += CalculateAreaOfSmallestPlane(package);
            }

            // write out solution
            AppendSolution("The elves need to order " + squareFeetNeeded + " square feet of wrapping paper.");

            // calculate feet needed for ribbon
            foreach (int[] package in packages) 
            {

                // Add the perimeter, where the face selected is the smallest perimeter on the package
                feetRibbonNeeded += CalculateSmallestPerimeter(package);

                // Add the cubic volume of package
                feetRibbonNeeded += CalculateCubicVolume(package);
            }

            // write out solution
            AppendSolution("The elves need to order " + feetRibbonNeeded + "feet of ribbon.");

           
        }

        private List<int[]> ParseInputSample()
        {
            List<int[]> packages = new List<int[]>();

            // parse input sample
            using (StringReader sr = new StringReader(Sample))
            {
                String currLine = sr.ReadLine();

                while (currLine != null)
                {
                    if (currLine != null)
                    {
                        packages.Add(getIntArray(currLine));

                        currLine = sr.ReadLine();
                    }
                }
            }

            return packages;
        }

        private int[] getIntArray(String currLine)
        {
            // parse line into int array
            String[] stringRepPackage = currLine.Split('x');
            int[] package = new int[stringRepPackage.Length];

            for (int i = 0; i < stringRepPackage.Length; i++)
            {
                if (Int32.TryParse(stringRepPackage[i], out package[i]))
                {
                    // do nothing
                }
                else
                {
                    Console.WriteLine("Error: Cannot parse string " + stringRepPackage[i] + " as Int32 for line " + currLine);
                    // Pass file path and name to StreamReader constructor

                    Thread.Sleep(3000);
                    System.Environment.Exit(1);
                }
            }

            return package;
        }

        private int CalculateSurfaceArea(int[] package)
        {
            int surfaceArea = (2 * package[Length] * package[Width]) + (2 * package[Width] * package[Height]) + (2 * package[Length] * package[Height]);
            return surfaceArea;
        }

        private int CalculateAreaOfSmallestPlane(int[] package)
        {
            int[] areas =
            [
                package[Length] * package[Width],
                package[Width] * package[Height],
                package[Length] * package[Height],
            ];

            Array.Sort(areas);

            return areas[0];
        }

        private int CalculateSmallestPerimeter(int[] package)
        {
            int perimeter = 0;
            int[] dimensions = new int[3];

            Array.ConstrainedCopy(package, 0, dimensions, 0, 3);

            Array.Sort(dimensions);

            perimeter = (dimensions[0] * 2) + (dimensions[1] * 2);

            return perimeter;
        }

        private int CalculateCubicVolume(int[] package)
        {
            int product = -1;

            for (int i = 0; i < package.Length; i++)
            {
                if (product == -1)
                {
                    product = i;
                }
                else
                {
                    product *= i;
                }
            }

            return product;
        }
    }
}
