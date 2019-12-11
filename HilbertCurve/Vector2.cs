using System;

namespace HilbertCurve
{
    class Vector2
    {
        public int change;
        public int[] Pos;

        public Vector2(int change = 1)
        {
            this.change = change;
            Pos = new[] { 0, 0 };
        }

        public Vector2(int x, int y, int change = 1)
        {
            this.change = change;
            Pos = new[] { x, y };
        }

        public Vector2(Vector2 vector2, int change = 1)
        {
            this.change = change;
            Pos = new[] { vector2[0], vector2[1] };
        }

        public int this[int i]
        {
            get => Pos[i];
            set => Pos[i] = value;
        }

        public static Vector2[] NewVector2v21D(Vector2[] vector1D)
        {
            Vector2[] newVector1D = new Vector2[vector1D.GetLength(0)];
            for (int i = 0; i < vector1D.GetLength(0); i++) newVector1D[i] = new Vector2(vector1D[i]);
            return newVector1D;
        }

        // Iterately builds a curve
        public static Vector2[] IterateBuildCurve(int times, int change = 1)
        {
            Vector2[] start = { new Vector2(change) };
            for (int i = 0; i < times; i++) start = BuildCurve(start);
            return start;
        }

        // Builds a curve up to the next layer
        public static Vector2[] BuildCurve(Vector2[] input)
        {
            Vector2[] first = RotateX(NewVector2v21D(input));
            Vector2[] second = NewVector2v21D(input);
            Vector2[] third = NewVector2v21D(input);
            Vector2[] fourth = RotateXY(NewVector2v21D(input));
            int length = (int)Math.Sqrt(input.Length);
            // This makes the actual curve
            second = Add(second, 0, input[0].change * length);
            third = Add(third, input[0].change * length, input[0].change * length);
            fourth = Add(fourth, input[0].change * length, 0);
            return Add(first, Add(second, Add(third, fourth)));
        }

        // Does a matrix rotation of a Vector2 array
        public static Vector2[] RotateX(Vector2[] input)
        {
            int length = input.GetLength(0);

            if (length == 1) return input;

            // Recursive calls might be able to refactor to iterative loops
            Vector2[] first = RotateX(SubArray(input, 0, length / 4));
            Vector2[] second = RotateX(SubArray(input, length / 4 * 3, length / 4));
            Vector2[] third = RotateX(SubArray(input, length / 2, length / 4));
            Vector2[] fourth = RotateX(SubArray(input, length / 4, length / 4));

            fourth = RotateXY(fourth);
            second = RotateXY(second);

            return Add(first, Add(second, Add(third, fourth)));
        }

        // Does a matrix rotation of a Vector2 array
        public static Vector2[] RotateXY(Vector2[] input)
        {
            int length = input.GetLength(0);

            if (length == 1) return input;

            // Recursive calls might be able to refactor to iterative loops
            Vector2[] first = RotateXY(SubArray(input, length / 2, length / 4));
            Vector2[] second = RotateXY(SubArray(input, length / 4, length / 4));
            Vector2[] third = RotateXY(SubArray(input, 0, length / 4));
            Vector2[] fourth = RotateXY(SubArray(input, length / 4 * 3, length / 4));

            first = RotateX(first);
            third = RotateX(third);

            return Add(first, Add(second, Add(third, fourth)));
        }

        // Adds an offset to all elements in a Vector2 array
        public static Vector2[] Add(Vector2[] input, int x, int y)
        {
            Vector2[] newVector2 = new Vector2[input.GetLength(0)];
            for (int i = 0; i < input.GetLength(0); i++) newVector2[i] = Add(input[i], x, y);
            return newVector2;
        }

        // Adds an offset to a Vector2 object
        public static Vector2 Add(Vector2 input, int x, int y)
        {
            return new Vector2(input[0] + x, input[1] + y);
        }

        // Allocates a new Vector2 array and appends the left and right to it
        public static Vector2[] Add(Vector2[] left, Vector2[] right)
        {
            Vector2[] output = new Vector2[left.GetLength(0) + right.GetLength(0)];
            for (int i = 0; i < output.GetLength(0); i++)
            {
                if (i < left.GetLength(0)) output[i] = left[i];
                else output[i] = right[i - left.GetLength(0)];
            }

            return output;
        }

        // Returns new array based on the index and length arguments
        public static Vector2[] SubArray(Vector2[] data, int index, int length)
        {
            Vector2[] result = new Vector2[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}