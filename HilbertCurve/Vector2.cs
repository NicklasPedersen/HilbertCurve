using System;

namespace HilbertCurve
{
    class Vector2
    {
        public static int Change = 1;
        public int[] Pos;

        public Vector2()
        {
            Pos = new[] { 0, 0 };
        }

        public Vector2(int x, int y)
        {
            Pos = new[] { x, y };
        }

        public Vector2(Vector2 vector2)
        {
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

        public static Vector2[] IterateBuildCurve(int times)
        {
            Vector2[] start = { new Vector2() };
            for (int i = 0; i < times; i++) start = BuildCurve(start);
            return start;
        }

        public static Vector2[] BuildCurve(Vector2[] input)
        {
            Vector2[] first = RotateX(NewVector2v21D(input));
            Vector2[] second = NewVector2v21D(input);
            Vector2[] third = NewVector2v21D(input);
            Vector2[] fourth = RotateXY(NewVector2v21D(input));
            int length = (int)Math.Sqrt(input.Length);
            // This makes
            second = Add(second, 0, Change * length);
            third = Add(third, Change * length, Change * length);
            fourth = Add(fourth, Change * length, 0);
            return Add(first, Add(second, Add(third, fourth)));
        }

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

        public static Vector2[] Add(Vector2[] input, int x, int y)
        {
            Vector2[] newVector2 = new Vector2[input.GetLength(0)];
            for (int i = 0; i < input.GetLength(0); i++) newVector2[i] = Add(input[i], x, y);
            return newVector2;
        }

        public static Vector2 Add(Vector2 input, int x, int y)
        {
            return new Vector2(input[0] + x, input[1] + y);
        }

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

        public static Vector2[] SubArray(Vector2[] data, int index, int length)
        {
            Vector2[] result = new Vector2[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}