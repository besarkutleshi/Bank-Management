﻿using EntityLayer.Persons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Departaments;
using EntityLayer.Entity;
using DataAccessLayer.Interface;

namespace DataAccessLayer.Persons
{
    public class EmployeeRepository:IReader<Employees>
    {
        ApplicationDbContext context;
        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public async Task<ActionResult<Employees>> InsertEmployee(Employees obj)
        {
            try
            {
                context.Employees.Add(obj);
                if (await context.SaveChangesAsync() > 0)
                {
                    return obj;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ActionResult<Employees>> DeleteEmployee(int id)
        {
            try
            {
                EntityLayer.Persons.Persons p = context.Persons.Where(p => p.Id == id).FirstOrDefault();
                Employees emp = context.Employees.OfType<Employees>().Where(emp => emp.PersonId == id).FirstOrDefault();
                context.Employees.Remove(emp);
                context.Persons.Remove(p);
                if (await context.SaveChangesAsync() > 0)
                {
                    return emp;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ActionResult<Employees>> UpdateEmployee(Employees emp)
        {
            try
            {
                var person = context.Persons.Attach(emp.Person);
                person.State = EntityState.Modified;
                await context.SaveChangesAsync();
                var employee = context.Employees.Attach(emp);
                employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
                return emp;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Employees>> Read()
        {
            try
            {
                await context.Persons.ToListAsync();
                await context.Departaments.ToListAsync();
                return await context.Employees.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Employees> Read(int id)
        {
            try
            {
                EntityLayer.Persons.Persons p = await context.Persons.Where(p => p.Id == id).FirstOrDefaultAsync();
                Employees emps = await context.Employees.Where(emp => emp.PersonId == id).FirstOrDefaultAsync();
                emps.Person = p;
                return emps;
            }
            catch (Exception)
            {
                return null;
            }       
        }

        public async Task<Employees> Read(string name)
        {
            try
            {
                EntityLayer.Persons.Persons p = await context.Persons.Where(p => p.Name == name).FirstOrDefaultAsync();
                Employees emps = await context.Employees.Where(emp => emp.Person.Name == name).FirstOrDefaultAsync();
                return emps;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Employees GetEmailEmployee(string email)
        {
            context.Persons.ToList();
            return context.Employees.FirstOrDefault(p => p.Person.Email == email);
        }

        public async Task<EntityLayer.Persons.Persons> GetPersons(int id)
        {
            return await context.Persons.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
