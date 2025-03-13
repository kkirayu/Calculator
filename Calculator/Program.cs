using System;

class Calculator
{
    static void Main(string[] args)
    {
        bool lanjutkan = true;
        
        while (lanjutkan)
        {
            Console.Clear();
            Console.WriteLine("======= KALKULATOR V1 =======");
            Console.WriteLine("1. Penambahan");
            Console.WriteLine("2. Pengurangan");
            Console.WriteLine("3. Perkalian");
            Console.WriteLine("4. Pembagian");
            Console.WriteLine("5. Modulus (Sisa Bagi)");
            Console.WriteLine("6. Pangkat");
            Console.WriteLine("7. Akar Kuadrat");
            Console.WriteLine("8. Nilai Absolut");
            Console.WriteLine("0. Keluar");
            Console.WriteLine("==================================");
            
            Console.Write("\nPilih operasi (0-8): ");
            string pilihan = Console.ReadLine();
            
            switch (pilihan)
            {
                case "0":
                    lanjutkan = false;
                    Console.WriteLine("\nTerima kasih telah menggunakan kalkulator ini!");
                    break;
                    
                case "1": 
                    ProsesOperasiDuaAngka("Penambahan", Penambahan);
                    break;
                    
                case "2": 
                    ProsesOperasiDuaAngka("Pengurangan", Pengurangan);
                    break;
                    
                case "3": 
                    ProsesOperasiDuaAngka("Perkalian", Perkalian);
                    break;
                    
                case "4": 
                    ProsesOperasiDuaAngka("Pembagian", Pembagian);
                    break;
                    
                case "5": 
                    ProsesOperasiDuaAngka("Modulus", Modulus);
                    break;
                    
                case "6": 
                    ProsesOperasiDuaAngka("Pangkat", Pangkat);
                    break;
                    
                case "7": 
                    ProsesOperasiSatuAngka("Akar Kuadrat", AkarKuadrat);
                    break;
                    
                case "8": 
                    ProsesOperasiSatuAngka("Nilai Absolut", NilaiAbsolut);
                    break;
                    
                default:
                    Console.WriteLine("\nPilihan tidak valid. Silakan coba lagi.");
                    break;
            }
            
            if (lanjutkan)
            {
                Console.WriteLine("\nTekan sembarang key untuk melanjutkan...");
                Console.ReadKey();
            }
        }
    }
    
    static void ProsesOperasiDuaAngka(string namaOperasi, Func<double, double, double> operasi)
    {
        try
        {
            Console.WriteLine($"\n=== {namaOperasi} ===");
            Console.Write("Masukkan angka pertama: ");
            double a = Convert.ToDouble(Console.ReadLine());
            
            Console.Write("Masukkan angka kedua: ");
            double b = Convert.ToDouble(Console.ReadLine());
            
            double hasil = operasi(a, b);
            Console.WriteLine($"\nHasil {namaOperasi}: {a} {GetOperatorSymbol(namaOperasi)} {b} = {hasil}");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nERROR: Masukkan harus berupa angka.");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("\nERROR: Pembagian dengan nol tidak diperbolehkan.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR: {ex.Message}");
        }
    }
    
    
    static void ProsesOperasiSatuAngka(string namaOperasi, Func<double, double> operasi)
    {
        try
        {
            Console.WriteLine($"\n=== {namaOperasi} ===");
            Console.Write("Masukkan angka: ");
            double a = Convert.ToDouble(Console.ReadLine());
            
            double hasil = operasi(a);
            Console.WriteLine($"\nHasil {namaOperasi} dari {a} = {hasil}");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nERROR: Masukkan harus berupa angka.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nERROR: {ex.Message}");
        }
    }
    
    static string GetOperatorSymbol(string namaOperasi)
    {
        switch (namaOperasi)
        {
            case "Penambahan": return "+";
            case "Pengurangan": return "-";
            case "Perkalian": return "×";
            case "Pembagian": return "÷";
            case "Modulus": return "%";
            case "Pangkat": return "^";
            default: return "";
        }
    }
    static double Penambahan(double a, double b)
    {
        return a + b;
    }
    
    static double Pengurangan(double a, double b)
    {
        return a - b;
    }
    
    static double Perkalian(double a, double b)
    {
        return a * b;
    }
    
    static double Pembagian(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException();
        return a / b;
    }
    
    static double Modulus(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException();
        return a % b;
    }
    
    static double Pangkat(double a, double b)
    {
        return Math.Pow(a, b);
    }
    
    static double AkarKuadrat(double a)
    {
        if (a < 0)
            throw new ArgumentException("Tidak bisa menghitung akar kuadrat dari angka negatif");
        return Math.Sqrt(a);
    }
    
    static double NilaiAbsolut(double a)
    {
        return Math.Abs(a);
    }
}