using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestCRUD
{

    public interface IEmployee
    {
        Employee Create(string fullName, DateTime birthDate);
        IEnumerable<Employee> ReadAll();
        Employee ReadById(string id);
        Employee Update(string id, string fullName, DateTime birthDate);
        bool Delete(string id);
    }
  
    public class EmployeeServices : IEmployee
    {
        private readonly List<Employee> _employees;
        private int _nextId;

        public EmployeeServices()
        {
            _employees = new List<Employee>();
            _nextId = 1001;
        }

        public Employee Create(string fullName, DateTime birthDate)
        {
            try
            {
                foreach (var item in _employees)
                {
                    if (item.FullName == fullName)
                    {
                        throw new Exception($"Karyawan dengan Nama {fullName} Sudah Terdaftar\n");
                    }
                }
                var employee = new Employee
                {
                    EmployeeId = (_nextId++).ToString(),
                    FullName = fullName,
                    BirthDate = birthDate
                };
                _employees.Add(employee);
                return employee;
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Employee> ReadAll()
        {
            try
            {
                if (_employees.Count == 0)
                {
                    throw new Exception("Belum Ada Data\n\n");                    
                }
                return _employees;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee ReadById(string id)
        {
            try
            {
                var employee = _employees.SingleOrDefault(e => e.EmployeeId == id);
                return employee ?? throw new Exception($"Karyawan dengan Employee ID : {id} Tidak ditemukan\n");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee Update(string id, string fullName, DateTime birthDate)
        {
            try
            {
                var employee = _employees.SingleOrDefault(e => e.EmployeeId == id);
                if (employee != null)
                {
                    employee.FullName = fullName;
                    employee.BirthDate = birthDate;
                }
                else
                {
                    throw new Exception($"Karyawan dengan Employee ID : {id} Tidak ditemukan\n");
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(string id)
        {
            try
            {
                var employee = _employees.SingleOrDefault(e => e.EmployeeId == id);
                if (employee != null)
                {
                    _employees.Remove(employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}