using lab6._3;

class Program
{
    static void Main()
    {
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);

        
        Quaternion sum = q1 + q2;
        Console.WriteLine("Результат додавання: W={0}, X={1}, Y={2}, Z={3}", sum.W, sum.X, sum.Y, sum.Z);

        
        Quaternion difference = q1 - q2;
        Console.WriteLine("Результат віднімання: W={0}, X={1}, Y={2}, Z={3}", difference.W, difference.X, difference.Y, difference.Z);

       
        Quaternion product = q1 * q2;
        Console.WriteLine("Результат множення: W={0}, X={1}, Y={2}, Z={3}", product.W, product.X, product.Y, product.Z);

        
        double magnitude = q1.Magnitude();
        Console.WriteLine("Норма кватерніона q1: {0}", magnitude);

       
        Quaternion conjugate = q1.Conjugate();
        Console.WriteLine("Спряжений кватерніон q1: W={0}, X={1}, Y={2}, Z={3}", conjugate.W, conjugate.X, conjugate.Y, conjugate.Z);

      
        Quaternion inverse = q1.Inverse();
        Console.WriteLine("Інверсний кватерніон q1: W={0}, X={1}, Y={2}, Z={3}", inverse.W, inverse.X, inverse.Y, inverse.Z);

      
        double[,] rotationMatrix = q1.ToRotationMatrix();
        Console.WriteLine("Матриця обертання з кватерніона q1:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"{rotationMatrix[i, j]}\t");
            }
            Console.WriteLine();
        }
    }
}