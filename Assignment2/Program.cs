﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceAssignmentDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralManager gm = new GeneralManager("Mahesh", 5, 30000, "SE", "nothing");
            Console.WriteLine(gm.CalcNetSalary());

            Console.WriteLine();

            CEO ceo = new CEO();
            Console.WriteLine(ceo.CalcNetSalary());

            Console.ReadLine();
        }
    }

    /* Employee
    Prop

     string Name -> no blanks

     int EmpNo -> readonly, autogenerated
     short DeptNo -> > 0
     abstract decimal Basic
    Methods
     abstract decimal CalcNetSalary()
    */

    public abstract class Employee
    {
        private string Name;
        private int EmpNo;
        private short DeptNo;
        public decimal Basic;
        private static int cnt;

        public Employee(string Name = "EmpName", short DeptNo = 10, decimal Basic = 25000)
        {
            EmpNo = ++cnt;
            this.Name = Name;
            this.DeptNo = DeptNo;
            this.Basic = Basic;
        }

        public int EMPNO
        {
            get
            {
                return EmpNo;
            }
        }

        public string NAME
        {
            set
            {
                if (value != null)
                    Name = value;
                else
                    Console.WriteLine("Name cannot be null");
            }
            get
            {
                return Name;
            }
        }

        public short DEPTNO
        {
            set
            {
                if (value > 0)
                    DeptNo = value;
                else
                    Console.WriteLine("DeptNo should be greater than zero");
            }
            get
            {
                return DeptNo;
            }
        }

        public abstract decimal BASIC
        {
            set;
            get;
        }

        public abstract decimal CalcNetSalary();
    }

    /*
     Manager : Employee
   Prop
	string Designation -> cant be blank
    */

    public class Manager : Employee
    {
        private string Designation;
        public Manager(string Name = "EmpName", short DeptNo = 10, decimal Basic = 25000, string Designation = "NoDesignation") : base(Name, DeptNo, Basic)
        {
            this.Designation = Designation;
        }

        public string DESIGNATION
        {
            set
            {
                if (value != null)
                    Designation = value;
                else
                    Console.WriteLine("Designation cannot be empty");
            }
            get
            {
                return Designation;
            }
        }

        public override decimal BASIC
        {
            set
            {
                if (value > 0 && value < 100000)
                    Basic = value;
                else
                    Console.WriteLine("Basic Sal should be in range between 0 to 100000");
            }
            get
            {
                return Basic;
            }
        }

        public override decimal CalcNetSalary()
        {
            return BASIC + 2000;
        }
    }

    /*GeneralManager : Manager
   Prop
 	string Perks -> no validations
    */

    public class GeneralManager : Manager
    {
        private string Perks;

        public GeneralManager(string Name = "EmpName", short DeptNo = 10, decimal Basic = 25000, string Designation = "NoDesignation", string Perks = null) : base(Name, DeptNo, Basic, Designation)
        {
            this.Perks = Perks;
        }

        public string PERKS
        {
            set
            {
                Perks = value;
            }
            get
            {
                return Perks;
            }
        }
    }

    /*
     * CEO : Employee
      Make CalNetSalary() a sealed method
    */

    public class CEO : Employee
    {
        public override decimal BASIC
        {
            set
            {
                if (value > 0 && value < 100000)
                    Basic = value;
                else
                    Console.WriteLine("Basic Sal should be in range between 0 to 100000");
            }
            get
            {
                return Basic;
            }
        }

        public sealed override decimal CalcNetSalary()
        {
            return BASIC + 5000;
        }
    }
}