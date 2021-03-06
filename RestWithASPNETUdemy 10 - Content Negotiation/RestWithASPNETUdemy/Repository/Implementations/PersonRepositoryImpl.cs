﻿using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private MySQLContext _context;
        private volatile int count;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if(result != null)_context.Person.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exists(long? id)
        {
            return _context.Person.Any(p => p.Id.Equals(id));
        }

        public List<Person> FindAll()
        {
            return _context.Person.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Person.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return null;
            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(long? id)
        {
            return _context.Person.Any(p => p.Id.Equals(id));
        }
    }
}
