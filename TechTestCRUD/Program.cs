using System;
using TechTestCRUD;

class Program
{
    static void Main()
    {
        IEmployee service = new EmployeeServices();
        Console.WriteLine();
        //Create
        var employee1 = service.Create("Adit", new DateTime(1954, 8, 17));
        var employee2 = service.Create("Anton", new DateTime(1954, 8, 18));
        var employee3 = service.Create("Amir", new DateTime(1954, 8, 19));
        Console.WriteLine();
        // Read
        Console.WriteLine("Daftar Karyawan");
        foreach (var employee in service.ReadAll())
        {
            Console.WriteLine($"{employee.EmployeeId}: {employee.FullName}, {employee.BirthDate.ToShortDateString()}");
        }
        Console.WriteLine();
        // Update
        var updatedEmployee = service.Update(employee1.EmployeeId, "Adit Update", new DateTime(2014, 5, 20));
        if (updatedEmployee != null)
        {
            Console.WriteLine($"Updated Data Karyawan\n{updatedEmployee.EmployeeId}: {updatedEmployee.FullName}, {updatedEmployee.BirthDate.ToShortDateString()}");
        }
        Console.WriteLine();
        // Delete
        bool deleted = service.Delete(employee2.EmployeeId);
        if (deleted)
        {
            Console.WriteLine($"Hapus data Karyawan dengan ID : {employee2.EmployeeId}");
        }
        Console.WriteLine();
        Console.WriteLine($"Setelah Delete Data Karyawan");
        foreach (var employee in service.ReadAll())
        {
            Console.WriteLine($"{employee.EmployeeId}: {employee.FullName}, {employee.BirthDate.ToShortDateString()}");
        }
        Console.WriteLine();
        var employee4 = service.Create("Budi Baru", new DateTime(1999, 8, 20));
        var employee5 = service.Create("Ani Baru", new DateTime(2000, 8, 20));

        Console.WriteLine("Setelah ditambah 2 data Baru");
        Console.WriteLine(new string('-', 35)); // Garis pemisah
        Console.WriteLine($"{"ID",-5} {"| FullName",-12} {" | Birth Date",-12}");
        Console.WriteLine(new string('-', 35)); // Garis pemisah
        foreach (var employee in service.ReadAll())
        {
            Console.WriteLine($"{employee.EmployeeId,-5} | {employee.FullName,-12}| {employee.BirthDate:dd-MMM-yy}");
        }
    }
}
