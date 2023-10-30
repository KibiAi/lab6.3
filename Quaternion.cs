using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6._3
{
    public class Quaternion
    {
        public double W { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Quaternion(double w, double x, double y, double z)
        {
            W = w;
            X = x;
            Y = y;
            Z = z;
        }

        // Перевантаження додавання
        public static Quaternion operator +(Quaternion a, Quaternion b)
        {
            return new Quaternion(a.W + b.W, a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        // Перевантаження віднімання
        public static Quaternion operator -(Quaternion a, Quaternion b)
        {
            return new Quaternion(a.W - b.W, a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        // Перевантаження множення
        public static Quaternion operator *(Quaternion a, Quaternion b)
        {
            double w = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
            double x = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y;
            double y = a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X;
            double z = a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W;
            return new Quaternion(w, x, y, z);
        }

        // Перевантаження порівняння
        public static bool operator ==(Quaternion a, Quaternion b)
        {
            return a.W == b.W && a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Quaternion a, Quaternion b)
        {
            return !(a == b);
        }

        // Метод для обчислення кватерніона
        public double Magnitude()
        {
            return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
        }

        // Метод для обчислення спряженого кватерніона
        public Quaternion Conjugate()
        {
            return new Quaternion(W, -X, -Y, -Z);
        }

        // Метод для обчислення інверсного кватерніона
        public Quaternion Inverse()
        {
            Quaternion conjugate = Conjugate();
            double magnitude = Magnitude();
            double magnitudeSquared = magnitude * magnitude;

            return new Quaternion(conjugate.W / magnitudeSquared, conjugate.X / magnitudeSquared, conjugate.Y / magnitudeSquared, conjugate.Z / magnitudeSquared);
        }

        // Метод для конвертації кватерніона в матрицю обертанн
        public double[,] ToRotationMatrix()
        {
            double[,] matrix = new double[3, 3];

            double xx = X * X;
            double yy = Y * Y;
            double zz = Z * Z;
            double xy = X * Y;
            double xz = X * Z;
            double yz = Y * Z;
            double wx = W * X;
            double wy = W * Y;
            double wz = W * Z;

            matrix[0, 0] = 1 - 2 * (yy + zz);
            matrix[0, 1] = 2 * (xy - wz);
            matrix[0, 2] = 2 * (xz + wy);

            matrix[1, 0] = 2 * (xy + wz);
            matrix[1, 1] = 1 - 2 * (xx + zz);
            matrix[1, 2] = 2 * (yz - wx);

            matrix[2, 0] = 2 * (xz - wy);
            matrix[2, 1] = 2 * (yz + wx);
            matrix[2, 2] = 1 - 2 * (xx + yy);

            return matrix;
        }
    }

}
